using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using WebsDAL;

namespace WebsBL {
	public static class SessionManagerBL {

		public static SessionManagerBO OpenSession(string pUsername, string pPassword) {
			SessionManagerBO sessionResult = null;
			try {
				using (SessionManagerDAL sessionProxy = new SessionManagerDAL(Util.GetConnection())) {
					List<SessionManagerBO> lstSession = sessionProxy.SessionManagerDAL_CreateSession(pUsername, pPassword).ToList();
					if (lstSession.Count() == 1) {
						sessionResult = lstSession[0];
						PersonneBO objPersonne = PersonneBL.SelectById(sessionResult.Token, sessionResult.PersonneId);
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
