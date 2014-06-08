using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;
using WCF.Proxies;
using WebsBO;
using System.Runtime.Remoting.Messaging;
using System.Net;

namespace WindowsFormsApplication1.DashboardAdmin {
	public partial class EmpruntManagement : UserControl {
		private readonly DashboardAdminManager _dashboardAdminManager;
		private readonly ReservationBO _objReservation;
		private List<PersonneBO> _lstPersonneField;
		private List<ReservationBO> _lstReservationField;

		private bool _bCmbClientFieldToogle;
		private List<LivreBO> _lstLivreField;
		private bool _bTooMuchBook;
		
		private delegate List<PersonneBO> AsyncGuiSelectListPersonne(String token, String pPersonneInfo);
		private delegate List<LivreBO> AsyncGuiSelectListLivre(String token, String pLivreInfo, Int32 pBibliothequeId);
		private delegate List<ReservationBO> AsyncGuiSelectReservationByClientId(String token, Int32 pClientId); 
		private delegate List<ReservationBO> AsyncGuiSelectReservationByInfo(String token, String pInfo); 

		

		public EmpruntManagement() {
			InitializeComponent();
		}

		public EmpruntManagement(DashboardAdminManager dashboardAdminManager) : this() {
			_dashboardAdminManager = dashboardAdminManager;
		}

		public EmpruntManagement(DashboardAdminManager dashboardAdminManager, ReservationBO objReservation) : this(dashboardAdminManager) {
			_objReservation = objReservation;
		}

		#region private

		private void InitComponent() {
			txtLivreField.Enabled = CGlobalCache.ActualBibliotheque != null;
			btnLivreGo.Enabled = CGlobalCache.ActualBibliotheque != null;
			CGlobalCache.ActualBibliothequeChangeEventHandler += ActualBibliothequeChange;
			if (_objReservation != null) {
				fillReservationControllers();
			}
		}

		private void FillCombobox() {
			throw new NotImplementedException();
		}

		private void fillReservationControllers() {
			throw new NotImplementedException();
		}

		private void SearchClientField() {
			var personneIFac = new PersonneIFACClient();
			
			AsyncGuiSelectListPersonne asyncExecute = personneIFac.SelectByInfo;
			try {
				asyncExecute.BeginInvoke(CGlobalCache.SessionManager.Token, txtClientField.Text, xx => {
					var samplePersDelegate = (AsyncGuiSelectListPersonne)((AsyncResult)xx).AsyncDelegate;
					_lstPersonneField = samplePersDelegate.EndInvoke(xx);
					if (_lstPersonneField != null && _lstPersonneField.Any()) {
						_bCmbClientFieldToogle = false;
						var tmpClientDatas = _lstPersonneField.Select(yy => new { Key = yy.PersonneMatricule + ": " + yy.ToString(), Value = yy }).ToList();
						tmpClientDatas.Insert(0, new { Key = "", Value = null as PersonneBO });
						cmbClientField.DataSource = tmpClientDatas;
						cmbClientField.ValueMember = "Value";
						cmbClientField.DisplayMember = "Key";
						cmbClientField.Enabled = true;
						_bCmbClientFieldToogle = true;
					}
					personneIFac.Close();
				}, null);
			} catch(Exception) {
				personneIFac.Close();
				MessageBox.Show(Resources.EmpruntManagement_SearchLivreField_Erreur_lors_de_la_recuperation_des_informations_sur_le_livre_demande_);
			}
		}

		private void SearchReservationField(PersonneBO objPersonne) {
			var reservationIFac = new ReservationIFACClient();
			AsyncGuiSelectReservationByClientId asyncExecute = reservationIFac.SelectEnCoursValidByClientId;
			try{
				asyncExecute.BeginInvoke(CGlobalCache.SessionManager.Token, objPersonne.PersonneId, result =>{
					var sampleReservationDelegate = (AsyncGuiSelectReservationByClientId)((AsyncResult)result).AsyncDelegate;
					_lstReservationField = sampleReservationDelegate.EndInvoke(result);
					if (_lstReservationField.Count(xx => xx.Emprunt.Livre.BibliothequeId == CGlobalCache.ActualBibliotheque.BibliothequeId) > 0) {
						_bCmbClientFieldToogle = false;
						var tmpLivreDatas = _lstReservationField.Select(yy => new { Key = yy.ReservationId + ": " + yy.Emprunt.Livre.ToString(), Value = yy }).ToList();
						tmpLivreDatas.Insert(0, new { Key = "", Value = null as ReservationBO });
						cmbReservationField.DataSource = tmpLivreDatas;
						cmbReservationField.ValueMember = "Value";
						cmbReservationField.DisplayMember = "Key";
						cmbReservationField.Enabled = true;
						_bCmbClientFieldToogle = true;
					} else {
						cmbReservationField.DataSource = null;
						cmbReservationField.Enabled = false;
					}
				}, null);
			} catch(Exception ex){
				reservationIFac.Close();
				MessageBox.Show(Resources.EmpruntManagement_SearchReservationField_Erreur_lors_de_la_recuperation_des_informations_sur_la_reservation_demandee);
			}
		}

