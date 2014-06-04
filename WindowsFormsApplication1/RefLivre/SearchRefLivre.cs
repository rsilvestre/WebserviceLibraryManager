using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApplication1.Livre;
using WebsBO;
using WCF.Proxies;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1.RefLivre {
	public partial class SearchRefLivre : Form {
		private readonly CreateLivre _createLivre;
		private delegate List<RefLivreBO> ASyncGuiSelectLstRefLivreByString(String pToken, String pString);

		public RefLivreBO ObjRefLivre { get; private set; }

		public SearchRefLivre() {
			InitializeComponent();
			FormBorderStyle = FormBorderStyle.FixedSingle;
		}

		public SearchRefLivre(CreateLivre createLivre) : this() {
			_createLivre = createLivre;
		}

		private void RaiseFind() {
			if (radioISBN.Checked) {
				FindByIsbn(txtSearch.Text);
			} else {
				FindByTitre(txtSearch.Text);
			}
		}
		private void FindByTitre(String pSearchText) {
			var refLivreIfac = new RefLivreIFACClient();
			ASyncGuiSelectLstRefLivreByString selectRefLivreByString = refLivreIfac.SelectByTitre;
			selectRefLivreByString.BeginInvoke(CGlobalCache.SessionManager.Token, pSearchText, CbFindByTitreResult, null);
		}

		private void FindByIsbn(String pSearchText) {
			var refLivreIfac = new RefLivreIFACClient();
			ASyncGuiSelectLstRefLivreByString selectRefLivreByString = refLivreIfac.SelectByISBN;
			selectRefLivreByString.BeginInvoke(CGlobalCache.SessionManager.Token, pSearchText, CbFindByTitreResult, null);
		}

		private void CbFindByTitreResult(IAsyncResult result) {
			var sampleFindByTitreCallback = (ASyncGuiSelectLstRefLivreByString)((AsyncResult)result).AsyncDelegate;
			var lstRefLivre = sampleFindByTitreCallback.EndInvoke(result);
			lstSearchResult.Items.Clear();
			lstSearchResult.Items.AddRange(lstRefLivre.ToArray());
		}

		/// <summary>
		/// Boutton de recherche de référence de livre sur amazon
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSearchAmazon_Click(object sender, EventArgs e) {
			_createLivre.SearchBookOnAmazon();
			Dispose();
			//AddBookFromAmazon frmAddBookFromAmazon = new AddBookFromAmazon(this);
			//frmAddBookFromAmazon.Show();
		}

		private void btnSearch_Click(object sender, EventArgs e) {
			RaiseFind();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
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
				const string pattern = @"[^0-9]";
				if (Regex.Matches(txtSearch.Text, pattern).Count > 0) {
					txtSearch.Text = Regex.Replace(txtSearch.Text, pattern, @"");
				}
			}
		}

		private void lstSearchResult_SelectedValueChanged(object sender, EventArgs e) {
			ObjRefLivre = (RefLivreBO)(((ListBox)sender).SelectedItem);
			btnSelection.Enabled = true;
		}

		private void btnSelection_Click(object sender, EventArgs e) {
			_createLivre.FillForm((RefLivreBO)ObjRefLivre.Clone());
			Dispose();
		}
	}
}
