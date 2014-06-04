using System;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApplication1.Livre;
using WindowsFormsApplication1.Properties;
using WCF.Proxies;
using WebsBO;

namespace WindowsFormsApplication1.RefLivre {
	public partial class AddBookFromAmazon : Form {

		private readonly FrmMdi _objFrmMdi;
		private readonly SearchRefLivre _searchRefLivre;
		private readonly CreateLivre _createLivre;

		public AddBookFromAmazon() {
			InitializeComponent();
			FormBorderStyle = FormBorderStyle.FixedSingle;
		}
		public AddBookFromAmazon(FrmMdi pFrmMdi) : this() {
			_objFrmMdi = pFrmMdi;
		}

		public AddBookFromAmazon(SearchRefLivre pSearchRefLivre) : this() {
			_searchRefLivre = pSearchRefLivre;
		}

		public AddBookFromAmazon(CreateLivre pCreateLivre) : this() {
			_createLivre = pCreateLivre;
		}

		public FrmMdi ObjFrmMdi {
			get { return _objFrmMdi; }
		}

		public CreateLivre CreateLivre {
			get { return _createLivre; }
		}

		public SearchRefLivre SearchRefLivre {
			get { return _searchRefLivre; }
		}

		private RefLivreBO ObjRefLivre { get; set; }

		private void FindBookByIsbn(String txtSearch) {
			if (txtSearch.Length != 10 && txtSearch.Length != 13) {
				MessageBox.Show(Resources.AddBookFromAmazon_FindBookByIsbn_Le_numéro_ISBN_doit_contenir_10_ou_13_chiffres);
				return;
			}
			var txtSearchs = new[] { txtSearch };
			try {
				using (var refLivreProxy = new RefLivreIFACClient()) {
					foreach (RefLivreBO oRefLivre in refLivreProxy.FindAmazonRefByISBN(CGlobalCache.SessionManager.Token, txtSearchs.ToList())) {
						showBook1.SetLivre(oRefLivre);
						ObjRefLivre = oRefLivre;
						btnAccept.Enabled = true;
						break;
					}
				}
			} catch (Exception ex) {
				throw;
			}
		}

		private void btnSearch_Click(object sender, EventArgs e) {
			FindBookByIsbn(txtSearch.Text);
		}

		private void txtSearch_KeyPress(object sender, KeyPressEventArgs e) {
			if (e.KeyChar == (char)Keys.Enter) {
				FindBookByIsbn(txtSearch.Text);
				return;
			}

			if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar)) {
				//The char is not a number or a control key
				//Handle the event so the key press is accepted
				e.Handled = true;
				//Get out of there - make it safe to add stuff after the if statement
			}
		}

		private void btnAccept_Click(object sender, EventArgs e) {
			_createLivre.FillForm((RefLivreBO)ObjRefLivre.Clone());
			Dispose();
			//InsertRefLivre(ObjRefLivre);
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Dispose();
		}

		//private void InsertRefLivre(RefLivreBO ObjRefLivre) {
		//	try {
		//		if (_objFrmMDI.InsertLivreFromAmazon(ObjRefLivre)) {
		//			this.Dispose();
		//		}
		//	} catch (Exception ex) {
		//		throw;
		//	}
		//}
	}
}
