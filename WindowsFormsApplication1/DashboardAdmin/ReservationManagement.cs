using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;
using WebsBO;
using WCF.Proxies;
using System.Runtime.Remoting.Messaging;
using System.Net;

namespace WindowsFormsApplication1.DashboardAdmin {
	public partial class ReservationManagement : UserControl {
		private readonly DashboardAdminManager _dashboardAdminManager;
		private bool _bCmpReservationInitialized;
		private List<DemandeReservationBO> _lstDemandeReservation;
		private DemandeReservationBO _demandeReservationSelected;
		private ReservationBO _reservationSelected;

		private delegate PersonneBO AsyncGuiSelectPersonneById(String token, Int32 pPersonneId);

		public ReservationManagement() {
			InitializeComponent();
		}

		public ReservationManagement(DashboardAdminManager dashboardAdminManager) : this() {
			_dashboardAdminManager = dashboardAdminManager;
		}

		#region private

		private void InitComponent() {
			FillCmbDemandeReservation();
			dataGridDemandeReservation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			CGlobalCache.LstDemandeReservationSelectAll.CollectionChanged += LstSelectAll_CollectionChanged;
			CGlobalCache.LstReservationSelectAll.CollectionChanged += LstSelectAll_CollectionChanged;
			CGlobalCache.ActualBibliothequeChangeEventHandler += ActualBibliothequeChange;
		}

		private void FillCmbDemandeReservation() {
			var lstDemandeReservationCombo = new List<DemandeReservationCombo>{
				new DemandeReservationCombo("", ""),
				new DemandeReservationCombo("Demandes en cours", RefreshDataGridWithDemandeReservationValid),
				//new DemandeReservationCombo("Demandes passée", "LstOldDemandeReservationByClient"),
				new DemandeReservationCombo("Réservations en cours", RefreshDataGridWithReservationValid),
				new DemandeReservationCombo("Réservations dépassées", RefreshDataGridWithReservationOutdated)
			};
			cmbReservationToogle.DataSource = null;
			cmbReservationToogle.DataSource = lstDemandeReservationCombo;
            cmbReservationToogle.DisplayMember = "Title";
			cmbReservationToogle.ValueMember = "LstDemandeReservation";
			_bCmpReservationInitialized = true;
		}

		private void cmbReservationToogle_SelectedIndexChanged(object sender, EventArgs e) {
			var objCmpBox = (ComboBox)sender;
			if (objCmpBox.SelectedIndex == -1 || !_bCmpReservationInitialized) {
				return;
			}

			if (objCmpBox.SelectedValue == null || objCmpBox.SelectedValue.ToString() == "") {
				return;
			}
			if (objCmpBox.SelectedValue.GetType() != typeof(Action)){
				try{
					_lstDemandeReservation = (List<DemandeReservationBO>)typeof(CGlobalCache).GetProperty(objCmpBox.SelectedValue.ToString()).GetValue(null, null);
					RefreshDataGridWithDemandeReservation();
				} catch(Exception){
					MessageBox.Show(Resources.ReservationManagement_cmbReservationToogle_SelectedIndexChanged_Erreur_lors_de_la_recuperation_des_reservations);
				}
			} else {
				((Action)objCmpBox.SelectedValue)();
			}
			RefreshField();
		}

		private void RefreshField() {
			foreach (var textBox in Controls.OfType<Panel>().SelectMany(panel => panel.Controls.OfType<TextBox>())){
				textBox.Text = "";
			}
			picBook.Image = null;
		}

