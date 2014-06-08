using System;
using System.ServiceModel;
using WebsFAC;

namespace WebservicePerso {
	public class HostingServerAdministrateur {
		internal static ServiceHost serverAdministrateur;

		public void StartServer() {
			serverAdministrateur = new ServiceHost(typeof(AdministrateurFAC));
			serverAdministrateur.Open();
			Console.WriteLine("Server : Administrateur Started");
		}

		public void StopServer() {
			if (serverAdministrateur != null && serverAdministrateur.State != CommunicationState.Closed) {
				serverAdministrateur.Close();
			}
		}
	}
}