		private void SearchReservationField(String pInfo){
			var reservationIFac = new ReservationIFACClient();
			AsyncGuiSelectReservationByInfo asyncExecute = reservationIFac.SelectEnCoursValidByInfo;
			try{
				asyncExecute.BeginInvoke(CGlobalCache.SessionManager.Token, pInfo, result =>{
					var sampleReservationDelegate = (AsyncGuiSelectReservationByInfo)((AsyncResult)result).AsyncDelegate;
					_lstReservationField = sampleReservationDelegate.EndInvoke(result);
					if (_lstReservationField.Count > 0) {
						_bCmbClientFieldToogle = false;
						var tmpLivreDatas = _lstReservationField.Select(yy => new { Key = yy.ReservationId + ": " + yy.Emprunt.Livre.ToString(), Value = yy }).ToList();
						tmpLivreDatas.Insert(0, new { Key = "", Value = null as ReservationBO });
						cmbReservationField.DataSource = tmpLivreDatas;
						cmbReservationField.ValueMember = "Value";
						cmbReservationField.DisplayMember = "Key";
						cmbReservationField.Enabled = true;
						_bCmbClientFieldToogle = true;
					} else {
						cmbReservationField.DataSource = null;
						cmbReservationField.Enabled = false;
					}
				}, null);
			} catch(Exception ex){
				reservationIFac.Close();
				MessageBox.Show(Resources.EmpruntManagement_SearchReservationField_Erreur_lors_de_la_recuperation_des_informations_sur_la_reservation_demandee);
			}

		}

		private void SearchLivreField() {
			var livreIFac = new LivreIFACClient();
			
			AsyncGuiSelectListLivre asyncExecute = livreIFac.SelectByInfo;
			try {
				asyncExecute.BeginInvoke(CGlobalCache.SessionManager.Token, txtLivreField.Text, CGlobalCache.ActualBibliotheque.BibliothequeId, result => {
					var samplePersDelegate = (AsyncGuiSelectListLivre)((AsyncResult)result).AsyncDelegate;
					_lstLivreField = samplePersDelegate.EndInvoke(result);
					if (_lstLivreField.Count > 0) {
						_bCmbClientFieldToogle = false;
						var tmpLivreDatas = _lstLivreField.Select(yy => new { Key = yy.InternalReference + ": " + yy.ToString(), Value = yy }).ToList();
						tmpLivreDatas.Insert(0, new { Key = "", Value = null as LivreBO });
						cmbLivreField.DataSource = tmpLivreDatas;
						cmbLivreField.ValueMember = "Value";
						cmbLivreField.DisplayMember = "Key";
						cmbLivreField.Enabled = true;
						_bCmbClientFieldToogle = true;
					} else {
						cmbLivreField.DataSource = null;
						cmbLivreField.Enabled = false;
					}
					livreIFac.Close();
				}, null);
			} catch(Exception) {
				livreIFac.Close();
				MessageBox.Show(Resources.EmpruntManagement_SearchLivreField_Erreur_lors_de_la_recuperation_des_informations_sur_le_livre_demande_);
			}
		}
		
		private void FillReservation() {
			if (cmbClientField.SelectedValue == null) {
				return;
			}
			/*
			var objSelectedPersonne = (PersonneBO)cmbClientField.SelectedValue;
			var lstDemandeReservation = CGlobalCache.LstNewDemandeReservationByClient.FindAll(xx => xx.ClientId == objSelectedPersonne.PersonneId).ToList();
			if (lstDemandeReservation.Any()) {
				_bCmbClientFieldToogle = false;
				cmbReservationField.DataSource = null;
				var tmpDemandeReservationDatas = lstDemandeReservation.Select(xx => new { Key = "Id: " + xx.DemandeReservationId + " Date: " + xx.CreatedAt.ToShortDateString(), Value = xx }).ToList();
				tmpDemandeReservationDatas.Insert(0, new { Key = "", Value = null as DemandeReservationBO });
				cmbReservationField.DataSource = tmpDemandeReservationDatas;
				cmbReservationField.DisplayMember = "Key";
				cmbReservationField.ValueMember = "Value";
				cmbReservationField.Enabled = (CGlobalCache.ActualBibliotheque != null);

				_bCmbClientFieldToogle = true;
			} else { 
				cmbReservationField.DataSource = null;
				cmbReservationField.Enabled = false;
			}*/
		}

