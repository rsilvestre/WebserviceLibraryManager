using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WebsFAC;

namespace WebservicePerso {
	public class HostingServerRefLivre {
		internal static ServiceHost ServiceRefLivre;

		public void StartServer() {
			ServiceRefLivre = new ServiceHost(typeof(RefLivreFAC));
			ServiceRefLivre.Open();
			Console.WriteLine("Service : RefLivre Started ");
		}

		public void StopServer() {
			if (ServiceRefLivre != null && ServiceRefLivre.State != CommunicationState.Closed) {
				ServiceRefLivre.Close();
			}
		}
	}
}
