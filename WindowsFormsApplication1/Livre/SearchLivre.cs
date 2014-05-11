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
		private LivreBO _livreSelected;

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

		/// <summary>
		/// Recherche Livre par titre
		/// </summary>
		/// <param name="pSearchText"></param>
		private void FindByTitre(String pSearchText) {
			//List<LivreBO> lstLivre = CGlobalCache.LstLivreByBibliotheque.FindAll(xx => xx.RefLivre.Titre.Contains(pSearchText)).ToList();

			Predicate<LivreBO> searchPredicacte = (xx) => { return xx.RefLivre.Titre.Contains(pSearchText); };
			FindByTitreResult(searchPredicacte);
		}

		/// <summary>
		/// Recherche Livre par ISBN
		/// </summary>
		/// <param name="pSearchText"></param>
		private void FindByIsbn(String pSearchText) {
			//List<LivreBO> lstLivre = CGlobalCache.LstLivreByBibliotheque.FindAll(xx => xx.RefLivre.ISBN.Contains(pSearchText)).ToList();
			
			Predicate<LivreBO> searchPredicacte = (xx) => { return xx.RefLivre.ISBN.Contains(pSearchText); };
			FindByTitreResult(searchPredicacte);
		}

		/// <summary>
		/// Affichage du résultat de recherche
		/// </summary>
		/// <param name="pSearchPredicate"></param>
		private void FindByTitreResult(Predicate<LivreBO> pSearchPredicate) {
			// Recherche dans le bibliotheque locale
			var grpLivreLocal = CGlobalCache.LstLivreByBibliotheque.FindAll(pSearchPredicate).GroupBy(xx => xx.RefLivreId).Select(group => new { refLivreId = group.Key, count = group.Count() });
			// Recherche dans toutes les bibliothèques (locale comprise)
			var grpLivreAll = CGlobalCache.LstLivreSelectAll.FindAll(pSearchPredicate).GroupBy(xx => xx.RefLivreId).Select(group => new { refLivreId = group.Key, count = group.Count() });
			
			// Jointure des resultats entre la bibliothèque locale et les autres
			var query = grpLivreLocal.Join(grpLivreAll, livreLocal => livreLocal.refLivreId, livreAll => livreAll.refLivreId, (livre1, livre2) => new { countLocal = livre1.count, countAll = livre2.count, refLivreId = livre1.refLivreId});
			
			// Création de la liste de résultat
			var lstLivre = new List<dynamic>();
			foreach (var livre in query) {
				//lstSearchResult.Items.Add(CGlobalCache.LstRefLivreSelectAll.FirstOrDefault(xx => xx.RefLivreId.Equals(toto.refLivreId)));
				//lstSearchResult.Items.Add(new { toto.count, CGlobalCache.LstRefLivreSelectAll.FirstOrDefault(xx => xx.RefLivreId.Equals(toto.refLivreId)).Titre });
				LivreBO objLivreAll = CGlobalCache.LstLivreSelectAll.FirstOrDefault(xx => xx.RefLivre.RefLivreId.Equals(livre.refLivreId));
				
				// Ajout des éléments de la liste de résultat
				lstLivre.Add(new { Locale = livre.countLocal, Total = livre.countAll, ISBN = objLivreAll.RefLivre.ISBN, Titre = objLivreAll.ToString() });
			}
			
			// Affichage du résultat de la recherche
			dataGridSearchResult.DataSource = null;
			dataGridSearchResult.DataSource = lstLivre;
			dataGridSearchResult.AutoResizeColumns();
		}

		private Boolean InsertDemandeReservation() {
			Boolean bResult = false;
			DemandeReservationBO objDemandeReservation = new DemandeReservationBO(), demandeReservationResult;
			objDemandeReservation.Client = CGlobalCache.SessionManager.Personne.Client;
			objDemandeReservation.RefLivre = _livreSelected.RefLivre;

			DemandeReservationIFACClient demandeReservationIFacClient = null;
			try {
				demandeReservationIFacClient = new DemandeReservationIFACClient();
				demandeReservationResult = demandeReservationIFacClient.InsertDemandeReservation(CGlobalCache.SessionManager.Token, objDemandeReservation);
			} catch (Exception ex) {
				throw;
			} finally {
				if (demandeReservationIFacClient != null) {
					demandeReservationIFacClient.Close();
				}
			}
			if (demandeReservationResult != null) {
				CGlobalCache.LstDemandeReservationByClient.Add(demandeReservationResult);
				bResult = true;
			}
			return bResult;
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
			this.Close();
		}

		private void SearchLivre_Load(object sender, EventArgs e) {
			if (CGlobalCache.SessionManager.Personne != null) {
				lblBibliotheque.Text = CGlobalCache.SessionManager.Personne.Client.Bibliotheque.BibliothequeName;
			}
		}

		private void dataGridSearchResult_CellClick(object sender, DataGridViewCellEventArgs e) {
			if (e.RowIndex < 0) {
				return;
			}
			_livreSelected = CGlobalCache.LstLivreSelectAll.FirstOrDefault(xx => xx.RefLivre.ISBN.Equals(dataGridSearchResult.Rows[e.RowIndex].Cells[2].Value));
			dataGridSearchResult.Rows[e.RowIndex].Selected = true;
			btnSelection.Enabled = true;
		}

		private void btnSelection_Click(object sender, EventArgs e) {
			DialogResult result = MessageBox.Show(String.Format(@"Demande de réservation pour: ""{0}""", _livreSelected.RefLivre.Titre), "Demande de réservation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false);
			if (result == System.Windows.Forms.DialogResult.OK) {
				if (!InsertDemandeReservation()) {
					MessageBox.Show("Erreur lors de l'enregistrement de la demande de réservation");
					return;
				}
				this.Close();
			}
		}
	}
}