		private void RefreshDataGridWithDemandeReservationValid(){
			//var lstReservation = CGlobalCache.LstDemandeReservationSelectAll;
			//var grpAllBibliotheque = lstReservation.Where(condition => condition.Valide == 1).GroupBy(xx => xx.Client.BibliothequeId).Select(group => new { bibliothequeId = group.Key, count = group.Count() });
			//var query = CGlobalCache.SessionManager.Personne.Administrateur.LstBibliotheque.Join(grpAllBibliotheque, myBiblio => myBiblio.BibliothequeId, allBiblio => allBiblio.bibliothequeId, (biblio1, biblio2) => new { biblioId = biblio1.BibliothequeId, count = biblio2.count });

			var lstDemandeReservation = CGlobalCache.LstDemandeReservationSelectAll;
			var lstDemandeReservationValideByBibliotheque = lstDemandeReservation.ToList().FindAll(xx => xx.Client.BibliothequeId.Equals(CGlobalCache.ActualBibliotheque.BibliothequeId)).Where(yy => yy.Valide.Equals(1)).ToList();

			var lstReservationLocal = CGlobalCache.LstReservationSelectAll.Where(xx => xx.DemandeReservation.Client.BibliothequeId == CGlobalCache.ActualBibliotheque.BibliothequeId).ToList();

			var lstDemandeReservationUnExpectedReservation = lstDemandeReservationValideByBibliotheque.Where(demandeReservationBo => lstReservationLocal.FirstOrDefault(xx => xx.DemandeReservationId == demandeReservationBo.DemandeReservationId) == null).ToList();

			var tmpClientDatas = new List<dynamic>();
			foreach (var objDemandeReservationByBibliotheque in lstDemandeReservationUnExpectedReservation){
				tmpClientDatas.Add(new {Demande = objDemandeReservationByBibliotheque.DemandeReservationId, Creation = objDemandeReservationByBibliotheque.CreatedAt.ToShortDateString(), ClientId = objDemandeReservationByBibliotheque.Personne.PersonneMatricule, Client=objDemandeReservationByBibliotheque.Personne.ToString(), Titre = objDemandeReservationByBibliotheque.RefLivre.ToString() });
			}

			dataGridDemandeReservation.DataSource = null;
			dataGridDemandeReservation.DataSource = tmpClientDatas;
			dataGridDemandeReservation.Refresh();
			dataGridDemandeReservation.AutoResizeColumns();

			dataGridDemandeReservation.ClearSelection();
			btnAnnuler.Enabled = false;
			btnEmprunter.Enabled = false;

		}

		private void RefreshDataGridWithReservationValid() {
			RefreshDataGridGeneric(result => result.Value != null && result.Value.State == "res" && result.Value.Livre.BibliothequeId == CGlobalCache.ActualBibliotheque.BibliothequeId && (DateTime.Now - result.Value.CreatedAt).Days <= 15);
		}

		private void RefreshDataGridWithReservationOutdated() {
			RefreshDataGridGeneric(result => result.Value != null && result.Value.State == "res" && result.Value.Livre.BibliothequeId == CGlobalCache.ActualBibliotheque.BibliothequeId && (DateTime.Now - result.Value.CreatedAt).Days > 15);
		}

		private void RefreshDataGridGeneric(Func<dynamic, bool> inPredicate) {
			if ( CGlobalCache.ActualBibliotheque == null) {
				return;
			}

			var lstReservation = CGlobalCache.LstReservationSelectAll.ToList();
			var maxReservation = lstReservation.GroupBy(xx => xx.LivreId).Select(dd => new{LivreId = dd.Key, ActionId = dd.Max(qq => qq.ActionId), ReservationId = dd.Max(rr => rr.ReservationId)});
			var lstReservationByBibliotheque = maxReservation.Select(dataInMaxActionResult => new { Key = dataInMaxActionResult.ReservationId, Value = CGlobalCache.LstEmpruntSelectAll.ToList().Find(xx => xx.ActionId == dataInMaxActionResult.ActionId && xx.LivreId == dataInMaxActionResult.LivreId)}).Where(inPredicate).ToList();
			
			var tmpClientDatas = new List<dynamic>();
			foreach (var objReservationByBibliotheque in lstReservationByBibliotheque){
				tmpClientDatas.Add(new {Reservation = objReservationByBibliotheque.Key, Creation = objReservationByBibliotheque.Value.CreatedAt.ToShortDateString(), ClientId = objReservationByBibliotheque.Value.Personne.PersonneMatricule, Client=objReservationByBibliotheque.Value.Personne.ToString(), Livre = objReservationByBibliotheque.Value.Livre.InternalReference, Titre = objReservationByBibliotheque.Value.Livre.ToString() });
			}

			dataGridDemandeReservation.DataSource = null;
			dataGridDemandeReservation.DataSource = tmpClientDatas;
			dataGridDemandeReservation.Refresh();
			dataGridDemandeReservation.AutoResizeColumns();

			dataGridDemandeReservation.ClearSelection();
			btnAnnuler.Enabled = false;
			btnEmprunter.Enabled = false;
		}

