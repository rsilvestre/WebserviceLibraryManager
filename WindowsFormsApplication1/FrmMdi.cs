using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApplication1.Livre;
using WindowsFormsApplication1.Properties;
using WCF.Proxies;
using WebsBO;
using WindowsFormsApplication1.Dashboard;
using WindowsFormsApplication1.DashboardAdmin;
using WindowsFormsApplication1.RefLivre;

namespace WindowsFormsApplication1 {
	public partial class FrmMdi : Form {
		private int _childFormNumber;
		private FrmSplashScreen _splashScreen;
		private readonly AutoResetEvent _autoEvent = new AutoResetEvent(false);
        private ToolStripComboBox _cmbToolStripBibliotheque;

		private Int32 _iLockMdi;

		public FrmMdi() {
			InitializeComponent();
		}

		public Int32 LockMdi {
			get { return _iLockMdi; }
			set { _iLockMdi = value; }
		}

		public void DecrementILockMdi() {

			Interlocked.Decrement(ref _iLockMdi);
			if (_iLockMdi == 0) {
				_autoEvent.Set();
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

		private void InitComponent() {

			if (CGlobalCache.SessionManager.Personne.Administrateur != null) {
				_cmbToolStripBibliotheque.Items.AddRange(CGlobalCache.SessionManager.Personne.Administrateur.LstBibliotheque.ToArray());
				lblToolStripManagement.Visible = true;
				_cmbToolStripBibliotheque.Visible = true;
				administrationToolStripMenuItem.Visible = true;
			} else {
				//BibliothequeBO bibliothequeItem = CGlobalCache.SessionManager.Personne.Client.Bibliotheque;
				//toolStripComboBox1.Items.Add(bibliothequeItem);
				//toolStripComboBox1.SelectedItem = bibliothequeItem;
				lblToolStripManagement.Visible = false;
				_cmbToolStripBibliotheque.Visible = false;
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
			
			CGlobalCache.actualBibliothequeChangeEventHandler += ActualBibliothequeChange;
		}

		private void FrmMdi_Load(object sender, EventArgs e) {
			LockMdi = 2;
			try {
				_splashScreen = new FrmSplashScreen(this);
				_splashScreen.Show();
				_splashScreen.EnableConnect(CGlobalCache.LoadCache(this));

				while (!_autoEvent.WaitOne(50, true)) {
					Application.DoEvents();
				}

				if (_splashScreen.Connect) {
					_splashScreen.Close();
					WindowState = FormWindowState.Maximized;
					InitComponent();
					LauchDashboard();
				} else {
					_splashScreen.Close();
					Close();
				}

			} catch (Exception ex) {
				_splashScreen.Close();
				Close();
			}
		}

		private void LauchDashboard() {
			try {
				if (!CGlobalCache.SessionManager.IsAdministrateur) {
					var dashboardManager = new DashboardManager(this) {MdiParent = this};
					dashboardManager.Show();
				} else {
					var dashboardAdminManager = new DashboardAdminManager(this);
					dashboardAdminManager.MdiParent = this;
					dashboardAdminManager.Show();
				}
			} catch (Exception ex) {
				throw;
			} finally {
				ChildFormIncrement();
			}
		}

		private void ShowClientDashboard(object sender, EventArgs e) {
			if (_childFormNumber != 0) {
				MessageBox.Show(Resources.FrmMdi_ShowClientDashboard_Vous_avez_deja_un_Dashboard_ouvert);
				return;
			}
			var dashboardManager = new DashboardManager(this);
			ChildFormIncrement();
			dashboardManager.MdiParent = this;
			dashboardManager.Show();
		}

		private void ShowAdminDashboard(object sender, EventArgs e) {
			if (_childFormNumber != 0) {
				MessageBox.Show(Resources.FrmMdi_ShowClientDashboard_Vous_avez_deja_un_Dashboard_ouvert);
				return;
			}
			var dashboardManager = new DashboardAdminManager(this);
			ChildFormIncrement();
			dashboardManager.MdiParent = this;
			dashboardManager.Show();
		}

		private void ChildFormIncrement() {
			_childFormNumber++;
		}

		public void ChildFormDecrement() {
			_childFormNumber--;
		}

		private void OpenFile(object sender, EventArgs e) {
			var openFileDialog = new OpenFileDialog
			{
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
				Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog(this) == DialogResult.OK) {
				var fileName = openFileDialog.FileName;
			}
		}

		private void ExitToolsStripMenuItem_Click(object sender, EventArgs e) {
			Close();
		}

		private void CutToolStripMenuItem_Click(object sender, EventArgs e) {
		}

		private void CopyToolStripMenuItem_Click(object sender, EventArgs e) {
		}

		private void PasteToolStripMenuItem_Click(object sender, EventArgs e) {
		}


		private void searchToolStripMenuItem_Click(object sender, EventArgs e) {
			var addBookFromAmazon = new AddBookFromAmazon(this) {MdiParent = this};
			addBookFromAmazon.Show();
		}

		internal Boolean InsertLivreFromAmazon(RefLivreBO objRefLivre) {
			List<RefLivreBO> lstRefLivre;
			try {
				using (var refLivreProxy = new RefLivreIFACClient()) {
					lstRefLivre = refLivreProxy.InsertLivre(CGlobalCache.SessionManager.Token, objRefLivre.ISBN, objRefLivre.Titre, objRefLivre.Description, objRefLivre.Auteur, objRefLivre.Langue, objRefLivre.Editeur, objRefLivre.Published, objRefLivre.ImageUrl);
				}
			} catch (Exception ex) {
				throw;
			}
			if (!lstRefLivre.Any()) {
				return true;
			}
			return CGlobalCache.ReloadRefLivreCache();
		}

		internal Boolean InsertLivre(LivreBO pObjLivre) {
			LivreBO Livre;
			try {
				using (var livreProxy = new LivreIFACClient()) {
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
			var frmCreateLivre = new CreateLivre(this);
			frmCreateLivre.MdiParent = this;
			frmCreateLivre.Show();
		}

		private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			var objBibliotheque = (BibliothequeBO)_cmbToolStripBibliotheque.SelectedItem;
			CGlobalCache.ActualBibliotheque = objBibliotheque;
			if (objBibliotheque != null && CGlobalCache.SessionManager.IsAdministrateur) {
				addBookToolStripMenuItem.Enabled = true;
			} 
		}

		private void ActualBibliothequeChange(object value, EventArgs e) {
			var objBibliothequeBo = (BibliothequeBO) value;
			_cmbToolStripBibliotheque.SelectedItem = objBibliothequeBo;
		}

		private void findBookToolStripMenuItem_Click(object sender, EventArgs e) {
			var frmCreateLivre = new SearchLivre(this) {MdiParent = this};
			frmCreateLivre.Show();
		}
	}
}
