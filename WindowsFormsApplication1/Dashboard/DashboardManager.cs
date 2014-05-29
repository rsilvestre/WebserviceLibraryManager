using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebsBO;

namespace WindowsFormsApplication1.Dashboard {
	public partial class DashboardManager : Form {
		private FrmMdi _frmMdi;

		public DashboardManager() {
			InitializeComponent();
		}

		public DashboardManager(FrmMdi frmMdi) : this() {
			this._frmMdi = frmMdi;
		}

		private void DashboardManager_Load(object sender, EventArgs e) {
			this.loadDecoration();

			this.loadNouveaute();

			this.loadReservation();
		}

		private void loadReservation() {
			List<DemandeReservationBO> lstDemandeReservationEnCours = CGlobalCache.LstDemandeReservationByClient;
			lstReservationEnCours.Items.AddRange(lstDemandeReservationEnCours.ToArray());

			List<DemandeReservationBO> lstDemandeReservationPasse = CGlobalCache.LstDemandeReservationByClient;
			lstReservationPasse.Items.AddRange(lstDemandeReservationPasse.ToArray());
		}

		private void loadDecoration() {
			PersonneBO personne = CGlobalCache.SessionManager.Personne;
			lblName.Text = String.Format(@"{0} {1}",personne.PersonneFirstName, personne.PersonneLastName);
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
			lstNewLivreLocal.Items.AddRange(lstUniqLocalLivre.ToArray());
			
			// Select Uniq in a list !!!
			Int32 bibliothequeId = CGlobalCache.SessionManager.Personne.Client.BibliothequeId;
			List<LivreBO> lstUniqNetworkLivre = CGlobalCache.LstLivreSelectAll.FindAll(xx => xx.BibliothequeId != bibliothequeId).GroupBy(cust => cust.RefLivre.RefLivreId).Select(grp => grp.First()).OrderByDescending(xx => xx.CreatedAt).Take(25).ToList();
			lstNewLivreNetwork.Items.AddRange(lstUniqNetworkLivre.ToArray());
		}

		private void DashboardManager_FormClosed(object sender, FormClosedEventArgs e) {
			this._frmMdi.ChildFormDecrement();
			Dispose();
		}

	}
}
