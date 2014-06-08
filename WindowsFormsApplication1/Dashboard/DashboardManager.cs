using System;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;
using Transitions;
using WCF.Proxies;
using WebsBO;

namespace WindowsFormsApplication1.Dashboard {
	public partial class DashboardManager : Form {
		private readonly FrmMdi _frmMdi;
		private LivreBO _livreSelected;
		private FicheDeLivre _ficheDeLivre;
		private FicheDeLivreReservation _ficheDeLivreReservation;

		private int _dashboardWidth;
		private int _lblBibliothequeLocationX;
		private int _lblBibliothequeTitleLocationX;
		private int _lblDtLastLocationX;
		private int _lblDtLastVisiteTitleLocationX;

		private FicheLivreBO _actualFicheLivre;

		private delegate FicheLivreBO AsyncGuiFicheDeLivreSelectForClientById(String token, Int32 pClientId, Int32 pLivreId);

		public DashboardManager() {
			InitializeComponent();
		}

		public DashboardManager(FrmMdi frmMdi) : this() {
			_frmMdi = frmMdi;
		}

		private void LoadEmprunt(){
			var lstEmprunt = CGlobalCache.LstEmpruntByClient;
			lstEmpruntEnCours.Items.Clear();
			var toto = lstEmprunt.GroupBy(xx => xx.LivreId).Select(xx => new { xx.Key, state = xx.Min(p => p.State)}).ToList();
			var query = CGlobalCache.LstLivreSelectAll.Join(toto.Where(xx => xx.state == "emp"), bo => bo.LivreId, arg => arg.Key, (key1, key2) => key1.RefLivre );
			var query2 = CGlobalCache.LstLivreSelectAll.Join(toto.Where(xx => xx.state == "reg"), bo => bo.LivreId, arg => arg.Key, (key1, key2) => key1.RefLivre );
			lstEmpruntEnCours.Items.AddRange(items: Enumerable.ToArray(source: query));
			lstEmpruntPasse.Items.AddRange(items: Enumerable.ToArray(source: query2));
		}

		private void LoadReservation() {
			var lstDemandeReservationEnCours = CGlobalCache.LstNewDemandeReservationByClient;
			lstReservationEnCours.Items.Clear();
			lstReservationEnCours.Items.AddRange(items: lstDemandeReservationEnCours.ToArray());

			var lstDemandeReservationPasse = CGlobalCache.LstOldDemandeReservationByClient;
			lstReservationPasse.Items.Clear();
			lstReservationPasse.Items.AddRange(items: lstDemandeReservationPasse.ToArray());
		}

		private void LoadDecoration() {
			var personne = CGlobalCache.SessionManager.Personne;
			lblName.Text = personne.ToString();
			lblDtLastVisite.Text = "";
			lblBibliotheque.Text = personne.Client.Bibliotheque.BibliothequeName;
		}

		private void LoadNouveaute() {
			/*
			foreach (LivreBO objLivre in CGlobalCache.LstLivreByBibliotheque.FindAll(xx => {TimeSpan diff = DateTime.Now - xx.CreatedAt; return diff.Days < 10;})) {
				lstNewLivreLocal.Items.Add(objLivre.ToString());
			}
			*/

			// Select Uniq in a list !!!
			var lstUniqLocalLivre = CGlobalCache.LstLivreByBibliotheque.GroupBy(cust => cust.RefLivre.RefLivreId).Select(grp => grp.First()).OrderByDescending(xx => xx.CreatedAt).Take(25).ToList();
			lstNewLivreLocal.Items.Clear();
			lstNewLivreLocal.Items.AddRange(lstUniqLocalLivre.ToArray());

			// Select Uniq in a list !!!
			var bibliothequeId = CGlobalCache.SessionManager.Personne.Client.BibliothequeId;
			var lstUniqNetworkLivre = CGlobalCache.LstLivreSelectAll.ToList().FindAll(xx => xx.BibliothequeId != bibliothequeId).GroupBy(cust => cust.RefLivre.RefLivreId).Select(grp => grp.First()).OrderByDescending(xx => xx.CreatedAt).Take(25).ToList();
			lstNewLivreNetwork.Items.Clear();
			lstNewLivreNetwork.Items.AddRange(lstUniqNetworkLivre.ToArray());
		}

