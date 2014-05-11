using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebsBO;
using System.Net;

namespace WindowsFormsApplication1.Livre {
	public partial class LivreFormulaire : UserControl {

		public LivreFormulaire() {
			InitializeComponent();
		}

		public void SetForm(LivreBO pLivre) {
			CGlobalCache.actualBibliothequeChangeEventHandler += actualBibliothequeChange;
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
			System.Net.WebRequest webRequest = HttpWebRequest.Create(pLivre.RefLivre.ImageUrl);
			// Execute the request synchronuously
			HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

			// Create an image from the stream returned by the web request
			picBook.Image = new System.Drawing.Bitmap(webResponse.GetResponseStream());
		}

		private void actualBibliothequeChange(object value, EventArgs e) {
			BibliothequeBO objBibliothequeBO = (BibliothequeBO) value;
			cmbBibliotheque.SelectedItem = objBibliothequeBO;
		}

		/// <summary>
		/// Vérifie si des champs ont été modifiés
		/// </summary>
		/// <param name="ObjLivre"></param>
		public void CheckField(LivreBO ObjLivre) {
			if (ObjLivre.CreatedAt.ToShortDateString() != datePicker.Text) {
				ObjLivre.CreatedAt = DateTime.Parse(datePicker.Text);
			}
			if (!ObjLivre.RefLivre.ISBN.Equals(txtISBN.Text)) {
				ObjLivre.RefLivre.ISBN = txtISBN.Text;
			}
			if (!ObjLivre.RefLivre.Titre.Equals(txtTitle.Text)) {
				ObjLivre.RefLivre.Titre = txtTitle.Text;
			}
			if (!ObjLivre.RefLivre.Auteur.Equals(txtAuteur.Text)) {
				ObjLivre.RefLivre.Auteur = txtAuteur.Text;
			}
		}
	}
}
