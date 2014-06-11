using System;
using System.ServiceModel;
using WebsFAC;

namespace WebservicePerso {
	class HostingServerItem {
		internal static ServiceHost ServiceItem;

		public void StartServer() {
			ServiceItem = new ServiceHost(typeof(ItemFAC));
			ServiceItem.Open();
			Console.WriteLine("Service : Item Started");
		
		}

		public void StopServer() {
			if (ServiceItem != null && ServiceItem.State != CommunicationState.Closed) {
				ServiceItem.Close();
			}
		}

	}
}
