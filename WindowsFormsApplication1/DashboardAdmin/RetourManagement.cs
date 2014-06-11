using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;
using WCF.Proxies;
using WebsBO;

namespace WindowsFormsApplication1.DashboardAdmin {
	public partial class RetourManagement : UserControl {
		private bool _bCmbClientFieldToogle;
		private List<PersonneBO> _lstPersonneField;
		private readonly DashboardAdminManager _dashboardAdminManager;

		private delegate List<PersonneBO> AsyncGuiSelectListPersonne(String token, String pPersonneInfo);
		private delegate PersonneBO AsyncGuiSelectPersonneFromEmpruntId(String token, Int32 pEmpruntId);

		public RetourManagement() {
			InitializeComponent();
		}

		public RetourManagement(DashboardAdminManager dashboardAdminManager) : this() {
			_dashboardAdminManager = dashboardAdminManager;
		}

		private void InitComponent(){
			txtLivreField.Enabled = CGlobalCache.ActualBibliotheque != null;
			btnLivreGo.Enabled = CGlobalCache.ActualBibliotheque != null;
			CGlobalCache.ActualBibliothequeChangeEventHandler += ActualBibliothequeChange;
		}

		private void SearchClientField(){
			lblAlert.Enabled = false;
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

		private void SearchLivreField(){
			lblAlert.Enabled = false;
			var txtField = txtLivreField.Text;
			var empruntNumber = CGlobalCache.LstEmpruntSelectAll.ToList().FindAll(xx => xx.Livre.RefLivre.Titre.Contains(txtField) || xx.Livre.InternalReference.Contains(txtField));
			var maxActionId = empruntNumber.GroupBy(xx => xx.LivreId).Select(dd => new{LivreId = dd.Key, ActionId = dd.Max(qq => qq.ActionId)});
			var clientEmprunt = maxActionId.Select(dataInMaxActionResult => CGlobalCache.LstEmpruntSelectAll.ToList().Find(xx => xx.ActionId == dataInMaxActionResult.ActionId && xx.LivreId == dataInMaxActionResult.LivreId)).Where(result => result != null && result.State == "emp" && result.Livre.BibliothequeId == CGlobalCache.ActualBibliotheque.BibliothequeId).ToList();
			var lstResult = clientEmprunt.Select(empruntBo => empruntBo.Livre).ToList();
			if (!lstResult.Any()){
				cmbLivreField.Enabled = false;
				cmbLivreField.DataSource = null;
				return;
			}
			cmbLivreField.Enabled = true;
			_bCmbClientFieldToogle = false;
			var tmpClientDatas = lstResult.Select(yy => new { Key = yy.InternalReference + ": " + yy.ToString(), Value = yy }).ToList();
			tmpClientDatas.Insert(0, new { Key = "", Value = null as LivreBO });
			cmbLivreField.DataSource = tmpClientDatas;
			cmbLivreField.ValueMember = "Value";
			cmbLivreField.DisplayMember = "Key";
			_bCmbClientFieldToogle = true;
		}

		private void FillCmpLivreField(PersonneBO pPersonneBo){
			if (pPersonneBo == null || CGlobalCache.ActualBibliotheque == null){
				return;
			}
			var empruntNumber = CGlobalCache.LstEmpruntSelectAll.ToList().FindAll(xx => xx.ClientId == pPersonneBo.PersonneId);
			var maxActionId = empruntNumber.GroupBy(xx => xx.LivreId).Select(dd => new{LivreId = dd.Key, ActionId = dd.Max(qq => qq.ActionId)});
			var clientEmprunt = maxActionId.Select(dataInMaxActionResult => CGlobalCache.LstEmpruntSelectAll.ToList().Find(xx => xx.ActionId == dataInMaxActionResult.ActionId && xx.LivreId == dataInMaxActionResult.LivreId)).Where(result => result != null && result.State == "emp" && result.Livre.BibliothequeId == CGlobalCache.ActualBibliotheque.BibliothequeId).ToList();
			var lstResult = clientEmprunt.Select(empruntBo => empruntBo.Livre).ToList();
			if (!lstResult.Any()){
				cmbLivreField.Enabled = false;
				cmbLivreField.DataSource = null;
				return;
			}
			cmbLivreField.Enabled = true;
			_bCmbClientFieldToogle = false;
			var tmpClientDatas = lstResult.Select(yy => new { Key = yy.InternalReference + ": " + yy.ToString(), Value = yy }).ToList();
			tmpClientDatas.Insert(0, new { Key = "", Value = null as LivreBO });
			cmbLivreField.DataSource = tmpClientDatas;
			cmbLivreField.ValueMember = "Value";
			cmbLivreField.DisplayMember = "Key";
			_bCmbClientFieldToogle = true;

		}

		private void AlertToMuchBook(PersonneBO pPersonneBo){
			if (pPersonneBo == null){
				return;
			}
			//var empruntNumber = CGlobalCache.LstEmpruntSelectAll.FindAll(xx => xx.ClientId == pPersonneBo.PersonneId).GroupBy(yy => yy.LivreId).Select(zz => new{zz.Key, value = zz.Max(q => q.State)}).Count(gg => gg.value == "emp");
			var empruntNumber = CGlobalCache.LstEmpruntSelectAll.ToList().FindAll(xx => xx.ClientId == pPersonneBo.PersonneId);
			var maxActionId = empruntNumber.GroupBy(xx => xx.LivreId).Select(dd => new{LivreId = dd.Key, ActionId = dd.Max(qq => qq.ActionId)});
			var toCount = maxActionId.Select(dataInMaxActionResult => CGlobalCache.LstEmpruntSelectAll.ToList().Find(xx => xx.ActionId == dataInMaxActionResult.ActionId && xx.LivreId == dataInMaxActionResult.LivreId)).Where(result => result != null && result.State == "emp").ToList();
			
			lblInfo.Visible = true;
			lblInfo.Text = String.Format(@"Nombre de livre emprunté total {0}", toCount.Count());
			//_bTooMuchBook = (empruntNumber >= 3);
		}

		private void FillRecapitulatifClient() {
			var bEnableValidButton = true;

			if (cmbClientField.SelectedValue != null) {
				var objPersonne = (PersonneBO)cmbClientField.SelectedValue;
				txtClientName.Text = objPersonne.ToString();
				txtClientId.Text = objPersonne.PersonneId.ToString(CultureInfo.InvariantCulture);
				cbAdministrateur.Checked = (objPersonne.Administrateur != null);
			} else {
				bEnableValidButton = false;
				SelectPersonneFromEmpruntLivreId((LivreBO)cmbLivreField.SelectedValue);
			}

			btnValider.Enabled = bEnableValidButton;

		}

		private void FillRecapitulatifLivre() {
			var bEnableValidButton = true;
			if (cmbLivreField.SelectedValue != null) {
				FillRecapitulatifLivreField(cmbLivreField.SelectedValue);
				SelectPersonneFromEmpruntLivreId((LivreBO)cmbLivreField.SelectedValue);
			} else {
				bEnableValidButton = false;
			}

			btnValider.Enabled = bEnableValidButton;

		}

		private void SelectPersonneFromEmpruntLivreId(LivreBO pLivreBo){
			var empruntNumber = CGlobalCache.LstEmpruntSelectAll.ToList().FindAll(xx => xx.LivreId == pLivreBo.LivreId);
			var maxActionId = empruntNumber.GroupBy(xx => xx.LivreId).Select(dd => new{LivreId = dd.Key, ActionId = dd.Max(qq => qq.ActionId)});
			var lstObjEmprunt = maxActionId.Select(dataInMaxActionResult => CGlobalCache.LstEmpruntSelectAll.ToList().Find(xx => xx.ActionId == dataInMaxActionResult.ActionId && xx.LivreId == dataInMaxActionResult.LivreId)).Where(result => result != null && result.State == "emp" && result.Livre.BibliothequeId == CGlobalCache.ActualBibliotheque.BibliothequeId).ToList();
			
			if (!lstObjEmprunt.Any()){
				return;
			}

			var objEmprunt = lstObjEmprunt.Last(xx => xx.LivreId == pLivreBo.LivreId);
			if (objEmprunt == null){
				return;
			}
			var personneIFac = new PersonneIFACClient();
			
			AsyncGuiSelectPersonneFromEmpruntId asyncExecute = personneIFac.SelectByLivreEmpruntId;
			try {
				asyncExecute.BeginInvoke(CGlobalCache.SessionManager.Token, objEmprunt.EmpruntId, result => {
					var samplePersDelegate = (AsyncGuiSelectPersonneFromEmpruntId)((AsyncResult)result).AsyncDelegate;
					var objPersonneField = samplePersDelegate.EndInvoke(result);
					if (objPersonneField != null && cmbClientField.SelectedValue!= null && objPersonneField.PersonneId != ((PersonneBO)cmbClientField.SelectedValue).PersonneId) {
						_bCmbClientFieldToogle = false;
						var lstPersonne = new List<PersonneBO> {objPersonneField};
						var tmpClientDatas = lstPersonne.Select(yy => new { Key = yy.PersonneMatricule + ": " + yy.ToString(), Value = yy }).ToList();
						//tmpClientDatas.Insert(0, new { Key = "", Value = null as PersonneBO });
						cmbClientField.DataSource = tmpClientDatas;
						cmbClientField.ValueMember = "Value";
						cmbClientField.DisplayMember = "Key";
						cmbClientField.Enabled = true;
						_bCmbClientFieldToogle = true;
						txtClientName.Text = objPersonneField.ToString();
						txtClientId.Text = objPersonneField.PersonneId.ToString(CultureInfo.InvariantCulture);
						cbAdministrateur.Checked = (objPersonneField.Administrateur != null);
					}
					personneIFac.Close();
				}, null);
			} catch(Exception) {
				personneIFac.Close();
				MessageBox.Show(Resources.EmpruntManagement_SearchLivreField_Erreur_lors_de_la_recuperation_des_informations_sur_le_livre_demande_);
			}
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
		
		private void RetourManagement_Load(object sender, EventArgs e){
			InitComponent();
		}

		private void txtClientField_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				SearchClientField();
			}
		}

