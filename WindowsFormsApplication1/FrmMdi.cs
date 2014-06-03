using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCF.Proxies;
using WebsBO;
using WindowsFormsApplication1.Dashboard;
using WindowsFormsApplication1.DashboardAdmin;
using WindowsFormsApplication1.RefLivre;

namespace WindowsFormsApplication1 {
	public partial class FrmMdi : Form {
		private int childFormNumber = 0;
		private FrmSplashScreen _splashScreen;
		private AutoResetEvent AutoEvent = new AutoResetEvent(false);
        private ToolStripComboBox cmbToolStripBibliotheque;

		private Int32 _iLockMDI;

		public FrmMdi() {
			InitializeComponent();
		}

		public Int32 ILockMDI {
			get { return _iLockMDI; }
			set { _iLockMDI = value; }
		}

		public void DecrementILockMDI() {

			Interlocked.Decrement(ref _iLockMDI);
			if (_iLockMDI == 0) {
				AutoEvent.Set();
			}
		}

		public void SetLoadingText(String text) {
			try {
				_splashScreen.LoadginText = text;
				_splashScreen.Dostep(1);
			} catch (Exception Ex) {
				throw;
			}
		}

		private void initComponent() {

			if (CGlobalCache.SessionManager.Personne.Administrateur != null) {
				cmbToolStripBibliotheque.Items.AddRange(CGlobalCache.SessionManager.Personne.Administrateur.LstBibliotheque.ToArray());
				lblToolStripManagement.Visible = true;
				cmbToolStripBibliotheque.Visible = true;
				administrationToolStripMenuItem.Visible = true;
			} else {
				//BibliothequeBO bibliothequeItem = CGlobalCache.SessionManager.Personne.Client.Bibliotheque;
				//toolStripComboBox1.Items.Add(bibliothequeItem);
				//toolStripComboBox1.SelectedItem = bibliothequeItem;
				lblToolStripManagement.Visible = false;
				cmbToolStripBibliotheque.Visible = false;
				administrationToolStripMenuItem.Visible = false;
			}

			if (CGlobalCache.SessionManager.Personne.Client != null) {
				lblToolStripClient.Visible = true;
				txtToolStripClientBibliotheque.Visible = true;
				txtToolStripClientBibliotheque.Text = CGlobalCache.SessionManager.Personne.Client.Bibliotheque.BibliothequeName;
				libraryToolStripMenuItem.Visible = true;
			} else {
				lblToolStripClient.Visible = false;
				txtToolStripClientBibliotheque.Visible = false;
				libraryToolStripMenuItem.Visible = false;
			}
			
			CGlobalCache.actualBibliothequeChangeEventHandler += actualBibliothequeChange;
		}

		private void FrmMdi_Load(object sender, EventArgs e) {
			ILockMDI = 2;
			try {
				_splashScreen = new FrmSplashScreen(this);
				_splashScreen.Show();
				_splashScreen.EnableConnect(CGlobalCache.LoadCache(this));

				while (!AutoEvent.WaitOne(50, true)) {
					Application.DoEvents();
				}

				if (_splashScreen.Connect) {
					_splashScreen.Close();
					WindowState = FormWindowState.Maximized;
					initComponent();
					this.lauchDashboard();
				} else {
					_splashScreen.Close();
					Close();
				}

			} catch (Exception Ex) {
				_splashScreen.Close();
				Close();
			}
		}

		private void lauchDashboard() {
			try {
				if (!CGlobalCache.SessionManager.IsAdministrateur) {
					DashboardManager dashboardManager = new DashboardManager(this);
					dashboardManager.MdiParent = this;
					dashboardManager.Show();
				} else {
					DashboardAdminManager dashboardAdminManager = new DashboardAdminManager(this);
					dashboardAdminManager.MdiParent = this;
					dashboardAdminManager.Show();
				}
			} catch (Exception ex) {
				throw;
			} finally {
				this.ChildFormIncrement();
			}
		}

		private void ShowClientDashboard(object sender, EventArgs e) {
			if (childFormNumber != 0) {
				MessageBox.Show("Vous avez déjà un Dashboard ouvert");
				return;
			}
			DashboardManager dashboardManager = new DashboardManager(this);
			this.ChildFormIncrement();
			dashboardManager.MdiParent = this;
			dashboardManager.Show();
		}

