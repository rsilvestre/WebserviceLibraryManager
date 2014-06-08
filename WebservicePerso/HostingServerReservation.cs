using System;
using WebsFAC;
using System.ServiceModel;

namespace WebservicePerso {
	public class HostingServerReservation {
		internal static ServiceHost ServiceReservation = null;

		public void StartServer() {
			ServiceReservation = new ServiceHost(typeof(ReservationFAC));
			ServiceReservation.Open();
			Console.WriteLine("Service : Reservation Started ");
		}

		public void StopServer() {
			if (ServiceReservation != null && ServiceReservation.State != CommunicationState.Closed) {
				ServiceReservation.Close();
			}
		}
	}
}
