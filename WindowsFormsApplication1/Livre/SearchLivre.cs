using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCF.Proxies;
using WebsBO;

namespace WindowsFormsApplication1.Livre {
	public partial class SearchLivre : Form {
		private FrmMdi _frmMdi;
		private delegate List<LivreBO> ASyncGuiSelectLstLivreByString(String pToken, String pString);

		private FrmMdi FrmMdi {
			get { return _frmMdi; }
			set { _frmMdi = value; }
		}

		public SearchLivre() {
			InitializeComponent();
		}

		public SearchLivre(FrmMdi frmMdi) : this() {
			this._frmMdi = _frmMdi;
		}
		
		private void RaiseFind() {
			if (radioISBN.Checked) {
				FindByIsbn(txtSearch.Text);
			} else {
				FindByTitre(txtSearch.Text);
			}
		}
		private void FindByTitre(String pSearchText) {
			List<LivreBO> lstLivre = CGlobalCache.LstLivreByBibliotheque.FindAll(xx => xx.RefLivre.Titre.Contains(pSearchText)).ToList();
			FindByTitreResult(lstLivre);
		}

		private void FindByIsbn(String pSearchText) {
			List<LivreBO> lstLivre = CGlobalCache.LstLivreByBibliotheque.FindAll(xx => xx.RefLivre.ISBN.Contains(pSearchText)).ToList();
			FindByTitreResult(lstLivre);
		}

		private void FindByTitreResult(List<LivreBO> lstLivre) {
			lstSearchResult.Items.Clear();
			lstSearchResult.Items.AddRange(lstLivre.ToArray());
		}

		private void btnSearch_Click(object sender, EventArgs e) {
			RaiseFind();
		}

		private void txtSearch_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				RaiseFind();
			}
		}

		private void txtSearch_KeyPress(object sender, KeyPressEventArgs e) {
			if (radioISBN.Checked && !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar)) {
				e.Handled = true;
			}
		}

		private void radioISBN_CheckedChanged(object sender, EventArgs e) {
			if (((RadioButton)sender).Checked) {
				String pattern = @"[^0-9]";
				if (Regex.Matches(txtSearch.Text, pattern).Count > 0) {
					txtSearch.Text = Regex.Replace(txtSearch.Text, pattern, @"");
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
