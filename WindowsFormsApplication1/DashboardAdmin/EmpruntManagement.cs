using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCF.Proxies;
using WebsBO;
using System.Runtime.Remoting.Messaging;
using System.Net;

namespace WindowsFormsApplication1.DashboardAdmin {
	public partial class EmpruntManagement : UserControl {
		private DashboardAdminManager _dashboardAdminManager;
		private WebsBO.DemandeReservationBO _objDemandeReservation;
		private List<PersonneBO> _lstPersonneField;

		private bool _bCmbClientFieldToogle = false;
		private List<LivreBO> _lstLivreField;
		
		private delegate List<PersonneBO> AsyncGuiSelectListPersonne(String Token, String pPersonneInfo);
		private delegate List<LivreBO> AsyncGuiSelectListLivre(String Token, String pLivreInfo, Int32 pBibliothequeId);

		public EmpruntManagement() {
			InitializeComponent();
		}

		public EmpruntManagement(DashboardAdminManager dashboardAdminManager) : this() {
			this._dashboardAdminManager = dashboardAdminManager;
		}

		public EmpruntManagement(DashboardAdminManager dashboardAdminManager, WebsBO.DemandeReservationBO objDemandeReservation) : this(dashboardAdminManager) {
			this._objDemandeReservation = objDemandeReservation;
		}

		#region private

		private void initComponent() {
			if (CGlobalCache.ActualBibliotheque == null) {
				txtLivreField.Enabled = false;
			}
			CGlobalCache.actualBibliothequeChangeEventHandler += actualBibliothequeChange;
			if (_objDemandeReservation != null) {
				this.fillDemandeReservationControllers();
			}
		}

		private void fillCombobox() {
			throw new NotImplementedException();
		}

		private void fillDemandeReservationControllers() {
			throw new NotImplementedException();
		}

		private void SearchClientField() {
			PersonneIFACClient personneIFac = new PersonneIFACClient();
			
			AsyncGuiSelectListPersonne asyncExecute = personneIFac.SelectByInfo;
			try {
				asyncExecute.BeginInvoke(CGlobalCache.SessionManager.Token, txtClientField.Text, xx => {
					var samplePersDelegate = (AsyncGuiSelectListPersonne)((AsyncResult)xx).AsyncDelegate;
					_lstPersonneField = samplePersDelegate.EndInvoke(xx);
					if (_lstPersonneField.Count > 0) {
						_bCmbClientFieldToogle = false;
						var tmpClientDatas = _lstPersonneField.Select(yy => new { Key = yy.PersonneMatricule + ": " + yy.ToString(), Value = yy }).ToList();
						tmpClientDatas.Insert(0, new { Key = "", Value = null as PersonneBO });
						cmbClientField.DataSource = tmpClientDatas;
						cmbClientField.ValueMember = "Value";
						cmbClientField.DisplayMember = "Key";
						cmbClientField.Enabled = true;
						_bCmbClientFieldToogle = true;
					}
					if (personneIFac != null) {
						personneIFac.Close();
					}
				}, null);
			} catch(Exception ex) {
				if (personneIFac != null) {
					personneIFac.Close();
				}
				MessageBox.Show("Erreur lors de la récupération des informations sur le livre demandé.");
			}
		}

		private void SearchDemandeReservationField() {
			throw new NotImplementedException();
		}