		private void btnClientGo_Click(object sender, EventArgs e) {
			SearchClientField();
		}

		private void cmbClientField_SelectedValueChanged(object sender, EventArgs e) {
			if (!_bCmbClientFieldToogle){
				return;
			}
			var objPersonne = (PersonneBO)((ComboBox)sender).SelectedValue;
			FillRecapitulatifClient();
			AlertToMuchBook(objPersonne);
			FillCmpLivreField(objPersonne);
		}

		private void txtLivreField_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				SearchLivreField();
			}
		}

		private void btnLivreGo_Click(object sender, EventArgs e) {
			SearchLivreField();
		}

		private void cmbLivreField_SelectedIndexChanged(object sender, EventArgs e) {
			if (_bCmbClientFieldToogle) {
				FillRecapitulatifLivre();
			}
		}
		
		private void ActualBibliothequeChange(object value, EventArgs e) {
			var objBibliotheque = (BibliothequeBO) value;
			txtLivreField.Enabled = (objBibliotheque != null);
			btnLivreGo.Enabled = (objBibliotheque != null);
			if (cmbClientField.SelectedValue != null) {
				FillCmpLivreField((PersonneBO)cmbClientField.SelectedValue);
			}
			if (txtLivreField.Text.Trim() == ""){
				cmbLivreField.DataSource = null;
				cmbLivreField.Enabled = false;
				return;
			}
			SearchLivreField();
		}

		private void btnValider_Click(object sender, EventArgs e) {
			if (cmbClientField.SelectedValue == null || cmbLivreField.SelectedValue == null) {
				MessageBox.Show(Resources.EmpruntManagement_btnValider_Click_Tous_les_champs_ne_sont_pas_remplis_);
				return;
			}
			var resultEmprunt = _dashboardAdminManager.SaveRetour(CGlobalCache.SessionManager.Personne.Administrateur, (PersonneBO)cmbClientField.SelectedValue, (LivreBO)cmbLivreField.SelectedValue);
			if (resultEmprunt == null){
				MessageBox.Show(Resources.EmpruntManagement_btnValider_Click_Echec_lors_de_l_enregistrement_de_l_emprunt);
				return;
			}
			CGlobalCache.LstEmpruntSelectAll.Add(resultEmprunt);

			var objItem = _dashboardAdminManager.SelectItemByEmpruntId(resultEmprunt);
			if (objItem == null){
				MessageBox.Show(@"Echec lors de la récupération de l'item lié à l'emprunt");
				return;
			}
			CGlobalCache.LstItemSelectByAministrateurId.Add(objItem);

			lblAlert.Visible = true;
			lblAlert.Text = String.Format("Retour enregistré ref: {0}\nEmprunt: {1:C}\nAmende: {2:C}\nMontant à payer: {3:C} !", resultEmprunt.EmpruntId, objItem.Count, objItem.Amende, objItem.Montant);
			
			cmbClientField.DataSource = null;
			cmbLivreField.Enabled = false;
			cmbLivreField.DataSource = null;
			cmbLivreField.Enabled = false;
			
			var selectedValue = cmbClientField.SelectedValue;
			if (selectedValue != null) {
				AlertToMuchBook((PersonneBO)selectedValue);
			}

			_bCmbClientFieldToogle = false;
			lblInfo.Visible = true;
			btnValider.Enabled = false;
			cmbLivreField.DataSource = null;
			cmbLivreField.Enabled = false;
		}
	}
}
