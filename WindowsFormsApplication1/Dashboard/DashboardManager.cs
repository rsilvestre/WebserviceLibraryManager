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
		private DemandeReservationBO _demandeReservationSelected;

		private delegate FicheLivreBO AsyncGuiFicheDeLivreSelectForClientById(String token, Int32 pClientId, Int32 pLivreId);
		private delegate DemandeAnnulationBO AsyncGuiDemandeAnnulationInsertAnnulation(String token, Int32 pAdministrateurId, Int32 pDemandeReservatioId);
		private delegate DemandeReservationBO AsyncGuiDemandeReservationInsert(String token, DemandeReservationBO pDemandeReservationBo);
		private delegate ReservationBO AsyncGuiReservationSelectByDemandeReservationId(String token, Int32 pDemandeReservationId);

		public DashboardManager() {
			InitializeComponent();
		}

		public DashboardManager(FrmMdi frmMdi) : this() {
			_frmMdi = frmMdi;
		}

		private void LoadEmprunt(){
			var lstEmprunt = CGlobalCache.LstEmpruntByClient;
			lstEmpruntEnCours.Items.Clear();
			var lstEmpruntEncours = lstEmprunt.FindAll(xx => xx.State == "emp").Select(yy => new { Key = yy.Livre.ToString(), Value = yy }).ToList();
			var lstEmpruntOutDated = lstEmprunt.FindAll(xx => xx.State == "reg" && xx.Transition != "annul").Select(yy => new { Key = yy.Livre.ToString(), Value = yy }).ToList();
			//lstEmpruntEnCours.Items.AddRange(items: Enumerable.ToArray(source: query));
			lstEmpruntEnCours.DataSource = lstEmpruntEncours;
			lstEmpruntEnCours.DisplayMember = "Key";
			lstEmpruntEnCours.ValueMember = "Value";
			//lstEmpruntPasse.Items.AddRange(items: Enumerable.ToArray(source: query2));
			lstEmpruntPasse.DataSource = lstEmpruntOutDated;
			lstEmpruntPasse.DisplayMember = "Key";
			lstEmpruntPasse.ValueMember = "Value";
		}

		private void LoadDemandeReservation() {
			var lstDemandeReservationEnCours = CGlobalCache.LstNewDemandeReservationByClient.Where(xx => xx.Valide == 1);
			lstReservationEnCours.Items.Clear();
			lstReservationEnCours.Items.AddRange(items: lstDemandeReservationEnCours.ToArray());

			var lstDemandeReservationPasse = CGlobalCache.LstOldDemandeReservationByClient.Where(xx => xx.Valide == 0);
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

		private void InsertDemandeReservation(Action<DemandeReservationBO> callbackAction = null) {
			DemandeReservationBO objDemandeReservation = new DemandeReservationBO();
			objDemandeReservation.Client = CGlobalCache.SessionManager.Personne.Client;
			objDemandeReservation.RefLivre = _livreSelected.RefLivre;

			var demandeReservationIFacClient = new DemandeReservationIFACClient();
			AsyncGuiDemandeReservationInsert insertGuiSampleDemandeReservationDelegate = demandeReservationIFacClient.InsertDemandeReservation;
			insertGuiSampleDemandeReservationDelegate.BeginInvoke(CGlobalCache.SessionManager.Token, objDemandeReservation, (result) =>{
				var sampleInsertDemandeReservationDelegate = (AsyncGuiDemandeReservationInsert)((AsyncResult)result).AsyncDelegate;
				var objDemandeReservationResult = sampleInsertDemandeReservationDelegate.EndInvoke(result);
				
				demandeReservationIFacClient.Close();

				if (objDemandeReservationResult == null){
					MessageBox.Show(Resources.DashboardManager_totoToolStripMenuItem_Click_Le_livre_n_a_pas_pu_etre_ajoute_dans_votre_liste_de_demande);
					return;
				}
				
				//CGlobalCache.AddNewDemandeReservationByClient(objDemandeReservationResult);
				CGlobalCache.LstNewDemandeReservationByClient.Add(objDemandeReservationResult);
				if (CGlobalCache.SessionManager.Personne.Administrateur != null){
					CGlobalCache.LstDemandeReservationSelectAll.Add(objDemandeReservationResult);
				}
				
				LoadDemandeReservation();

				if (callbackAction == null){
					return;
				}
				callbackAction(objDemandeReservationResult);
			}, null);
		}

		private void ConfirmReservation(DemandeReservationBO objDemandeReservation, Action<ReservationBO> callbackAction){
			var reservationIFacClient = new ReservationIFACClient();
			AsyncGuiReservationSelectByDemandeReservationId insertGuiSampleDemandeReservationDelegate = reservationIFacClient.SelectEnCoursValidByReservationId;
			insertGuiSampleDemandeReservationDelegate.BeginInvoke(CGlobalCache.SessionManager.Token, objDemandeReservation.DemandeReservationId, (result) =>{
				var sampleInsertDemandeReservationDelegate = (AsyncGuiReservationSelectByDemandeReservationId)((AsyncResult)result).AsyncDelegate;
				var objReservationResult = sampleInsertDemandeReservationDelegate.EndInvoke(result);
				
				reservationIFacClient.Close();

				if (objReservationResult != null && CGlobalCache.SessionManager.IsAdministrateur) {
					CGlobalCache.LstReservationSelectAll.Add(objReservationResult);
				}
				
				if (callbackAction == null){
					return;
				}
				callbackAction(objReservationResult);
			}, null);
		}

		private void LoadFicheLivre(DemandeReservationBO pDemandeReservation) {
			CreateFicheLivreReservation();
			
			var refLivreIFac = new RefLivreIFACClient();
			
			AsyncGuiFicheDeLivreSelectForClientById asyncExecute = refLivreIFac.SelectFicheLivreForClientByRefLivreId;
			try {
				asyncExecute.BeginInvoke(CGlobalCache.SessionManager.Token, CGlobalCache.SessionManager.Personne.Client.ClientId, pDemandeReservation.RefLivreId, xx => {
					var samplePersDelegate = (AsyncGuiFicheDeLivreSelectForClientById)((AsyncResult)xx).AsyncDelegate;
					_actualFicheLivre = samplePersDelegate.EndInvoke(xx);
					if (_ficheDeLivreReservation == null) {
						refLivreIFac.Close();
						return;
					}
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
					if (_ficheDeLivre == null) {
						livreIFac.Close();
						return;
					}
					_ficheDeLivre.setFicheDeLivre(_actualFicheLivre);
					livreIFac.Close();
				}, null);
			} catch(Exception) {
				livreIFac.Close();
				MessageBox.Show(Resources.DashboardManager_loadFicheLivre_Erreur_lors_de_la_recuperation_des_informations_sur_le_livre_demande_);
			}

		}

		private void LoadFicheLivre(EmpruntBO pEmpruntBo) {
			CreateFicheLivre();
			if (_ficheDeLivre == null){
				return;
			}
			
			_ficheDeLivre.setFicheDeLivre(pEmpruntBo);

			//_actualFicheLivre = pEmpruntBo.Livre;
			/*var livreIFac = new LivreIFACClient();
			
			AsyncGuiFicheDeLivreSelectForClientById asyncExecute = livreIFac.SelectFicheLivreForClientByLivreId;
			try {
				asyncExecute.BeginInvoke(CGlobalCache.SessionManager.Token, CGlobalCache.SessionManager.Personne.Client.ClientId, pEmpruntBo.LivreId, xx => {
					var samplePersDelegate = (AsyncGuiFicheDeLivreSelectForClientById)((AsyncResult)xx).AsyncDelegate;
					_actualFicheLivre = samplePersDelegate.EndInvoke(xx);
					_ficheDeLivre.setFicheDeLivre(_actualFicheLivre);
					livreIFac.Close();
				}, null);
			} catch(Exception) {
				livreIFac.Close();
				MessageBox.Show(Resources.DashboardManager_loadFicheLivre_Erreur_lors_de_la_recuperation_des_informations_sur_le_livre_demande_);
			}*/

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
			Controls.Add(_ficheDeLivre);

			ResizeDynamicWindow(_ficheDeLivre);
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
			Controls.Add(_ficheDeLivreReservation);

			ResizeDynamicWindow(_ficheDeLivreReservation);
		}

		private void ResizeDynamicWindow(Control objControl){
			var t1 = new Transition(new TransitionType_EaseInEaseOut(1000));
			t1.add(this, "Width", _dashboardWidth + objControl.Width + 10);
			t1.add(lblBibliotheque, "Left", _lblBibliothequeLocationX + objControl.Width + 10);
			t1.add(lblBibliothequeTitle, "Left", _lblBibliothequeTitleLocationX + objControl.Width + 10);
			t1.add(lblDtLastVisite, "Left", _lblDtLastLocationX + objControl.Width + 10);
			t1.add(lblDtLastVisiteTitle, "Left", _lblDtLastVisiteTitleLocationX + objControl.Width + 10);

			t1.run();
		}

		private void CleanListBoxSelected(IDisposable actualListBox){
			foreach (var listBox2 in Controls.OfType<Panel>().SelectMany(panel => panel.Controls.OfType<ListBox>().Where(xx => xx.GetHashCode() != actualListBox.GetHashCode()))){
				listBox2.ClearSelected();
			}
		}

		private void CleanListBoxSelected(){
			foreach (var listBox2 in Controls.OfType<Panel>().SelectMany(panel => panel.Controls.OfType<ListBox>())){
				listBox2.ClearSelected();
			}
		}

		internal void AnnuleDemandeReservation(Action<DemandeAnnulationBO> callbackAction = null) {
			if (_demandeReservationSelected == null){
				return;
			}
			var demandeAnnulationIFac = new DemandeAnnulationIFACClient();
			AsyncGuiDemandeAnnulationInsertAnnulation sampleDemandeAnnulationInsertAnnulationDelegate = demandeAnnulationIFac.InsertDemandeAnnulationByClient;
			sampleDemandeAnnulationInsertAnnulationDelegate.BeginInvoke(CGlobalCache.SessionManager.Token, _demandeReservationSelected.ClientId, _demandeReservationSelected.DemandeReservationId, result =>{
				var sampleDemandeAnnulationDelegate = (AsyncGuiDemandeAnnulationInsertAnnulation)((AsyncResult)result).AsyncDelegate;
				var objDemandeAnnulation = sampleDemandeAnnulationDelegate.EndInvoke(result);
				demandeAnnulationIFac.Close();

				if (objDemandeAnnulation == null){
					MessageBox.Show("La demande n'a pas été exécutée");
				}

				CGlobalCache.LstNewDemandeReservationByClient.Remove(_demandeReservationSelected);
				_demandeReservationSelected.Valide = 0;
				CGlobalCache.LstOldDemandeReservationByClient.Add(_demandeReservationSelected);
				_demandeReservationSelected = null;

				if (CGlobalCache.LstDemandeReservationSelectAll != null){
					CGlobalCache.LstDemandeReservationSelectAll.Remove(_demandeReservationSelected);
					CGlobalCache.LstDemandeReservationSelectAll.Add(objDemandeAnnulation.DemandeReservation);
				}

				if (callbackAction == null){
					return;
				}

				callbackAction(objDemandeAnnulation);
			}, null);

		}

		private void DashboardManager_Load(object sender, EventArgs e) {
			_dashboardWidth = Width;
			_lblBibliothequeLocationX = lblBibliotheque.Location.X ;
			_lblBibliothequeTitleLocationX = lblBibliothequeTitle.Location.X;
			_lblDtLastLocationX = lblDtLastVisite.Location.X;
			_lblDtLastVisiteTitleLocationX = lblDtLastVisiteTitle.Location.X;

			CGlobalCache.ActualLstDemandeReservationEventHandlser += LoadReservation;
			CGlobalCache.LstNewDemandeReservationByClient.CollectionChanged += LstDemandeReservationByClient_CollectionChanged;
			CGlobalCache.LstOldDemandeReservationByClient.CollectionChanged += LstDemandeReservationByClient_CollectionChanged;

			LoadDecoration();

			LoadNouveaute();

			LoadDemandeReservation();

			LoadEmprunt();

			CleanListBoxSelected();
		}

		private void LoadReservation(object sender, EventArgs e) {
			LoadDemandeReservation();
		}

		void LstDemandeReservationByClient_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
			LoadReservation(sender, e);
		}

		private void LivreStatus_MouseDown(object sender, MouseEventArgs e) {
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

		private void LivreDemandeReservation_MouseDown(object sender, MouseEventArgs e) {
			var listBox = (ListBox)sender;

			listBox.SelectedIndex = listBox.IndexFromPoint(e.Location);
			if (listBox.SelectedIndex == -1) {
				return;
			}

			CleanListBoxSelected(listBox);

			if (e.Button == MouseButtons.Left){
				_demandeReservationSelected = (DemandeReservationBO)listBox.SelectedItem;
				LoadFicheLivre(_demandeReservationSelected);
			}
		}

		private void LivreEmprunt_MouseDown(object sender, MouseEventArgs e) {
			var listBox = (ListBox)sender;

			listBox.SelectedIndex = listBox.IndexFromPoint(e.Location);
			if (listBox.SelectedIndex == -1) {
				return;
			}

			CleanListBoxSelected(listBox);

			if (e.Button == MouseButtons.Left) {
				LoadFicheLivre((EmpruntBO)listBox.SelectedValue);
			}
		}

		private void totoToolStripMenuItem_Click(object sender, EventArgs e) {
			if (_livreSelected == null) {
				return;
			}
			InsertDemandeReservation((objDemandeReservation) => ConfirmReservation(objDemandeReservation, (objReservation) => {
				if (objReservation == null){
					MessageBox.Show(String.Format(@"Il n'y a pas de livre disponible pour l'instant. Votre demande: {0} est enregistrée et vous serez averti dès que possible", objDemandeReservation.DemandeReservationId));
					return;
				}
				MessageBox.Show(String.Format(@"Votre demande de réservation: {0} a été convertie en réservation, numéro: {1}", objDemandeReservation.DemandeReservationId, objReservation.ReservationId));
			}));
		}

		private void DashboardManager_FormClosing(object sender, FormClosingEventArgs e) {
			_frmMdi.ChildFormDecrement();
		}

	}
}