		private Boolean InsertDemandeReservation() {
			var bResult = false;
			DemandeReservationBO objDemandeReservation = new DemandeReservationBO(), demandeReservationResult;
			objDemandeReservation.Client = CGlobalCache.SessionManager.Personne.Client;
			objDemandeReservation.RefLivre = _livreSelected.RefLivre;

			DemandeReservationIFACClient demandeReservationIFacClient = null;
			try {
				demandeReservationIFacClient = new DemandeReservationIFACClient();
				demandeReservationResult = demandeReservationIFacClient.InsertDemandeReservation(CGlobalCache.SessionManager.Token, objDemandeReservation);
			} catch (Exception ex) {
				throw;
			} finally {
				if (demandeReservationIFacClient != null) {
					demandeReservationIFacClient.Close();
				}
			}
			if (demandeReservationResult != null) {
				CGlobalCache.AddNewDemandeReservationByClient(demandeReservationResult);
				bResult = true;
			}
			return bResult;
		}

		private void LoadFicheLivre(DemandeReservationBO pDemandeReservation) {
			CreateFicheLivreReservation();
			
			var refLivreIFac = new RefLivreIFACClient();
			
			AsyncGuiFicheDeLivreSelectForClientById asyncExecute = refLivreIFac.SelectFicheLivreForClientByRefLivreId;
			try {
				asyncExecute.BeginInvoke(CGlobalCache.SessionManager.Token, CGlobalCache.SessionManager.Personne.Client.ClientId, pDemandeReservation.RefLivreId, xx => {
					var samplePersDelegate = (AsyncGuiFicheDeLivreSelectForClientById)((AsyncResult)xx).AsyncDelegate;
					_actualFicheLivre = samplePersDelegate.EndInvoke(xx);
					_ficheDeLivreReservation.setFicheDeLivre(_actualFicheLivre);
					refLivreIFac.Close();
				}, null);
			} catch(Exception) {
				refLivreIFac.Close();
				MessageBox.Show(Resources.DashboardManager_loadFicheLivre_Erreur_lors_de_la_recuperation_des_informations_sur_le_livre_demande_);
			}
		}

		private void LoadFicheLivre(LivreBO pLivreBo) {
			CreateFicheLivre();
			var livreIFac = new LivreIFACClient();
			
			AsyncGuiFicheDeLivreSelectForClientById asyncExecute = livreIFac.SelectFicheLivreForClientByLivreId;
			try {
				asyncExecute.BeginInvoke(CGlobalCache.SessionManager.Token, CGlobalCache.SessionManager.Personne.Client.ClientId, pLivreBo.LivreId, xx => {
					var samplePersDelegate = (AsyncGuiFicheDeLivreSelectForClientById)((AsyncResult)xx).AsyncDelegate;
					_actualFicheLivre = samplePersDelegate.EndInvoke(xx);
					_ficheDeLivre.setFicheDeLivre(_actualFicheLivre);
					livreIFac.Close();
				}, null);
			} catch(Exception) {
				livreIFac.Close();
				MessageBox.Show(Resources.DashboardManager_loadFicheLivre_Erreur_lors_de_la_recuperation_des_informations_sur_le_livre_demande_);
			}

		}

		private void CreateFicheLivre() {
			if (_ficheDeLivre != null) {
				return;
			}

			if (_ficheDeLivreReservation != null) {
				Controls.Remove(_ficheDeLivreReservation);
				_ficheDeLivreReservation = null;
			}
			
			_ficheDeLivre = new FicheDeLivre(this){Location = new Point(882, 56)};

			var t1 = new Transition(new TransitionType_EaseInEaseOut(1000));
			t1.add(this, "Width", _dashboardWidth + _ficheDeLivre.Width + 10);
			t1.add(lblBibliotheque, "Left", _lblBibliothequeLocationX + _ficheDeLivre.Width + 10);
			t1.add(lblBibliothequeTitle, "Left", _lblBibliothequeTitleLocationX + _ficheDeLivre.Width + 10);
			t1.add(lblDtLastVisite, "Left", _lblDtLastLocationX + _ficheDeLivre.Width + 10);
			t1.add(lblDtLastVisiteTitle, "Left", _lblDtLastVisiteTitleLocationX + _ficheDeLivre.Width + 10);

			Controls.Add(_ficheDeLivre);

			t1.run();
		}

