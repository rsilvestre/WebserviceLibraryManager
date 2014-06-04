using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WebsFAC;

namespace WebservicePerso {
	class HostingServerPersonne {
		internal static ServiceHost ServicePersonne;

		public void StartServer() {
			ServicePersonne = new ServiceHost(typeof(PersonneFAC));
			ServicePersonne.Open();
			Console.WriteLine("Service: Personne Started");
		}

		public void StopServer() {
			if (ServicePersonne != null && ServicePersonne.State != CommunicationState.Closed) {
				ServicePersonne.Close();
			}
		}
	}
}