		private void SearchLivreField() {
			LivreIFACClient livreIFac = new LivreIFACClient();
			
			AsyncGuiSelectListLivre asyncExecute = livreIFac.SelectByInfo;
			try {
				asyncExecute.BeginInvoke(CGlobalCache.SessionManager.Token, txtLivreField.Text, CGlobalCache.ActualBibliotheque.BibliothequeId, xx => {
					var samplePersDelegate = (AsyncGuiSelectListLivre)((AsyncResult)xx).AsyncDelegate;
					_lstLivreField = samplePersDelegate.EndInvoke(xx);
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
		
		private void fillDemandeReservation() {
			if (cmbClientField.SelectedValue == null) {
				return;
			}
			
			PersonneBO objSelectedPersonne = (PersonneBO)cmbClientField.SelectedValue;
			List<DemandeReservationBO> lstDemandeReservation = CGlobalCache.LstNewDemandeReservationByClient.FindAll(xx => xx.ClientId == objSelectedPersonne.PersonneId).ToList();
			if (lstDemandeReservation.Count() > 0) {
				_bCmbClientFieldToogle = false;
				cmbDemandeReservationField.DataSource = null;
				var tmpDemandeReservationDatas = lstDemandeReservation.Select(xx => new { Key = "Id: " + xx.DemandeReservationId + " Date: " + xx.CreatedAt.ToShortDateString(), Value = xx }).ToList();
				tmpDemandeReservationDatas.Insert(0, new { Key = "", Value = null as DemandeReservationBO });
				cmbDemandeReservationField.DataSource = tmpDemandeReservationDatas;
				cmbDemandeReservationField.DisplayMember = "Key";
				cmbDemandeReservationField.ValueMember = "Value";
				cmbDemandeReservationField.Enabled = true;
				_bCmbClientFieldToogle = true;
			} else { 
				cmbDemandeReservationField.DataSource = null;
				cmbDemandeReservationField.Enabled = false;
			}
		}

		private void fillLivre() {
			if (cmbDemandeReservationField.SelectedValue == null) {
				return;
			}
			
			DemandeReservationBO objSelectedDemandeReservation = (DemandeReservationBO)cmbDemandeReservationField.SelectedValue;
			//List<DemandeReservationBO> lstDemandeReservation = CGlobalCache.LstNewDemandeReservationByClient.FindAll(xx => xx.ClientId == objSelectedDemandeReservation.PersonneId).ToList();
			if (objSelectedDemandeReservation != null) {
				_bCmbClientFieldToogle = false;
				cmbLivreField.DataSource = null;
				//var tmpLivreDatas = lstDemandeReservation.Select(xx => new { Key = "Id: " + xx.DemandeReservationId + " Date: " + xx.CreatedAt.ToShortDateString(), Value = xx }).ToList();
				//tmpLivreDatas.Insert(0, new { Key = "", Value = null as DemandeReservationBO });
				cmbLivreField.DisplayMember = "Key";
				cmbLivreField.ValueMember = "Value";
				_bCmbClientFieldToogle = true;
				cmbLivreField.DataSource = new List<dynamic>() {new { Key = objSelectedDemandeReservation.RefLivre.Titre, Value = objSelectedDemandeReservation.RefLivre }};
				cmbLivreField.Enabled = true;
			} else { 
				cmbLivreField.DataSource = null;
				cmbLivreField.Enabled = false;
			}
		}

		private void fillRecapitulatif() {
			Boolean bEnableValidButton = true;
			if (cmbLivreField.SelectedValue != null) {
				this.fillRecapitulatifLivreField(cmbLivreField.SelectedValue);
				bEnableValidButton &= true;
			} else {
				bEnableValidButton = false;
			}

			if (cmbClientField.SelectedValue != null) {
				PersonneBO objPersonne = (PersonneBO)cmbClientField.SelectedValue;
				txtClientName.Text = objPersonne.ToString();
				txtClientId.Text = objPersonne.PersonneId.ToString();

				bEnableValidButton &= true;
			} else {
				bEnableValidButton = false;
			}

			if (cmbDemandeReservationField.SelectedValue != null) {
				DemandeReservationBO objDemandeReservation = (DemandeReservationBO)cmbDemandeReservationField.SelectedValue;
				txtReservationDate.Text = objDemandeReservation.DemandeReservationId.ToString();
				TimeSpan diffTime = DateTime.Now - objDemandeReservation.CreatedAt;
				txtReservationDepassement.Text = diffTime.Days.ToString();

			}

			btnValider.Enabled = bEnableValidButton;

		}

		private void fillRecapitulatifLivreField(object pObj) {
			RefLivreBO objRefLivre;
			if (pObj.GetType() == typeof(RefLivreBO)) {
				objRefLivre = (RefLivreBO)pObj;
			} else if (pObj.GetType() == typeof(LivreBO)) {
				objRefLivre = ((LivreBO)pObj).RefLivre;
			} else {
				return;
			}
			txtRefLivreTitre.Text = objRefLivre.Titre;
			Action<String> GetImage = (imageUrl) => { 
				// Create a web request to the URL for the picture
				System.Net.WebRequest webRequest = HttpWebRequest.Create(imageUrl);
				// Execute the request synchronuously
				HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

				// Create an image from the stream returned by the web request
				picBook.Image = new System.Drawing.Bitmap(webResponse.GetResponseStream());
			};

				GetImage(objRefLivre.ImageUrl);
		}

		#endregion private

		#region callback

		private void EmpruntManagement_Load(object sender, EventArgs e) {
			this.initComponent();
		}

		#endregion callback

		private void txtClientField_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				this.SearchClientField();
			}
		}

		private void btnClientGo_Click(object sender, EventArgs e) {
				this.SearchClientField();
		}

		private void cmbClientField_SelectedValueChanged(object sender, EventArgs e) {
			if (_bCmbClientFieldToogle) {
				this.fillDemandeReservation();
				this.fillRecapitulatif();
			}
		}

		private void txtDemandeReservationField_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				this.SearchDemandeReservationField();
			}
		}

		private void btnDemandeReservationGo_Click(object sender, EventArgs e) {
				this.SearchDemandeReservationField();
		}

		private void cmbDemandeReservationField_SelectedValueChanged(object sender, EventArgs e) {
			if (_bCmbClientFieldToogle) {
				this.fillLivre();
			}
		}

		private void txtLivreField_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				this.SearchLivreField();
			}
		}

		private void btnLivreGo_Click(object sender, EventArgs e) {
				this.SearchLivreField();
		}

		private void cmbLivreField_SelectedValueChanged(object sender, EventArgs e) {
			if (_bCmbClientFieldToogle) {
				this.fillRecapitulatif();
			}
		}

		private void btnValider_Click(object sender, EventArgs e) {
			if (cmbClientField.SelectedValue == null || cmbLivreField.SelectedValue == null) {
				MessageBox.Show("Tous les champs ne sont pas remplis!");
				return;
			}
			_dashboardAdminManager.saveEmprunt(this, CGlobalCache.ActualBibliotheque, (PersonneBO)cmbClientField.SelectedValue, (LivreBO)cmbLivreField.SelectedValue, (DemandeReservationBO)cmbDemandeReservationField.SelectedValue);
		}
		
		private void actualBibliothequeChange(object value, EventArgs e) {
			BibliothequeBO objBibliotheque = (BibliothequeBO) value;
			txtLivreField.Enabled = (objBibliotheque != null);
		}

	}
}
