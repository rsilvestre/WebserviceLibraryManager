using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsFAC;
using System.ServiceModel;

namespace WebservicePerso {
	public class HostingServerLocation {
		internal static ServiceHost ServiceLocation = null;

		public void StartServer() {
			ServiceLocation = new ServiceHost(typeof(LocationFAC));
			ServiceLocation.Open();
			Console.WriteLine("Service : Location Started ");
		}

		public void StopServer() {
			if (ServiceLocation != null && ServiceLocation.State != CommunicationState.Closed) {
				ServiceLocation.Close();
			}
		}
	}
}
