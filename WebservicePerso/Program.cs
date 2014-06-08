using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebservicePerso {
	class Program {
		static void Main(string[] args) {
			var clientServer = new HostingServerClient();
			var empruntServer = new HostingServerEmprunt();
			var personneServer = new HostingServerPersonne();
			var refLivreServer = new HostingServerRefLivre();
			var livreServer = new HostingServerLivre();
			var livreStatusServer = new HostingServerLivreStatus();
			var bibliothequeServer = new HostingServerBibliotheque();
			var sessionManagerServer = new HostingServerSessionManager();
			var administrateurServer = new HostingServerAdministrateur();
			var demandeReservationServer = new HostingServerDemandeReservation();
			var demandeAnnulationServer = new HostingServerDemandeAnnulation();
			var reservationServer = new HostingServerReservation();
			Console.WriteLine("Server Started");
			clientServer.StartServer();
			empruntServer.StartServer();
			personneServer.StartServer();
			refLivreServer.StartServer();
			livreServer.StartServer();
			livreStatusServer.StartServer();
			bibliothequeServer.StartServer();
			sessionManagerServer.StartServer();
			administrateurServer.StartServer();
			demandeReservationServer.StartServer();
			demandeAnnulationServer.StartServer();
			reservationServer.StartServer();
			Console.WriteLine("Press a key to stop the Service");
			Console.ReadKey();
			clientServer.StopServer();
			empruntServer.StopServer();
			personneServer.StopServer();
			refLivreServer.StopServer();
			livreServer.StopServer();
			livreStatusServer.StopServer();
			bibliothequeServer.StopServer();
			sessionManagerServer.StopServer();
			administrateurServer.StopServer();
			demandeReservationServer.StopServer();
			demandeAnnulationServer.StopServer();
			reservationServer.StopServer();
			Console.WriteLine("Server Stopped");


		}
	}
}
