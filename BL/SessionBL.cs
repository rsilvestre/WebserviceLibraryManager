using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using WebsDAL;

namespace WebsBL {
	public static class SessionBL {

		public static SessionBO OpenSession(string pUsername, string pPassword) {
			SessionBO sessionResult;
			try {
				using (SessionDAL sessionProxy = new SessionDAL(Util.GetConnection())) {
					List<SessionBO> lstSession = sessionProxy.SessionDAL_CreateSession(pUsername, pPassword).ToList();
					if (lstSession.Count() > 0) {
						sessionResult = lstSession[0];
						using (PersonneDAL sessionPersonne = new PersonneDAL(Util.GetConnection())) {
							PersonneBO personne = sessionPersonne.PersonneBO_SelectById(sessionResult.PersonneId).ToList()[0];
							sessionResult.Personne = personne;
						}
					} else {
						sessionResult = new SessionBO();
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return sessionResult;
		}
	}
}
