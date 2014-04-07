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

namespace WindowsFormsApplication1.RefLivre {
	public partial class ShowBook : UserControl {
		public ShowBook() {
			InitializeComponent();
		}

		public void setLivre(RefLivreBO pRefLivre) {
			lblTitle.Text = pRefLivre.Titre;
			lblAuthor.Text = String.Format( @"Author: {0}", pRefLivre.Auteur);
			lblTimestamp.Text = String.Format(@"Published: {0}", pRefLivre.Published.ToShortDateString());
			webDescription.DocumentText = pRefLivre.Description;

			// Create a web request to the URL for the picture
			System.Net.WebRequest webRequest = HttpWebRequest.Create(pRefLivre.ImageUrl);
			// Execute the request synchronuously
			HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

			// Create an image from the stream returned by the web request
			picBook.Image = new System.Drawing.Bitmap(webResponse.GetResponseStream());

			// Finally, close the request
			//webResponse.Close();

			this.Visible = true;
		}
	}
}