		private void FillLivre() {
			if (cmbReservationField.SelectedValue == null) {
				return;
			}
			
			var objSelectedReservation = (ReservationBO)cmbReservationField.SelectedValue;
			//List<DemandeReservationBO> lstDemandeReservation = CGlobalCache.LstNewDemandeReservationByClient.FindAll(xx => xx.ClientId == objSelectedDemandeReservation.PersonneId).ToList();
			if (objSelectedReservation != null) {
				_bCmbClientFieldToogle = false;
				cmbLivreField.DataSource = null;
				//var tmpLivreDatas = lstDemandeReservation.Select(xx => new { Key = "Id: " + xx.DemandeReservationId + " Date: " + xx.CreatedAt.ToShortDateString(), Value = xx }).ToList();
				//tmpLivreDatas.Insert(0, new { Key = "", Value = null as DemandeReservationBO });
				cmbLivreField.DisplayMember = "Key";
				cmbLivreField.ValueMember = "Value";
				_bCmbClientFieldToogle = true;
				cmbLivreField.DataSource = new List<dynamic>{new { Key = objSelectedReservation.DemandeReservation.RefLivre.Titre, Value = objSelectedReservation.Emprunt.Livre }};
				cmbLivreField.Enabled = true;
			} else { 
				cmbLivreField.DataSource = null;
				cmbLivreField.Enabled = false;
			}
		}

		private void FillRecapitulatif() {
			var bEnableValidButton = true;
			if (cmbLivreField.SelectedValue != null) {
				FillRecapitulatifLivreField(cmbLivreField.SelectedValue);
			} else {
				bEnableValidButton = false;
			}

			if (cmbClientField.SelectedValue != null) {
				var objPersonne = (PersonneBO)cmbClientField.SelectedValue;
				txtClientName.Text = objPersonne.ToString();
				txtClientId.Text = objPersonne.PersonneId.ToString(CultureInfo.InvariantCulture);
			} else {
				bEnableValidButton = false;
			}

			if (cmbReservationField.SelectedValue != null) {
				var objReservation = (ReservationBO)cmbReservationField.SelectedValue;
				txtReservationDate.Text = objReservation.ReservationId.ToString(CultureInfo.InvariantCulture);
				var diffTime = DateTime.Now - objReservation.CreatedAt;
				txtReservationDepassement.Text = diffTime.Days.ToString(CultureInfo.InvariantCulture);

			}

			btnValider.Enabled = bEnableValidButton;

		}

		private void AlertToMuchBook(PersonneBO pPersonneBo){
			//var empruntNumber = CGlobalCache.LstEmpruntSelectAll.FindAll(xx => xx.ClientId == pPersonneBo.PersonneId).GroupBy(yy => yy.LivreId).Select(zz => new{zz.Key, value = zz.Max(q => q.State)}).Count(gg => gg.value == "emp");
			if (pPersonneBo == null) {
				return;
			}
			var empruntNumber = CGlobalCache.LstEmpruntSelectAll.FindAll(xx => xx.ClientId == pPersonneBo.PersonneId);
			var maxActionId = empruntNumber.GroupBy(xx => xx.LivreId).Select(dd => new{LivreId = dd.Key, ActionId = dd.Max(qq => qq.ActionId)});
			var toCount = maxActionId.Select(dataInMaxActionResult => CGlobalCache.LstEmpruntSelectAll.Find(xx => xx.ActionId == dataInMaxActionResult.ActionId && xx.LivreId == dataInMaxActionResult.LivreId)).Where(result => result != null && result.State == "emp").ToList();
			
			lblInfo.Visible = true;
			lblInfo.Text = String.Format(@"Nombre de livre emprunté total {0}", toCount.Count());
			//_bTooMuchBook = (empruntNumber >= 3);
		}

		private void FillRecapitulatifLivreField(object pObj) {
			RefLivreBO objRefLivre;
			if (pObj.GetType() == typeof(RefLivreBO)) {
				objRefLivre = (RefLivreBO)pObj;
				txtLivreReference.Visible = false;
				lblLivreReference.Visible = false;
			} else if (pObj.GetType() == typeof(LivreBO)) {
				objRefLivre = ((LivreBO)pObj).RefLivre;
				txtLivreReference.Text = ((LivreBO)pObj).InternalReference;
				txtLivreReference.Visible = true;
				lblLivreReference.Visible = true;
			} else {
				return;
			}
			txtRefLivreTitre.Text = objRefLivre.Titre;
			
			Action<String> getImage = imageUrl => { 
				// Create a web request to the URL for the picture
				var webRequest = WebRequest.Create(imageUrl);
				// Execute the request synchronuously
				var webResponse = (HttpWebResponse)webRequest.GetResponse();

				// Create an image from the stream returned by the web request
				picBook.Image = new Bitmap(webResponse.GetResponseStream());
			};

				getImage(objRefLivre.ImageUrl);
		}
		
