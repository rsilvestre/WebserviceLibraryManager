﻿using System;
using System.ServiceModel;
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
