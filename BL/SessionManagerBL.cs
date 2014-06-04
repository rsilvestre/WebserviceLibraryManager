using System;
using System.Collections.Generic;
using System.Linq;
using WebsBO;
using WebsDAL;

namespace WebsBL {
	public static class SessionManagerBL {

		public static SessionManagerBO OpenSession(string pUsername, string pPassword) {
			SessionManagerBO sessionResult = null;
			try {
				using (var sessionProxy = new SessionManagerDAL(Util.GetConnection())) {
					var lstSession = sessionProxy.SessionManagerDAL_CreateSession(pUsername, pPassword).ToList();
					if (lstSession.Count() == 1) {
						sessionResult = lstSession[0];
						var objPersonne = PersonneBL.SelectById(sessionResult.PersonneId);
						//using (PersonneDAL sessionPersonne = new PersonneDAL(Util.GetConnection())) {
						//	PersonneBO personne = sessionPersonne.PersonneBO_SelectById(sessionResult.PersonneId).ToList()[0];
						//	sessionResult.Personne = personne;
						sessionResult.Personne = objPersonne;
						sessionResult.IsAdministrateur = objPersonne.Administrateur != null;
						//}
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return sessionResult;
		}
	}
}
