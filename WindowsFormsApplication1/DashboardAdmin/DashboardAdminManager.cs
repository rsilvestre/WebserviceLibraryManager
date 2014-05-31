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

namespace WindowsFormsApplication1.DashboardAdmin {
	public partial class DashboardAdminManager : Form {
		private FrmMdi _frmMdi;
		private int _dashboardWidth;
		private int _cmbBibliothequeLocationX;
		private int _lblBibliothequeTitleLocationX;

		public DashboardAdminManager() {
			InitializeComponent();
		}

		public DashboardAdminManager(FrmMdi frmMdi) : this() {
			this._frmMdi = frmMdi;
		}

		private void loadDecoration() {
			PersonneBO personne = CGlobalCache.SessionManager.Personne;
			lblName.Text = personne.ToString();
			cmbBibliotheque.SelectedItem = CGlobalCache.ActualBibliotheque;
		}

		private void initComponent() {
			cmbBibliotheque.Items.AddRange(CGlobalCache.SessionManager.Personne.Administrateur.LstBibliotheque.ToArray());
			CGlobalCache.actualBibliothequeChangeEventHandler += actualBibliothequeChange;
		}

		private void fixSize() {
			_dashboardWidth = this.Width;
			_cmbBibliothequeLocationX = cmbBibliotheque.Location.X ;
			_lblBibliothequeTitleLocationX = lblBibliothequeTitle.Location.X;
		}

		private void DashboardAdminManager_Load(object sender, EventArgs e) {
			this.fixSize();
			this.initComponent();
			this.loadDecoration();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			BibliothequeBO objBibliotheque = (BibliothequeBO)((ComboBox)sender).SelectedItem;
			CGlobalCache.ActualBibliotheque = objBibliotheque;
			if (objBibliotheque != null && CGlobalCache.SessionManager.IsAdministrateur) {
			} 
		}

		private void actualBibliothequeChange(object value, EventArgs e) {
			BibliothequeBO objBibliothequeBO = (BibliothequeBO) value;
			cmbBibliotheque.SelectedItem = objBibliothequeBO;
		}

		private void DashboardAdminManager_FormClosed(object sender, FormClosedEventArgs e) {
			this._frmMdi.ChildFormDecrement();
			Dispose();
		}
	}
}
