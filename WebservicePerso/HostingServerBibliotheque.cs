﻿using System;
using System.ServiceModel;
using WebsFAC;

namespace WebservicePerso {
	public class HostingServerBibliotheque {
		internal static ServiceHost serverBibliotheque;

		public void StartServer() {
			serverBibliotheque = new ServiceHost(typeof(BibliothequeFAC));
			serverBibliotheque.Open();
			Console.WriteLine("Server : Bibliotheque Started");
		}

		public void StopServer() {
			if (serverBibliotheque != null && serverBibliotheque.State != CommunicationState.Closed) {
				serverBibliotheque.Close();
			}
		}


	}
}