		private void RefreshDataGridWithDemandeReservation() {
			if (_lstDemandeReservation == null || CGlobalCache.ActualBibliotheque == null) {
				return;
			}

			var lstDemandeReservation = _lstDemandeReservation.FindAll(xx => xx.Client.BibliothequeId == CGlobalCache.ActualBibliotheque.BibliothequeId && xx.Valide == 1);
			var lstDemandeReservationSource = lstDemandeReservation.Select(selection => new { Id = selection.DemandeReservationId, selection.Client.ClientId, selection.RefLivre.Titre, Date = selection.CreatedAt.ToShortDateString() }).ToList();
			
			dataGridDemandeReservation.DataSource = null;
			dataGridDemandeReservation.DataSource = lstDemandeReservationSource;
			dataGridDemandeReservation.Refresh();
			dataGridDemandeReservation.AutoResizeColumns();

			dataGridDemandeReservation.ClearSelection();
			btnAnnuler.Enabled = false;
			btnEmprunter.Enabled = false;
		}

		private void ShowDetailSelection() {
			if (_demandeReservationSelected == null && _reservationSelected == null) {
				return;
			}

			if (_demandeReservationSelected != null){
				ShowDetailSelectionFinal(new{
					_demandeReservationSelected.Client,
					_demandeReservationSelected.Personne.PersonneMatricule,
					isAdministrateur = _demandeReservationSelected.Personne.Administrateur != null,
					_demandeReservationSelected.Client.Bibliotheque.BibliothequeName,
					_demandeReservationSelected.RefLivre.Titre,
					ReservationId = _demandeReservationSelected.DemandeReservationId,
					_demandeReservationSelected.CreatedAt,
					_demandeReservationSelected.RefLivre.ImageUrl
				});
			}
			if (_reservationSelected != null){
				ShowDetailSelectionFinal(new{
					_reservationSelected.DemandeReservation.Client,
					_reservationSelected.DemandeReservation.Personne.PersonneMatricule,
					isAdministrateur = _reservationSelected.DemandeReservation.Personne.Administrateur != null,
					_reservationSelected.DemandeReservation.Client.Bibliotheque.BibliothequeName,
					_reservationSelected.DemandeReservation.RefLivre.Titre,
					_reservationSelected.ReservationId,
					_reservationSelected.CreatedAt,
					_reservationSelected.DemandeReservation.RefLivre.ImageUrl
				});
			}

		}

		private void ShowDetailSelectionFinal(dynamic selection){
			GetPersonne(selection.Client);
			txtClientId.Text = selection.PersonneMatricule.ToString(CultureInfo.InvariantCulture);
			cbAdministrateur.Checked = (selection.isAdministrateur);
			lblBibliotheque.Text = selection.BibliothequeName;
			txtRefLivreTitre.Text = selection.Titre;
			txtReservationDate.Text = selection.ReservationId.ToString(CultureInfo.InvariantCulture);
			var diffTimeSpan = DateTime.Now - selection.CreatedAt;
			txtReservationDepassement.Text = diffTimeSpan.Days.ToString(CultureInfo.InvariantCulture);
			
			Action<String> getImage = imageUrl => { 
				// Create a web request to the URL for the picture
				var webRequest = WebRequest.Create(imageUrl);
				// Execute the request synchronuously
				var webResponse = (HttpWebResponse)webRequest.GetResponse();

				// Create an image from the stream returned by the web request
				// ReSharper disable AssignNullToNotNullAttribute
				picBook.Image = new Bitmap(webResponse.GetResponseStream());
				// ReSharper restore AssignNullToNotNullAttribute
			};

			getImage(selection.ImageUrl);
		}

