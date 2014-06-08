using System;
using System.ServiceModel;
using WebsFAC;

namespace WebservicePerso {
	public class HostingServerLivreStatus {
		internal static ServiceHost ServiceLivreStatus;

		public void StartServer() {
			ServiceLivreStatus = new ServiceHost(typeof(LivreStatusFAC));
			ServiceLivreStatus.Open();
			Console.WriteLine("Service : LivreStatus Started");
		}

		public void StopServer() {
			if (ServiceLivreStatus != null && ServiceLivreStatus.State != CommunicationState.Closed) {
				ServiceLivreStatus.Close();
			}
		}
	}
}
