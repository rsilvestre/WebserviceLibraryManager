using System;
using System.Drawing;
using System.Windows.Forms;
using WebsBO;
using System.Net;

namespace WindowsFormsApplication1.Livre {
	public partial class LivreFormulaire : UserControl {

		public LivreFormulaire() {
			InitializeComponent();
		}

		public void SetForm(LivreBO pLivre) {
			CGlobalCache.actualBibliothequeChangeEventHandler += ActualBibliothequeChange;
			cmbBibliotheque.Items.AddRange(CGlobalCache.SessionManager.Personne.Administrateur.LstBibliotheque.ToArray());
			cmbBibliotheque.SelectedItem = CGlobalCache.ActualBibliotheque;

			txtAuteur.Text = pLivre.RefLivre.Auteur;
			txtRef.Text = pLivre.InternalReference;
			//txtBibliotheque.Text = pLivre.Bibliotheque.ToString();
			cmbBibliotheque.SelectedItem = pLivre.Bibliotheque;
			//txtBibliotheque.Text = frmMdi.Bibliotheque.ToString();
			txtTitle.Text = pLivre.RefLivre.Titre;
			txtISBN.Text = pLivre.RefLivre.ISBN;
			webDescription.DocumentText = pLivre.RefLivre.Description;
			// Sensé permettre l'édition du texte
			//webDescription.Document.DomDocument.GetType().GetProperty("designMode").SetValue(webDescription.Document.DomDocument, "On", null);
			datePicker.Text = pLivre.RefLivre.Published.ToShortDateString();

			// Create a web request to the URL for the picture
			WebRequest webRequest = WebRequest.Create(pLivre.RefLivre.ImageUrl);
			// Execute the request synchronuously
			var webResponse = (HttpWebResponse)webRequest.GetResponse();

			// Create an image from the stream returned by the web request
			picBook.Image = new Bitmap(webResponse.GetResponseStream());
		}

		private void ActualBibliothequeChange(object value, EventArgs e) {
			var objBibliothequeBo = (BibliothequeBO) value;
			cmbBibliotheque.SelectedItem = objBibliothequeBo;
		}

		/// <summary>
		/// Vérifie si des champs ont été modifiés
		/// </summary>
		/// <param name="objLivre"></param>
		public void CheckField(LivreBO objLivre) {
			if (objLivre.CreatedAt.ToShortDateString() != datePicker.Text) {
				objLivre.CreatedAt = DateTime.Parse(datePicker.Text);
			}
			if (!objLivre.RefLivre.ISBN.Equals(txtISBN.Text)) {
				objLivre.RefLivre.ISBN = txtISBN.Text;
			}
			if (!objLivre.RefLivre.Titre.Equals(txtTitle.Text)) {
				objLivre.RefLivre.Titre = txtTitle.Text;
			}
			if (!objLivre.RefLivre.Auteur.Equals(txtAuteur.Text)) {
				objLivre.RefLivre.Auteur = txtAuteur.Text;
			}
		}
	}
}
