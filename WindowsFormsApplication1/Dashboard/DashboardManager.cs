using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;
using WCF.Proxies;
using WebsBO;

namespace WindowsFormsApplication1.Dashboard {
	public partial class DashboardManager : Form {
		private FrmMdi _frmMdi;
		private LivreBO _livreSelected;
		private FicheDeLivre _ficheDeLivre;
		private FicheDeLivreReservation _ficheDeLivreReservation;
		private const int ADD_DASHBOARD_FICHE_DE_LIVRE = 596;
		private const int ADD_DASHBOARD_FICHE_DE_LIVRE_RESERVATION = 544;
		private int _dashboardWidth;
		private int _lblBibliothequeLocationX;
		private int _lblBibliothequeTitleLocationX;
		private int _lblDtLastLocationX;
		private int _lblDtLastVisiteTitleLocationX;
		private FicheLivreBO _actualFicheLivre;

		private delegate FicheLivreBO AsyncGuiFicheDeLivreSelectForClientById(String Token, Int32 pClientId, Int32 pLivreId);

		public DashboardManager() {
			InitializeComponent();
		}

		public DashboardManager(FrmMdi frmMdi)
			: this() {
			this._frmMdi = frmMdi;
		}

		private void loadReservation() {
			List<DemandeReservationBO> lstDemandeReservationEnCours = CGlobalCache.LstNewDemandeReservationByClient;
			lstReservationEnCours.Items.Clear();
			lstReservationEnCours.Items.AddRange(lstDemandeReservationEnCours.ToArray());

			List<DemandeReservationBO> lstDemandeReservationPasse = CGlobalCache.LstOldDemandeReservationByClient;
			lstReservationPasse.Items.Clear();
			lstReservationPasse.Items.AddRange(lstDemandeReservationPasse.ToArray());
		}

		private void loadDecoration() {
			PersonneBO personne = CGlobalCache.SessionManager.Personne;
			lblName.Text = String.Format(@"{0} {1}", personne.PersonneFirstName, personne.PersonneLastName);
			lblDtLastVisite.Text = "";
			lblBibliotheque.Text = personne.Client.Bibliotheque.BibliothequeName;
		}

		private void loadNouveaute() {
			/*
			foreach (LivreBO objLivre in CGlobalCache.LstLivreByBibliotheque.FindAll(xx => {TimeSpan diff = DateTime.Now - xx.CreatedAt; return diff.Days < 10;})) {
				lstNewLivreLocal.Items.Add(objLivre.ToString());
			}
			*/

			// Select Uniq in a list !!!
			List<LivreBO> lstUniqLocalLivre = CGlobalCache.LstLivreByBibliotheque.GroupBy(cust => cust.RefLivre.RefLivreId).Select(grp => grp.First()).OrderByDescending(xx => xx.CreatedAt).Take(25).ToList();
			lstNewLivreLocal.Items.Clear();
			lstNewLivreLocal.Items.AddRange(lstUniqLocalLivre.ToArray());

			// Select Uniq in a list !!!
			Int32 bibliothequeId = CGlobalCache.SessionManager.Personne.Client.BibliothequeId;
			List<LivreBO> lstUniqNetworkLivre = CGlobalCache.LstLivreSelectAll.FindAll(xx => xx.BibliothequeId != bibliothequeId).GroupBy(cust => cust.RefLivre.RefLivreId).Select(grp => grp.First()).OrderByDescending(xx => xx.CreatedAt).Take(25).ToList();
			lstNewLivreNetwork.Items.Clear();
			lstNewLivreNetwork.Items.AddRange(lstUniqNetworkLivre.ToArray());
		}

