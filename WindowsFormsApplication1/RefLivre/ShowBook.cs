using System;
using System.Drawing;
using System.Windows.Forms;
using WebsBO;
using System.Net;

namespace WindowsFormsApplication1.RefLivre {
	public partial class ShowBook : UserControl {
		public ShowBook() {
			InitializeComponent();
		}

		public void SetLivre(RefLivreBO pRefLivre) {
			lblTitle.Text = pRefLivre.Titre;
			lblAuthor.Text = String.Format( @"Author: {0}", pRefLivre.Auteur);
			webDescription.DocumentText = pRefLivre.Description;
			lblTimestamp.Text = String.Format(@"Published: {0}", pRefLivre.Published.ToShortDateString());

			// Create a web request to the URL for the picture
			var webRequest = WebRequest.Create(pRefLivre.ImageUrl);
			// Execute the request synchronuously
			var webResponse = (HttpWebResponse)webRequest.GetResponse();

			// Create an image from the stream returned by the web request
			picBook.Image = new Bitmap(webResponse.GetResponseStream());

			// Finally, close the request
			//webResponse.Close();

			Visible = true;
		}
	}
}
