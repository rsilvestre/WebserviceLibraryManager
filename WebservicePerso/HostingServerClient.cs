using System;
using System.ServiceModel;
using WebsFAC;

namespace WebservicePerso {
	class HostingServerClient {
		internal static ServiceHost ServiceClient;

		public void StartServer() {
			ServiceClient = new ServiceHost(typeof(ClientFAC));
			ServiceClient.Open();
			Console.WriteLine("Service : Client Started");
		
		}

		public void StopServer() {
			if (ServiceClient != null && ServiceClient.State != CommunicationState.Closed) {
				ServiceClient.Close();
			}
		}

	}
}
