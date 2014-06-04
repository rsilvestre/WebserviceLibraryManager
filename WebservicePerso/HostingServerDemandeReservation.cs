using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WebsFAC;

namespace WebservicePerso {
	public class HostingServerDemandeReservation {
		internal static ServiceHost serverDemandeReservation;

		public void StartServer() {
			serverDemandeReservation = new ServiceHost(typeof(DemandeReservationFAC));
			serverDemandeReservation.Open();
			Console.WriteLine("Server DemandeReservation Started");
		}

		public void StopServer() {
			if (serverDemandeReservation != null && serverDemandeReservation.State != CommunicationState.Closed) {
				serverDemandeReservation.Close();
			}
		}
	}
}
