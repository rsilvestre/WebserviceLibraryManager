using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WebsFAC;

namespace WebservicePerso {
	public class HostingServerLivre {
		internal static ServiceHost ServiceLivre;

		public void StartServer() {
			ServiceLivre = new ServiceHost(typeof(LivreFAC));
			ServiceLivre.Open();
			Console.WriteLine("Service : Livre Started ");
		}

		public void StopServer() {
			if (ServiceLivre != null && ServiceLivre.State != CommunicationState.Closed) {
				ServiceLivre.Close();
			}
		}
	}
}