		private void ShowAdminDashboard(object sender, EventArgs e) {
			if (childFormNumber != 0) {
				MessageBox.Show("Vous avez déjà un Dashboard ouvert");
				return;
			}
			DashboardAdminManager dashboardManager = new DashboardAdminManager(this);
			this.ChildFormIncrement();
			dashboardManager.MdiParent = this;
			dashboardManager.Show();
		}

		private void ChildFormIncrement() {
			childFormNumber++;
		}

		public void ChildFormDecrement() {
			childFormNumber--;
		}

		private void OpenFile(object sender, EventArgs e) {
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
			if (openFileDialog.ShowDialog(this) == DialogResult.OK) {
				string FileName = openFileDialog.FileName;
			}
		}

		private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) {
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK) {
				string FileName = saveFileDialog.FileName;
			}
		}

		private void ExitToolsStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void CutToolStripMenuItem_Click(object sender, EventArgs e) {
		}

		private void CopyToolStripMenuItem_Click(object sender, EventArgs e) {
		}

		private void PasteToolStripMenuItem_Click(object sender, EventArgs e) {
		}


		private void CascadeToolStripMenuItem_Click(object sender, EventArgs e) {
			LayoutMdi(MdiLayout.Cascade);
		}

		private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e) {
			LayoutMdi(MdiLayout.TileVertical);
		}

		private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e) {
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e) {
			LayoutMdi(MdiLayout.ArrangeIcons);
		}

		private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e) {
			foreach (Form childForm in MdiChildren) {
				childForm.Close();
			}
		}

		private void searchToolStripMenuItem_Click(object sender, EventArgs e) {
			AddBookFromAmazon addBookFromAmazon = new AddBookFromAmazon(this);
			addBookFromAmazon.MdiParent = this;
			addBookFromAmazon.Show();
		}

		internal Boolean InsertLivreFromAmazon(WebsBO.RefLivreBO objRefLivre) {
			List<RefLivreBO> lstRefLivre;
			try {
				using (RefLivreIFACClient refLivreProxy = new RefLivreIFACClient()) {
					lstRefLivre = refLivreProxy.InsertLivre(CGlobalCache.SessionManager.Token, objRefLivre.ISBN, objRefLivre.Titre, objRefLivre.Description, objRefLivre.Auteur, objRefLivre.Langue, objRefLivre.Editeur, objRefLivre.Published, objRefLivre.ImageUrl);
				}
			} catch (Exception ex) {
				throw;
			}
			if (lstRefLivre.Count() == 0) {
				return true;
			}
			return CGlobalCache.ReloadRefLivreCache();
		}

		internal Boolean InsertLivre(WebsBO.LivreBO pObjLivre) {
			LivreBO Livre;
			try {
				using (LivreIFACClient livreProxy = new LivreIFACClient()) {
					Livre = livreProxy.InsertLivre(CGlobalCache.SessionManager.Token, pObjLivre, CGlobalCache.SessionManager.Personne.Administrateur.AdministrateurId);
				}
			} catch (Exception ex) {
				throw;
			}
			if (Livre == null) {
				return false;
			}
			// Ajout du livre au cache
			CGlobalCache.LstLivreSelectAll.Add(Livre);
			if (CGlobalCache.SessionManager.Personne.Client != null && Livre.BibliothequeId == CGlobalCache.SessionManager.Personne.Client.BibliothequeId) {
				CGlobalCache.LstLivreByBibliotheque.Add(Livre);
			}
			return true;
		}

		private void addBookToolStripMenuItem_Click(object sender, EventArgs e) {
			Livre.CreateLivre frmCreateLivre = new Livre.CreateLivre(this);
			frmCreateLivre.MdiParent = this;
			frmCreateLivre.Show();
		}

		private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			BibliothequeBO objBibliotheque = (BibliothequeBO)cmbToolStripBibliotheque.SelectedItem;
			CGlobalCache.ActualBibliotheque = objBibliotheque;
			if (objBibliotheque != null && CGlobalCache.SessionManager.IsAdministrateur) {
				addBookToolStripMenuItem.Enabled = true;
			} 
		}

		private void actualBibliothequeChange(object value, EventArgs e) {
			BibliothequeBO objBibliothequeBO = (BibliothequeBO) value;
			cmbToolStripBibliotheque.SelectedItem = objBibliothequeBO;
		}

		private void findBookToolStripMenuItem_Click(object sender, EventArgs e) {
			Livre.SearchLivre frmCreateLivre = new Livre.SearchLivre(this);
			frmCreateLivre.MdiParent = this;
			frmCreateLivre.Show();
		}
	}
}