		private Boolean InsertDemandeReservation() {
			Boolean bResult = false;
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

		private void loadFicheLivre(DemandeReservationBO pDemandeReservation) {
			this.createFicheLivreReservation();
			
			RefLivreIFACClient refLivreIFac = new RefLivreIFACClient();
			
			AsyncGuiFicheDeLivreSelectForClientById asyncExecute = refLivreIFac.SelectFicheLivreForClientByRefLivreId;
			try {
				asyncExecute.BeginInvoke(CGlobalCache.SessionManager.Token, CGlobalCache.SessionManager.Personne.Client.ClientId, pDemandeReservation.RefLivreId, xx => {
					var samplePersDelegate = (AsyncGuiFicheDeLivreSelectForClientById)((AsyncResult)xx).AsyncDelegate;
					_actualFicheLivre = samplePersDelegate.EndInvoke(xx);
					_ficheDeLivreReservation.setFicheDeLivre(_actualFicheLivre);
					if (refLivreIFac != null) {
						refLivreIFac.Close();
					}
				}, null);
			} catch(Exception ex) {
				if (refLivreIFac != null) {
					refLivreIFac.Close();
				}
				MessageBox.Show("Erreur lors de la récupération des informations sur le livre demandé.");
			}
		}

		private void loadFicheLivre(LivreBO livreBO) {
			this.createFicheLivre();
			LivreIFACClient livreIFac = new LivreIFACClient();
			
			AsyncGuiFicheDeLivreSelectForClientById asyncExecute = livreIFac.SelectFicheLivreForClientByLivreId;
			try {
				asyncExecute.BeginInvoke(CGlobalCache.SessionManager.Token, CGlobalCache.SessionManager.Personne.Client.ClientId, livreBO.LivreId, xx => {
					var samplePersDelegate = (AsyncGuiFicheDeLivreSelectForClientById)((AsyncResult)xx).AsyncDelegate;
					_actualFicheLivre = samplePersDelegate.EndInvoke(xx);
					_ficheDeLivre.setFicheDeLivre(_actualFicheLivre);
					if (livreIFac != null) {
						livreIFac.Close();
					}
				}, null);
			} catch(Exception ex) {
				if (livreIFac != null) {
					livreIFac.Close();
				}
				MessageBox.Show("Erreur lors de la récupération des informations sur le livre demandé.");
			}

		}

		private void createFicheLivre() {
			if (_ficheDeLivre != null) {
				return;
			}

			if (_ficheDeLivreReservation != null) {
				this.Controls.Remove(_ficheDeLivreReservation);
				_ficheDeLivreReservation = null;
			}

			Transition t1 = new Transition(new TransitionType_EaseInEaseOut(1000));
			t1.add(this, "Width", _dashboardWidth + ADD_DASHBOARD_FICHE_DE_LIVRE);
			t1.add(lblBibliotheque, "Left", _lblBibliothequeLocationX + ADD_DASHBOARD_FICHE_DE_LIVRE);
			t1.add(lblBibliothequeTitle, "Left", _lblBibliothequeTitleLocationX + ADD_DASHBOARD_FICHE_DE_LIVRE);
			t1.add(lblDtLastVisite, "Left", _lblDtLastLocationX + ADD_DASHBOARD_FICHE_DE_LIVRE);
			t1.add(lblDtLastVisiteTitle, "Left", _lblDtLastVisiteTitleLocationX + ADD_DASHBOARD_FICHE_DE_LIVRE);

			_ficheDeLivre = new FicheDeLivre(this);
			_ficheDeLivre.Location = new Point(882, 56);
			this.Controls.Add(_ficheDeLivre);

			t1.run();
		}

		private void createFicheLivreReservation() {
			if (_ficheDeLivreReservation != null) {
				return;
			}

			if (_ficheDeLivre != null) {
				this.Controls.Remove(_ficheDeLivre);
				_ficheDeLivre = null;
			}

			Transition t1 = new Transition(new TransitionType_EaseInEaseOut(1000));
			t1.add(this, "Width", _dashboardWidth + ADD_DASHBOARD_FICHE_DE_LIVRE_RESERVATION);
			t1.add(lblBibliotheque, "Left", _lblBibliothequeLocationX + ADD_DASHBOARD_FICHE_DE_LIVRE_RESERVATION);
			t1.add(lblBibliothequeTitle, "Left", _lblBibliothequeTitleLocationX + ADD_DASHBOARD_FICHE_DE_LIVRE_RESERVATION);
			t1.add(lblDtLastVisite, "Left", _lblDtLastLocationX + ADD_DASHBOARD_FICHE_DE_LIVRE_RESERVATION);
			t1.add(lblDtLastVisiteTitle, "Left", _lblDtLastVisiteTitleLocationX + ADD_DASHBOARD_FICHE_DE_LIVRE_RESERVATION);

			_ficheDeLivreReservation = new FicheDeLivreReservation(this);
			_ficheDeLivreReservation.Location = new Point(882, 56);
			this.Controls.Add(_ficheDeLivreReservation);

			t1.run();
		}

		private void loadReservation(DemandeReservationBO value, EventArgs e) {
			loadReservation();
		}

		private void cleanListBoxSelected(ListBox actualListBox) {
			foreach (Panel panel in this.Controls.OfType<Panel>()) {
				foreach (ListBox listBox2 in panel.Controls.OfType<ListBox>().Where(xx => xx.GetHashCode() != actualListBox.GetHashCode())) {
					listBox2.ClearSelected();
				}
			}
		}

		internal void AnnuleDemandeReservation() {
			throw new NotImplementedException();
		}

		private void DashboardManager_Load(object sender, EventArgs e) {
			_dashboardWidth = this.Width;
			_lblBibliothequeLocationX = lblBibliotheque.Location.X ;
			_lblBibliothequeTitleLocationX = lblBibliothequeTitle.Location.X;
			_lblDtLastLocationX = lblDtLastVisite.Location.X;
			_lblDtLastVisiteTitleLocationX = lblDtLastVisiteTitle.Location.X;

			CGlobalCache.actualLstDemandeReservationEventHandlser += this.loadReservation;

			this.loadDecoration();

			this.loadNouveaute();

			this.loadReservation();
		}

		private void DashboardManager_FormClosed(object sender, FormClosedEventArgs e) {
			this._frmMdi.ChildFormDecrement();
			Dispose();
		}

		private void LivreEmprunt_MouseDown(object sender, MouseEventArgs e) {
			ListBox listBox = (ListBox)sender;

			listBox.SelectedIndex = listBox.IndexFromPoint(e.Location);
			if (listBox.SelectedIndex == -1) {
				return;
			}

			this.cleanListBoxSelected(listBox);

			if (e.Button == MouseButtons.Right) {
				//select the item under the mouse pointer
				contextMenuStrip1.Show(Cursor.Position);
				_livreSelected = (LivreBO)listBox.SelectedItem;
				
			}
			if (e.Button == System.Windows.Forms.MouseButtons.Left) {
				this.loadFicheLivre((LivreBO)listBox.SelectedItem);
			}
		}

		private void LivreStatus_MouseDown(object sender, MouseEventArgs e) {
			ListBox listBox = (ListBox)sender;

			listBox.SelectedIndex = listBox.IndexFromPoint(e.Location);
			if (listBox.SelectedIndex == -1) {
				return;
			}

			this.cleanListBoxSelected(listBox);

			if (e.Button == System.Windows.Forms.MouseButtons.Left) {
				this.loadFicheLivre((DemandeReservationBO)listBox.SelectedItem);
			}
		}

		private void totoToolStripMenuItem_Click(object sender, EventArgs e) {
			if (_livreSelected == null) {
				return;
			}
			if (!InsertDemandeReservation()) {
				MessageBox.Show("Le livre n'a pas pu etre ajouté dans votre liste de demande");
			}
		}

	}
}
