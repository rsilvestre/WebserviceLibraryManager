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
		public DashboardManager() {
			InitializeComponent();
		}

		private void DashboardManager_Load(object sender, EventArgs e) {
			PersonneBO personne = CGlobalCache.SessionManager.Personne;
			lblName.Text = String.Format(@"{0} {1}",personne.PersonneFirstName, personne.PersonneLastName);
			lblDtLastVisite.Text = "";
			foreach (LivreBO objLivre in CGlobalCache.LstLivreByBibliotheque.FindAll(xx => {TimeSpan diff = DateTime.Now - xx.CreatedAt; return diff.Days < 10;})) {
				lstNouveaute.Items.Add(objLivre.ToString());
			}

			lblBibliotheque.Text = personne.Client.Bibliotheque.BibliothequeName;


		}
	}
}
