﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebservicePerso {
	class Program {
		static void Main(string[] args) {
			HostingServerClient clientServer = new HostingServerClient();
			HostingServerEmprunt empruntServer = new HostingServerEmprunt();
			HostingServerPersonne personneServer = new HostingServerPersonne();
			HostingServerRefLivre refLivreServer = new HostingServerRefLivre();
			HostingServerLivre livreServer = new HostingServerLivre();
			HostingServerLivreStatus livreStatusServer = new HostingServerLivreStatus();
			HostingServerBibliotheque bibliothequeServer = new HostingServerBibliotheque();
			HostingServerSessionManager sessionManagerServer = new HostingServerSessionManager();
			HostingServerAdministrateur administrateurServer = new HostingServerAdministrateur();
			HostingServerDemandeReservation demandeReservationServer = new HostingServerDemandeReservation();
			HostingServerDemandeAnnulation demandeAnnulationServer = new HostingServerDemandeAnnulation();
			HostingServerReservation reservationServer = new HostingServerReservation();
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