		private void GetPersonne(ClientBO pClient) {
			var personneIFac = new PersonneIFACClient();
			
			AsyncGuiSelectPersonneById asyncExecute = personneIFac.SelectById;
			try {
				asyncExecute.BeginInvoke(CGlobalCache.SessionManager.Token, pClient.ClientId, xx => {
					var samplePersDelegate = (AsyncGuiSelectPersonneById)((AsyncResult)xx).AsyncDelegate;
					var objPersonne = samplePersDelegate.EndInvoke(xx);
					if (objPersonne != null) {
						txtClientName.Text = objPersonne.ToString();
						cbAdministrateur.Checked = (objPersonne.Administrateur != null);
					}
					personneIFac.Close();
				}, null);
			} catch(Exception) {
				personneIFac.Close();
				MessageBox.Show(Resources.ReservationManagement_GetPersonne_Erreur_lors_de_la_recuperation_des_informations_sur_le_livre_demande_);
			}
		}

		#endregion private

		#region callback

		private void ReservationManagement_Load(object sender, EventArgs e) {
			InitComponent();
		}
		
		private void ActualBibliothequeChange(object value, EventArgs e) {
			//RefreshDataGridWithDemandeReservation();
			cmbReservationToogle_SelectedIndexChanged(cmbReservationToogle, new EventArgs());
		}

		void LstSelectAll_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
			cmbReservationToogle_SelectedIndexChanged(cmbReservationToogle, new EventArgs());
		}

		private void dataGridDemandeReservation_CellClick(object sender, DataGridViewCellEventArgs e) {
			if (e.RowIndex < 0) {
				return;
			}
			var objDataGridView = (DataGridView)sender;
			objDataGridView.Rows[e.RowIndex].Selected = true;

			if (objDataGridView.Columns[0].Name.Equals("Demande")){
				_reservationSelected = null;
				_demandeReservationSelected = CGlobalCache.LstDemandeReservationSelectAll.FirstOrDefault(xx => xx.DemandeReservationId.Equals(objDataGridView.Rows[e.RowIndex].Cells[0].Value));
				btnEmprunter.Enabled = false;
			}
			if (objDataGridView.Columns[0].Name.Equals("Reservation")){
				_demandeReservationSelected = null;
				_reservationSelected = CGlobalCache.LstReservationSelectAll.ToList().Find(xx => xx.ReservationId.Equals(objDataGridView.Rows[e.RowIndex].Cells[0].Value));
				btnEmprunter.Enabled = true;
			}
			btnAnnuler.Enabled = true;
			ShowDetailSelection();
		}

		private void dataGridDemandeReservation_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
			dataGridDemandeReservation_CellClick(sender, e);
		}

		private void btnEmprunter_Click(object sender, EventArgs e) {
			//throw new NotImplementedException();
			_dashboardAdminManager.SwitchToEmpruntManagement(_reservationSelected);
		}

		private void btnAnnuler_Click(object sender, EventArgs e){
			var bResult = false;
			if (_demandeReservationSelected != null){
				var result = _dashboardAdminManager.SaveAnnuleReservation(CGlobalCache.SessionManager.Personne.Administrateur, _demandeReservationSelected);
				if (result != null){
					CGlobalCache.LstDemandeReservationSelectAll.Remove(_demandeReservationSelected);
					bResult = true;
				}
			}
			if (_reservationSelected != null){
				var result = _dashboardAdminManager.SaveAnnuleReservation(CGlobalCache.SessionManager.Personne.Administrateur, _reservationSelected);
				if (result != null){
					CGlobalCache.LstReservationSelectAll.Remove(_reservationSelected);
					bResult = true;
				}
			}
			if (!bResult){
				MessageBox.Show(Resources.ReservationManagement_btnAnnuler_Click_Erreur_lors_de_votre_demande_d_annulation);
			}
		}

		#endregion callback
	}
}
