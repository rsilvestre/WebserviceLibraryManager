﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using WebsBO;

namespace WindowsFormsApplication1.Dashboard {
	public partial class FicheDeLivre : UserControl {
		private DashboardManager dashboardManager;

		public FicheDeLivre() {
			InitializeComponent();
		}

		public FicheDeLivre(DashboardManager dashboardManager) : this() {
			this.dashboardManager = dashboardManager;
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
			
			String NewDemandeReservation = "", OldDemandeReservation = "";
			foreach (DemandeReservationBO objDr in ficheLivre.LstDemandeReservation.OrderByDescending(xx => xx.CreatedAt)) {
				if (objDr.Valide == 1) {
					NewDemandeReservation += ((NewDemandeReservation == "") ? "": "\n" ) + "Réservation depuis: " + objDr.CreatedAt.ToShortDateString();
				} else { 
					OldDemandeReservation += ((OldDemandeReservation == "") ? "": "\n" ) + "Ancienne réservation: " + objDr.CreatedAt.ToShortDateString();
				}
			}
			lblReservationStatus.Text = NewDemandeReservation + "\n" + OldDemandeReservation;

		}
	}
}