		#endregion private

		#region callback

		private void EmpruntManagement_Load(object sender, EventArgs e) {
			lblAlert.Visible = false;
			InitComponent();
		}

		private void txtClientField_KeyDown(object sender, KeyEventArgs e) {
			lblAlert.Visible = false;
			if (e.KeyCode == Keys.Enter) {
				SearchClientField();
			}
		}

		private void btnClientGo_Click(object sender, EventArgs e) {
			lblAlert.Visible = false;
			SearchClientField();
		}

		private void cmbClientField_SelectedValueChanged(object sender, EventArgs e){
			lblAlert.Visible = false;
			if (!_bCmbClientFieldToogle){
				return;
			}
			var objPersonne = (PersonneBO)((ComboBox)sender).SelectedValue;
			SearchReservationField(objPersonne);
			FillRecapitulatif();
			AlertToMuchBook(objPersonne);
		}

		private void txtReservationField_KeyDown(object sender, KeyEventArgs e) {
			lblAlert.Visible = false;
			if (e.KeyCode == Keys.Enter) {
				SearchReservationField(txtReservationField.Text);
			}
		}

		private void btnReservationGo_Click(object sender, EventArgs e) {
			lblAlert.Visible = false;
				SearchReservationField(txtReservationField.Text);
		}

		private void cmbReservationField_SelectedValueChanged(object sender, EventArgs e) {
			lblAlert.Visible = false;
			if (_bCmbClientFieldToogle) {
				FillLivre();
			}
		}

		private void txtLivreField_KeyDown(object sender, KeyEventArgs e) {
			lblAlert.Visible = false;
			if (e.KeyCode == Keys.Enter) {
				SearchLivreField();
			}
		}

		private void btnLivreGo_Click(object sender, EventArgs e) {
			lblAlert.Visible = false;
				SearchLivreField();
		}

		private void cmbLivreField_SelectedValueChanged(object sender, EventArgs e) {
			lblAlert.Visible = false;
			if (_bCmbClientFieldToogle) {
				FillRecapitulatif();
			}
		}

		private void btnValider_Click(object sender, EventArgs e) {
			if (cmbClientField.SelectedValue == null || cmbLivreField.SelectedValue == null) {
				MessageBox.Show(Resources.EmpruntManagement_btnValider_Click_Tous_les_champs_ne_sont_pas_remplis_);
				return;
			}
			if (_bTooMuchBook){
				MessageBox.Show(Resources.EmpruntManagement_btnValider_Click_Vous_avez_trop_de_livre_empruntes__Seul_3_maximum_sont_authorizes);
				return;
			}
			var result = _dashboardAdminManager.SaveEmprunt(CGlobalCache.SessionManager.Personne.Administrateur, (PersonneBO)cmbClientField.SelectedValue, (LivreBO)cmbLivreField.SelectedValue, (ReservationBO)cmbReservationField.SelectedValue);
			if (result == null){
				MessageBox.Show(Resources.EmpruntManagement_btnValider_Click_Echec_lors_de_l_enregistrement_de_l_emprunt);
				return;
			}
			lblAlert.Visible = true;
			lblAlert.Text = String.Format(@"Emprunt enregistré ref: {0} !", result.EmpruntId);

			CGlobalCache.ReloadSelectAllEmpruntCache(() => {
				var selectedValue = cmbClientField.SelectedValue;
				if (selectedValue == null){
					return;
				}
				AlertToMuchBook((PersonneBO)selectedValue);
			});
			_bCmbClientFieldToogle = false;
			lblInfo.Visible = true;
			btnValider.Enabled = false;
			cmbLivreField.DataSource = null;
			cmbLivreField.Enabled = false;

		}
		
		private void ActualBibliothequeChange(object value, EventArgs e) {
			var objBibliotheque = (BibliothequeBO) value;
			txtLivreField.Enabled = (objBibliotheque != null);
			btnLivreGo.Enabled = (objBibliotheque != null);
			txtReservationField.Enabled = (objBibliotheque != null);
			btnReservationGo.Enabled = (objBibliotheque != null);
			if (txtLivreField.Text.Trim() == ""){
				cmbLivreField.DataSource = null;
				cmbLivreField.Enabled = false;
				return;
			}
			SearchLivreField();
		}

		#endregion callback

	}
}
