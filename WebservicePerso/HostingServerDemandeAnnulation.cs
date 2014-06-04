using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WebsFAC;

namespace WebservicePerso {
	public class HostingServerDemandeAnnulation {
		internal static ServiceHost serverDemandeAnnulation;

		public void StartServer() {
			serverDemandeAnnulation = new ServiceHost(typeof(DemandeAnnulationFAC));
			serverDemandeAnnulation.Open();
			Console.WriteLine("Server : DemandeAnnulation Started");
		}

		public void StopServer() {
			if (serverDemandeAnnulation != null && serverDemandeAnnulation.State != CommunicationState.Closed) {
				serverDemandeAnnulation.Close();
			}
		}
	}
}
