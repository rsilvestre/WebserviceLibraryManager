using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCF.Proxies;
using WebsBO;

namespace WindowsFormsApplication1.RefLivre {
	public partial class AddBookFromAmazon : Form {

		private FrmMdi _objFrmMDI;
		private SearchRefLivre _searchRefLivre;
		private Livre.CreateLivre _createLivre;
		private RefLivreBO _ObjRefLivre;

		public AddBookFromAmazon() {
			InitializeComponent();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		}
		public AddBookFromAmazon(FrmMdi pFrmMDI) : this() {
			_objFrmMDI = pFrmMDI;
		}

		public AddBookFromAmazon(SearchRefLivre pSearchRefLivre) : this() {
			_searchRefLivre = pSearchRefLivre;
		}

		public AddBookFromAmazon(Livre.CreateLivre pCreateLivre) : this() {
			_createLivre = pCreateLivre;
		}

		public FrmMdi ObjFrmMDI {
			get { return _objFrmMDI; }
		}

		public Livre.CreateLivre CreateLivre {
			get { return _createLivre; }
		}

		public SearchRefLivre SearchRefLivre {
			get { return _searchRefLivre; }
		}

		private RefLivreBO ObjRefLivre {
			get { return _ObjRefLivre; }
			set { _ObjRefLivre = value; }
		}

		private void FindBookByISBN(String txtSearch) {
			if (txtSearch.Length != 10 && txtSearch.Length != 13) {
				MessageBox.Show("Le numéro ISBN doit contenir 10 ou 13 chiffres");
				return;
			}
			String[] txtSearchs = new String[] { txtSearch };
			try {
				using (RefLivreIFACClient refLivreProxy = new RefLivreIFACClient()) {
					foreach (RefLivreBO oRefLivre in refLivreProxy.FindAmazonRefByISBN(txtSearchs.ToList())) {
						showBook1.setLivre(oRefLivre);
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
			FindBookByISBN(txtSearch.Text);
		}

		private void txtSearch_KeyPress(object sender, KeyPressEventArgs e) {
			if (e.KeyChar == (char)Keys.Enter) {
				FindBookByISBN(txtSearch.Text);
				return;
			}

			if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar)) {
				//The char is not a number or a control key
				//Handle the event so the key press is accepted
				e.Handled = true;
				//Get out of there - make it safe to add stuff after the if statement
				return;
			}
		}

		private void btnAccept_Click(object sender, EventArgs e) {
			_createLivre.fillForm((RefLivreBO)ObjRefLivre.Clone());
			this.Dispose();
			//InsertRefLivre(ObjRefLivre);
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
