using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WebsBO;
using System.Net;

namespace WindowsFormsApplication1.Dashboard {
	public partial class FicheDeLivreReservation : UserControl {
		private DashboardManager _dashboardManager;

		public FicheDeLivreReservation() {
			InitializeComponent();
		}

		public FicheDeLivreReservation(DashboardManager dashboardManager) : this() {
			_dashboardManager = dashboardManager;
		}

		internal void setFicheDeLivre(FicheLivreBO ficheLivre) {
			lblTitre.Text = ficheLivre.RefLivre.Titre;
			webDescription.DocumentText = ficheLivre.RefLivre.Description;
			lblAuteurs.Text = ficheLivre.RefLivre.Auteur;
			lblPublication.Text = ficheLivre.RefLivre.Published.ToShortDateString();
			
			Action<String> GetImage = (imageUrl) => { 
				// Create a web request to the URL for the picture
				WebRequest webRequest = HttpWebRequest.Create(imageUrl);
				// Execute the request synchronuously
				HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

				// Create an image from the stream returned by the web request
				picBook.Image = new Bitmap(webResponse.GetResponseStream());
			};

			GetImage(ficheLivre.RefLivre.ImageUrl);

			Annulation(ficheLivre.LstDemandeReservation);
		}

		private void Annulation(List<DemandeReservationBO> LstDemandeReservation) {
			Boolean bAnnuller = false;
			String NewDemandeReservation = "", OldDemandeReservation = "";
			foreach (DemandeReservationBO objDr in LstDemandeReservation.OrderByDescending(xx => xx.CreatedAt)) {
				if (objDr.Valide == 1) {
					NewDemandeReservation += ((NewDemandeReservation == "") ? "": "\n" ) + "Réservation depuis: " + objDr.CreatedAt.ToShortDateString();
					bAnnuller = true;
				} else { 
					OldDemandeReservation += ((OldDemandeReservation == "") ? "": "\n" ) + "Ancienne réservation: " + objDr.CreatedAt.ToShortDateString();
				}
			}
			lblOldReservationStatus.Text = OldDemandeReservation;
			lblNewReservationStatus.Text = NewDemandeReservation;
			if (bAnnuller) {
				btnAnnuler.Visible = true;
			}
		}

		private void btnAnnuler_Click(object sender, EventArgs e) {
			_dashboardManager.AnnuleDemandeReservation();
		}
	}
}
