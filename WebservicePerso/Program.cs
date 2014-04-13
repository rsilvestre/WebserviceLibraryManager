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
			HostingServerRefLivre refLivreServer = new HostingServerRefLivre();
			HostingServerLivre livreServer = new HostingServerLivre();
			HostingServerLivreStatus livreStatusServer = new HostingServerLivreStatus();
			HostingServerBibliotheque bibliothequeServer = new HostingServerBibliotheque();
			HostingServerSession sessionServer = new HostingServerSession();
			HostingServerAdministrateur administrateurServer = new HostingServerAdministrateur();
			Console.WriteLine("Server Started");
			clientServer.StartServer();
			locationServer.StartServer();
			personneServer.StartServer();
			refLivreServer.StartServer();
			livreServer.StartServer();
			livreStatusServer.StartServer();
			bibliothequeServer.StartServer();
			sessionServer.StartServer();
			administrateurServer.StartServer();
			Console.WriteLine("Press a key to stop the Service");
			Console.ReadKey();
			clientServer.StopServer();
			locationServer.StopServer();
			personneServer.StopServer();
			refLivreServer.StopServer();
			livreServer.StopServer();
			livreStatusServer.StopServer();
			bibliothequeServer.StopServer();
			sessionServer.StopServer();
			administrateurServer.StopServer();
			Console.WriteLine("Server Stopped");


		}
	}
}
