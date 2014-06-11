using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using WebsBO;

namespace WindowsFormsApplication1.Dashboard {
	public partial class FicheDeLivre : UserControl {
		private readonly DashboardManager _dashboardManager;

		public FicheDeLivre() {
			InitializeComponent();
		}

		public FicheDeLivre(DashboardManager dashboardManager) : this() {
			this._dashboardManager = dashboardManager;
		}

		internal void SetFicheDeLivre(LivreBO pLivreBo, FicheLivreBO ficheLivre) {
			if (ficheLivre == null){
				MessageBox.Show("Erreur lors de la récupération de la fiche du livre!");
				return;
			}
			lblReservationStatus.Visible = false;
			lblReservationTitle.Visible = false;

			lblTitre.Text = ficheLivre.RefLivre.Titre;
			webDescription.DocumentText = ficheLivre.RefLivre.Description;
			lblAuteurs.Text = ficheLivre.RefLivre.Auteur;
			lblPublication.Text = ficheLivre.RefLivre.Published.ToShortDateString();

			Action<String> getImage = (imageUrl) => { 
				// Create a web request to the URL for the picture
				var webRequest = WebRequest.Create(imageUrl);
				// Execute the request synchronuously
				var webResponse = (HttpWebResponse)webRequest.GetResponse();

				// Create an image from the stream returned by the web request
				picBook.Image = new Bitmap(webResponse.GetResponseStream());
			};

			getImage(ficheLivre.RefLivre.ImageUrl);

			lblBibliotheque.Text = pLivreBo.Bibliotheque.BibliothequeName;
			if (ficheLivre.LstEmprunt.Any()){
				var lastEmpruntState = ficheLivre.LstEmprunt[ficheLivre.LstEmprunt.Count() - 1];
				lblEmpruntStatus.Text = lastEmpruntState.Transition + "\n" + lastEmpruntState.CreatedAt.ToShortDateString();
			} else{
				lblEmpruntStatus.Text = "";
			}

			String newDemandeReservation = "", oldDemandeReservation = "";
			foreach (var objDr in ficheLivre.LstDemandeReservation.OrderByDescending(xx => xx.CreatedAt)) {
				if (objDr.Valide == 1) {
					newDemandeReservation += ((newDemandeReservation == "") ? "": "\n" ) + "Depuis: " + objDr.CreatedAt.ToShortDateString();
				} else { 
					oldDemandeReservation += ((oldDemandeReservation == "") ? "": "\n" ) + "Anciennes demandes: " + objDr.CreatedAt.ToShortDateString();
				}
			}
			lblDemandeReservationStatus.Text = newDemandeReservation + "\n" + oldDemandeReservation;

			var empruntByClient = CGlobalCache.LstEmpruntByClient.LastOrDefault(xx => xx.Livre.RefLivreId == ficheLivre.RefLivre.RefLivreId);
			if (empruntByClient != null && empruntByClient.State == "emp") {
				lblEmpruntStatus.Text = String.Format("Emprunté depuis le: {0}",empruntByClient.CreatedAt.ToShortDateString());
			} else if (empruntByClient != null && empruntByClient.State == "res") {
				lblEmpruntStatus.Text = String.Format("Reservé depuis le: {0}",empruntByClient.CreatedAt.ToShortDateString());
			} else if (empruntByClient != null && empruntByClient.State == "reg") {
				lblEmpruntStatus.Text = String.Format("Dernier emprunt le: {0}",empruntByClient.CreatedAt.ToShortDateString());
			} else{
				lblEmpruntStatus.Text = "";
			}

		}

		internal void SetFicheDeLivre(EmpruntBO pEmpruntBo) {
			lblReservationStatus.Visible = false;
			lblReservationTitle.Visible = false;

			lblTitre.Text = pEmpruntBo.Livre.RefLivre.Titre;
			webDescription.DocumentText = pEmpruntBo.Livre.RefLivre.Description;
			lblAuteurs.Text = pEmpruntBo.Livre.RefLivre.Auteur;
			lblPublication.Text = pEmpruntBo.Livre.RefLivre.Published.ToShortDateString();

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

			getImage(pEmpruntBo.Livre.RefLivre.ImageUrl);

			lblBibliotheque.Text = pEmpruntBo.Livre.Bibliotheque.ToString();
			
			String newDemandeReservation = "", oldDemandeReservation = "";
			foreach (var objDr in pEmpruntBo.LstDemandeReservation.OrderByDescending(xx => xx.CreatedAt)) {
				if (objDr.Valide == 1) {
					newDemandeReservation += ((newDemandeReservation == "") ? "": "\n" ) + "Réservation depuis: " + objDr.CreatedAt.ToShortDateString();
				} else { 
					oldDemandeReservation += ((oldDemandeReservation == "") ? "": "\n" ) + "Ancienne réservation: " + objDr.CreatedAt.ToShortDateString();
				}
			}
			lblDemandeReservationStatus.Text = newDemandeReservation + "\n" + oldDemandeReservation;

			if (pEmpruntBo.State == "emp") {
				var prixTotal = (((DateTime.Now - pEmpruntBo.CreatedAt).Days < 28) ? Math.Ceiling(((double)((DateTime.Now - pEmpruntBo.CreatedAt).Days + 1)/7)) : (Math.Ceiling(((double)((DateTime.Now - pEmpruntBo.CreatedAt).Days + 1)/7)) + (Math.Ceiling(((double)(28 - ((DateTime.Now - pEmpruntBo.CreatedAt).Days + 1))/7)))));
				lblEmpruntStatus.Text = String.Format("Créé le: {0}\nJours d'emprunt restant: {1}\nMontant prévisionnel: {2:C}", pEmpruntBo.CreatedAt.ToShortDateString(), (28 - ((DateTime.Now - pEmpruntBo.CreatedAt).Days)).ToString(CultureInfo.InvariantCulture), prixTotal);
			} else if (pEmpruntBo.State == "reg") {
				lblEmpruntStatus.Text = String.Format("Date de retour le: {0}", pEmpruntBo.CreatedAt.ToShortDateString());
			} else {
				lblEmpruntStatus.Text = "";
			}

		}
	}
}
