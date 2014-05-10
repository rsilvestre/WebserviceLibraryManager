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
using WindowsFormsApplication1.RefLivre;

namespace WindowsFormsApplication1 {
	public partial class FrmMdi : Form {
		private int childFormNumber = 0;
		private FrmSplashScreen _splashScreen;
		private AutoResetEvent AutoEvent = new AutoResetEvent(false);
        private ToolStripComboBox toolStripComboBox1;

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
				toolStripComboBox1.Items.AddRange(CGlobalCache.SessionManager.Personne.Administrateur.LstBibliotheque.ToArray());
				toolStripComboBox1.Enabled = true;
			} else {
				BibliothequeBO bibliothequeItem = CGlobalCache.SessionManager.Personne.Client.Bibliotheque;
				toolStripComboBox1.Items.Add(bibliothequeItem);
				toolStripComboBox1.SelectedItem = bibliothequeItem;
				toolStripComboBox1.Enabled = false;
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
				} else {
					_splashScreen.Close();
					Close();
				}

			} catch (Exception Ex) {
				_splashScreen.Close();
				Close();
			}
		}

		private void ShowNewForm(object sender, EventArgs e) {
			Form childForm = new Form1();
			childForm.MdiParent = this;
			childForm.Text = "Window " + childFormNumber++;
			childForm.Show();
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
					Livre = livreProxy.InsertLivre(CGlobalCache.SessionManager.Token, pObjLivre);
				}
			} catch (Exception ex) {
				throw;
			}
			if (Livre == null) {
				return true;
			}
			return CGlobalCache.ReloadLivreCache();
		}

		private void addBookToolStripMenuItem_Click(object sender, EventArgs e) {
			Livre.CreateLivre frmCreateLivre = new Livre.CreateLivre(this);
			frmCreateLivre.MdiParent = this;
			frmCreateLivre.Show();
		}

		private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			BibliothequeBO objBibliotheque = (BibliothequeBO)toolStripComboBox1.SelectedItem;
			CGlobalCache.ActualBibliotheque = objBibliotheque;
			if (objBibliotheque != null && CGlobalCache.SessionManager.IsAdministrateur) {
				addBookToolStripMenuItem.Enabled = true;
			} 
		}

		private void actualBibliothequeChange(object value, EventArgs e) {
			BibliothequeBO objBibliothequeBO = (BibliothequeBO) value;
			toolStripComboBox1.SelectedItem = objBibliothequeBO;
		}

		private void findBookToolStripMenuItem_Click(object sender, EventArgs e) {
			Livre.SearchLivre frmCreateLivre = new Livre.SearchLivre(this);
			frmCreateLivre.MdiParent = this;
			frmCreateLivre.Show();
		}
	}
}
