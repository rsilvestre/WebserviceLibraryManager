using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebsBO;
using System.Reflection;
using WCF.Proxies;
using System.Runtime.Remoting.Messaging;
using System.Net;

namespace WindowsFormsApplication1.DashboardAdmin {
	public partial class ReservationManagement : UserControl {
		private DashboardAdminManager _dashboardAdminManager;
		private bool _bCmpReservationInitialized;
		private List<DemandeReservationBO> _lstDemandeReservation;
		private DemandeReservationBO _demandeReservationSelected;

		private delegate PersonneBO AsyncGuiSelectPersonneById(String Token, Int32 pPersonneId);

		public ReservationManagement() {
			InitializeComponent();
		}

		public ReservationManagement(DashboardAdminManager dashboardAdminManager) : this() {
			this._dashboardAdminManager = dashboardAdminManager;
		}

		#region private

		private void initComponent() {
			fillCmbDemandeReservation();
			dataGridDemandeReservation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
		}

		private void fillCmbDemandeReservation() {
			List<DemandeReservationCombo> lstDemandeReservationCombo = new List<DemandeReservationCombo>();
			lstDemandeReservationCombo.Add(new DemandeReservationCombo("", ""));
			lstDemandeReservationCombo.Add(new DemandeReservationCombo("En cours", "LstNewDemandeReservationByClient"));
			lstDemandeReservationCombo.Add(new DemandeReservationCombo("Passée", "LstOldDemandeReservationByClient"));
			cmbReservationToogle.DataSource = lstDemandeReservationCombo;
            cmbReservationToogle.DisplayMember = "Title";
			cmbReservationToogle.ValueMember = "LstDemandeReservation";
			_bCmpReservationInitialized = true;
		}

		private void cmbReservationToogle_SelectedIndexChanged(object sender, EventArgs e) {
			ComboBox objCmpBox = (ComboBox)sender;
			if (objCmpBox.SelectedIndex == -1 || !_bCmpReservationInitialized) {
				return;
			}

			if (objCmpBox.SelectedValue == null || objCmpBox.SelectedValue.ToString() == "") {
				return;
			}

			try {
				_lstDemandeReservation = (List<DemandeReservationBO>)typeof(CGlobalCache).GetProperty(objCmpBox.SelectedValue.ToString()).GetValue(null, null);
			} catch (Exception ex) {
				throw;
			}
			this.refreshDataGrid();
			this.refreshField();
		}

		private void refreshField() {
			foreach (Panel panel in this.Controls.OfType<Panel>()) {
				foreach (TextBox textBox in panel.Controls.OfType<TextBox>()) {
					textBox.Text = "";
				}
			}
			picBook.Image = null;
		}

		private void refreshDataGrid() {
			if (_lstDemandeReservation == null || CGlobalCache.ActualBibliotheque == null) {
				return;
			}

			List<DemandeReservationBO> lstDemandeReservation = _lstDemandeReservation.FindAll(xx => xx.Client.BibliothequeId == CGlobalCache.ActualBibliotheque.BibliothequeId);
			var lstDemandeReservationSource = lstDemandeReservation.Select(selection => new { Id = selection.DemandeReservationId, ClientId = selection.Client.ClientId, Titre = selection.RefLivre.Titre, Date = selection.CreatedAt.ToShortDateString() }).ToList();
			
			dataGridDemandeReservation.DataSource = null;
			dataGridDemandeReservation.DataSource = lstDemandeReservationSource;
			dataGridDemandeReservation.Refresh();
			dataGridDemandeReservation.AutoResizeColumns();

			dataGridDemandeReservation.ClearSelection();
			btnAnnuler.Enabled = false;
		}

		private void showDetailSelection() {
			if (_demandeReservationSelected == null) {
				return;
			}
			this.getPersonne();
			txtClientId.Text = _demandeReservationSelected.ClientId.ToString();
			txtRefLivreTitre.Text = _demandeReservationSelected.RefLivre.Titre;
			txtReservationDate.Text = _demandeReservationSelected.DemandeReservationId.ToString();
			TimeSpan Ts = DateTime.Now - _demandeReservationSelected.CreatedAt;
			txtReservationDepassement.Text = Ts.Days.ToString();
			
			
			Action<String> GetImage = (imageUrl) => { 
				// Create a web request to the URL for the picture
				System.Net.WebRequest webRequest = HttpWebRequest.Create(imageUrl);
				// Execute the request synchronuously
				HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

				// Create an image from the stream returned by the web request
				picBook.Image = new System.Drawing.Bitmap(webResponse.GetResponseStream());
			};

			GetImage(_demandeReservationSelected.RefLivre.ImageUrl);
		}

		private void getPersonne() {
			PersonneIFACClient personneIFac = new PersonneIFACClient();
			
			AsyncGuiSelectPersonneById asyncExecute = personneIFac.SelectById;
			try {
				asyncExecute.BeginInvoke(CGlobalCache.SessionManager.Token, _demandeReservationSelected.Client.ClientId, xx => {
					var samplePersDelegate = (AsyncGuiSelectPersonneById)((AsyncResult)xx).AsyncDelegate;
					PersonneBO objPersonne = samplePersDelegate.EndInvoke(xx);
					if (objPersonne != null) {
						txtClientName.Text = objPersonne.ToString();
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

		#endregion private

		#region callback

		private void ReservationManagement_Load(object sender, EventArgs e) {
			CGlobalCache.actualBibliothequeChangeEventHandler += actualBibliothequeChange;
			initComponent();
		}
		
		private void actualBibliothequeChange(object value, EventArgs e) {
			BibliothequeBO objBibliothequeBO = (BibliothequeBO) value;
			refreshDataGrid();
		}

		private void dataGridDemandeReservation_CellClick(object sender, DataGridViewCellEventArgs e) {
			if (e.RowIndex < 0) {
				return;
			}
			DataGridView objDataGridView = (DataGridView)sender;
			_demandeReservationSelected = _lstDemandeReservation.FirstOrDefault(xx => xx.DemandeReservationId.Equals(objDataGridView.Rows[e.RowIndex].Cells[0].Value));
			objDataGridView.Rows[e.RowIndex].Selected = true;
			btnAnnuler.Enabled = true;
			this.showDetailSelection();
		}

		private void dataGridDemandeReservation_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
			dataGridDemandeReservation_CellClick(sender, e);
		}

		private void btnEmprunter_Click(object sender, EventArgs e) {
			this._dashboardAdminManager.switchToEmpruntManagement(_demandeReservationSelected);
		}

		#endregion callback
	}

	public class DemandeReservationCombo {
        private String _title;
        private String _lstDemandeReservation;

        public DemandeReservationCombo(string pTitle, String pLstDemandeReservation) {
            this._title = pTitle;
            this._lstDemandeReservation = pLstDemandeReservation;
        }

        public string Title {
            get {
                return _title;
            }
        }

        public String LstDemandeReservation {
            get {
                return _lstDemandeReservation;
            }
        }

    }
}
