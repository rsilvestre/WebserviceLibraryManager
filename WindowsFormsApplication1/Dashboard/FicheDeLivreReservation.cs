using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WebsBO;
using System.Net;

namespace WindowsFormsApplication1.Dashboard {
	public partial class FicheDeLivreReservation : UserControl {
		private readonly DashboardManager _dashboardManager;

		public FicheDeLivreReservation() {
			InitializeComponent();
		}

		public FicheDeLivreReservation(DashboardManager dashboardManager) : this() {
			_dashboardManager = dashboardManager;
		}

		internal void setFicheDeLivre(FicheLivreBO ficheLivre) {
			if (ficheLivre == null){
				return;
			}
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
			String newDemandeReservation = "", oldDemandeReservation = "";
			foreach (DemandeReservationBO objDr in LstDemandeReservation.OrderByDescending(xx => xx.CreatedAt)) {
				if (objDr.Valide == 1) {
					newDemandeReservation += ((newDemandeReservation == "") ? "": "\n" ) + "En cours: " + objDr.CreatedAt.ToShortDateString();
					bAnnuller = true;
				} else { 
					oldDemandeReservation += ((oldDemandeReservation == "") ? "": "\n" ) + "Passée: " + objDr.CreatedAt.ToShortDateString();
				}
			}
			lblOldReservationStatus.Text = oldDemandeReservation;
			lblNewReservationStatus.Text = newDemandeReservation;
			if (bAnnuller) {

			}
		}

		#region callback

		private void btnAnnuler_Click_1(object sender, EventArgs e) {
			_dashboardManager.AnnuleDemandeReservation((objDemandeAnnulation) => MessageBox.Show(String.Format(@"Votre demande de résevation {0} a bien été annulée", objDemandeAnnulation.DemandeReservation)));
		}

		#endregion callback
	}
}
