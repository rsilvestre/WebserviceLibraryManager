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

		internal void SetFicheDeLivre(DemandeReservationBO pDemandeReservation, ReservationBO objReservationResult) {
			if (pDemandeReservation == null) {
				return;
			}
			lblTitre.Text = pDemandeReservation.RefLivre.Titre;
			webDescription.DocumentText = pDemandeReservation.RefLivre.Description;
			lblAuteurs.Text = pDemandeReservation.RefLivre.Auteur;
			lblPublication.Text = pDemandeReservation.RefLivre.Published.ToShortDateString();
			
			Action<String> getImage = (imageUrl) => { 
				// Create a web request to the URL for the picture
				var webRequest = WebRequest.Create(imageUrl);
				// Execute the request synchronuously
				var webResponse = (HttpWebResponse)webRequest.GetResponse();

				// Create an image from the stream returned by the web request
				// ReSharper disable AssignNullToNotNullAttribute
				picBook.Image = new Bitmap(webResponse.GetResponseStream());
				// ReSharper restore AssignNullToNotNullAttribute
			};

			lblBibliotheque.Text = objReservationResult != null ? objReservationResult.Emprunt.Livre.Bibliotheque.ToString() : "";

			getImage(pDemandeReservation.RefLivre.ImageUrl);

			Annulation(pDemandeReservation);
		}

		private void Annulation(DemandeReservationBO pDemandeReservation) {
			String newDemandeReservation = "", oldDemandeReservation = "";
			foreach (DemandeReservationBO objDr in CGlobalCache.LstNewDemandeReservationByClient.ToList().FindAll(xx => xx.RefLivreId == pDemandeReservation.RefLivreId && xx.Valide == 1).OrderByDescending(xx => xx.CreatedAt)) {
				newDemandeReservation += ((newDemandeReservation == "") ? "" : "\n") + "En cours: " + objDr.CreatedAt.ToShortDateString();
			}
			foreach (DemandeReservationBO objDr in CGlobalCache.LstOldDemandeReservationByClient.ToList().FindAll(xx => xx.RefLivreId == pDemandeReservation.RefLivreId && xx.Valide == 1).OrderByDescending(xx => xx.CreatedAt)) {
				oldDemandeReservation += ((oldDemandeReservation == "") ? "": "\n" ) + "Passée: " + objDr.CreatedAt.ToShortDateString();
			}
			lblOldReservationStatus.Text = oldDemandeReservation;
			lblNewReservationStatus.Text = newDemandeReservation;
		}

		#region callback

		private void btnAnnuler_Click_1(object sender, EventArgs e) {
			_dashboardManager.AnnuleDemandeReservation((objDemandeAnnulation) => MessageBox.Show(String.Format(@"Votre demande de résevation {0} a bien été annulée", objDemandeAnnulation.DemandeReservation)));
		}

		#endregion callback
	}
}
