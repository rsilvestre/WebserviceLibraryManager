﻿using System;
using System.ServiceModel;
using WebsFAC;

namespace WebservicePerso {
	public class HostingServerSessionManager {
		internal static ServiceHost serverSessionManager;

		public void StartServer() {
			serverSessionManager = new ServiceHost(typeof(SessionManagerFAC));
			serverSessionManager.Open();
			Console.WriteLine("Server : SessionManager Started");
		}

		public void StopServer() {
			if (serverSessionManager != null && serverSessionManager.State != CommunicationState.Closed) {
				serverSessionManager.Close();
			}
		}
	}
}