		private void CreateFicheLivreReservation() {
			if (_ficheDeLivreReservation != null) {
				return;
			}

			if (_ficheDeLivre != null) {
				Controls.Remove(_ficheDeLivre);
				_ficheDeLivre = null;
			}

			_ficheDeLivreReservation = new FicheDeLivreReservation(this){Location = new Point(882, 56)};

			var t1 = new Transition(new TransitionType_EaseInEaseOut(1000));
			t1.add(this, "Width", _dashboardWidth + _ficheDeLivreReservation.Width + 10);
			t1.add(lblBibliotheque, "Left", _lblBibliothequeLocationX + _ficheDeLivreReservation.Width + 10);
			t1.add(lblBibliothequeTitle, "Left", _lblBibliothequeTitleLocationX + _ficheDeLivreReservation.Width + 10);
			t1.add(lblDtLastVisite, "Left", _lblDtLastLocationX + _ficheDeLivreReservation.Width + 10);
			t1.add(lblDtLastVisiteTitle, "Left", _lblDtLastVisiteTitleLocationX + _ficheDeLivreReservation.Width + 10);
			Controls.Add(_ficheDeLivreReservation);

			t1.run();
		}

		private void LoadReservation(DemandeReservationBO value, EventArgs e) {
			LoadReservation();
		}

		private void CleanListBoxSelected(IDisposable actualListBox){
			foreach (var listBox2 in Controls.OfType<Panel>().SelectMany(panel => panel.Controls.OfType<ListBox>().Where(xx => xx.GetHashCode() != actualListBox.GetHashCode()))){
				listBox2.ClearSelected();
			}
		}

		internal void AnnuleDemandeReservation() {
			throw new NotImplementedException();
		}

		private void DashboardManager_Load(object sender, EventArgs e) {
			_dashboardWidth = Width;
			_lblBibliothequeLocationX = lblBibliotheque.Location.X ;
			_lblBibliothequeTitleLocationX = lblBibliothequeTitle.Location.X;
			_lblDtLastLocationX = lblDtLastVisite.Location.X;
			_lblDtLastVisiteTitleLocationX = lblDtLastVisiteTitle.Location.X;

			CGlobalCache.ActualLstDemandeReservationEventHandlser += LoadReservation;

			LoadDecoration();

			LoadNouveaute();

			LoadReservation();

			LoadEmprunt();
		}

		private void LivreEmprunt_MouseDown(object sender, MouseEventArgs e) {
			var listBox = (ListBox)sender;

			listBox.SelectedIndex = listBox.IndexFromPoint(e.Location);
			if (listBox.SelectedIndex == -1) {
				return;
			}

			CleanListBoxSelected(listBox);

			if (e.Button == MouseButtons.Right) {
				//select the item under the mouse pointer
				contextMenuStrip1.Show(Cursor.Position);
				_livreSelected = (LivreBO)listBox.SelectedItem;
				
			}
			if (e.Button == MouseButtons.Left) {
				LoadFicheLivre((LivreBO)listBox.SelectedItem);
			}
		}

		private void LivreStatus_MouseDown(object sender, MouseEventArgs e) {
			var listBox = (ListBox)sender;

			listBox.SelectedIndex = listBox.IndexFromPoint(e.Location);
			if (listBox.SelectedIndex == -1) {
				return;
			}

			CleanListBoxSelected(listBox);

			if (e.Button == MouseButtons.Left) {
				LoadFicheLivre((DemandeReservationBO)listBox.SelectedItem);
			}
		}

		private void totoToolStripMenuItem_Click(object sender, EventArgs e) {
			if (_livreSelected == null) {
				return;
			}
			if (!InsertDemandeReservation()) {
				MessageBox.Show(Resources.DashboardManager_totoToolStripMenuItem_Click_Le_livre_n_a_pas_pu_etre_ajoute_dans_votre_liste_de_demande);
			}
		}

		private void DashboardManager_FormClosing(object sender, FormClosingEventArgs e) {
			_frmMdi.ChildFormDecrement();
		}

	}
}
