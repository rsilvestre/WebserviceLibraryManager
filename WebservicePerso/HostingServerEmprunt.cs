﻿using System;
using WebsFAC;
using System.ServiceModel;

namespace WebservicePerso {
	public class HostingServerEmprunt {
		internal static ServiceHost ServiceEmprunt = null;

		public void StartServer() {
			ServiceEmprunt = new ServiceHost(typeof(EmpruntFAC));
			ServiceEmprunt.Open();
			Console.WriteLine("Service : Emprunt Started ");
		}

		public void StopServer() {
			if (ServiceEmprunt != null && ServiceEmprunt.State != CommunicationState.Closed) {
				ServiceEmprunt.Close();
			}
		}
	}
}
