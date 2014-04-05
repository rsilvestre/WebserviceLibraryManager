using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebservicePerso {
	class Program {
		static void Main(string[] args) {
			HostingServerClient clientServer = new HostingServerClient();
			HostingServerEmprunt locationServer = new HostingServerEmprunt();
			HostingServerPersonne personneServer = new HostingServerPersonne();
			Console.WriteLine("Server Started");
			clientServer.StartServer();
			locationServer.StartServer();
			personneServer.StartServer();
			Console.WriteLine("Press a key to stop the Service");
			Console.ReadKey();
			clientServer.StopServer();
			locationServer.StopServer();
			personneServer.StopServer();
			Console.WriteLine("Server Stopped");


		}
	}
}
