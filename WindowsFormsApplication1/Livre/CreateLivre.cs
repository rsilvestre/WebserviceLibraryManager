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
using WindowsFormsApplication1.RefLivre;

namespace WindowsFormsApplication1.Livre {
	public partial class CreateLivre : Form {
		private FrmMdi _objFrmMDI;
		private LivreBO _ObjLivre;


		public CreateLivre() {
			InitializeComponent();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		}

		public CreateLivre(FrmMdi frmMdi) : this() {
			this._objFrmMDI = frmMdi;
		}

		/// <summary>
		/// Commande permettant la recherche de référence de livre sur amazon
		/// </summary>
		public void SearchBookOnAmazon() {
			AddBookFromAmazon frmAddBookFromAmazon = new AddBookFromAmazon(this);
			frmAddBookFromAmazon.Show();
		}

		/// <summary>
		/// Rempli un objet livre avec des données de référence de livre
		/// </summary>
		/// <param name="pObjRefLivre"></param>
		public void fillForm(RefLivreBO pObjRefLivre) {
			LivreBO oLivre = new LivreBO();
			oLivre.RefLivre = pObjRefLivre;
			oLivre.Bibliotheque = CGlobalCache.ActualBibliotheque;
			ObjLivre = (LivreBO)oLivre.Clone();
			livreFormulaire1.SetForm(oLivre);
			btnCreate.Enabled = true;
		}

		private LivreBO ObjLivre {
			get { return _ObjLivre; }
			set { _ObjLivre = value; }
		}

		/// <summary>
		/// Ajout d'une référence de livre à la base de données (DEPRECATED)
		/// </summary>
		/// <param name="pObjRefLivre"></param>
		/// <returns></returns>
		private Boolean InsertRefLivre(RefLivreBO pObjRefLivre) {
			Boolean result = false;
			try {
				result = _objFrmMDI.InsertLivreFromAmazon(pObjRefLivre);
			} catch (Exception ex) {
				throw;
			}
			return result;
		}

		/// <summary>
		/// Ajoute un livre à la base de données
		/// </summary>
		/// <param name="pObjLivre"></param>
		/// <returns></returns>
		private Boolean InsertLivre(LivreBO pObjLivre) {
			Boolean result = false;

			// Vérifie si une reflivre a déjà cet isbn et l'ajoute au livre
			RefLivreBO objRefLivre = CGlobalCache.LstRefLivreSelectAll.FirstOrDefault(xx => xx.ISBN == pObjLivre.RefLivre.ISBN);
			if (objRefLivre != null && objRefLivre.RefLivreId != 0) {
				pObjLivre.RefLivreId = objRefLivre.RefLivreId;
			}

			// Appel au webservice
			try {
				result = _objFrmMDI.InsertLivre(pObjLivre);
			} catch (Exception ex) {
				throw;
			}
			return result;
		}

		/// <summary>
		/// Vérifie si des champs ont été modifiés
		/// </summary>
		private void CheckField() {
			livreFormulaire1.CheckField(ObjLivre);
		}

		#region event

		/// <summary>
		/// Boutton d'ouverture de la fenetre de recherche de référence de livre dans le cache
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void refLivreSearch_Click(object sender, EventArgs e) {
			RefLivre.SearchRefLivre frmSearchRefLivre = new RefLivre.SearchRefLivre(this);
			frmSearchRefLivre.Show();
		}

		/// <summary>
		/// Boutton de création d'un livre
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCreate_Click(object sender, EventArgs e) {
			// Vérifie si des champes ont été modifiés
			CheckField();
			// Insert livre dans la database
			Boolean bInsert = InsertLivre(ObjLivre);
			// Vérifie si les données ont bien été sauvées dans la database
			if (!bInsert) {
				MessageBox.Show("Erreur lors de l'insertion du livre.");
				return;
			}
			this.Close();
		}

		/// <summary>
		/// Bouton de fermeture de la fenetre
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		#endregion event

	}
}
