using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsDAL;
using WebsBO;

namespace WebsBL {
	public static class Autorization {
		static public Boolean Validate(String Token) {
			Boolean boolResult = false;

			try {
				using(SessionManagerDAL sessionManagerDal = new SessionManagerDAL(Util.GetConnection())) {
					List<SessionManagerBO> lstObjSessionManager = sessionManagerDal.SessionManagerDAL_ById(Token).ToList();
					if (lstObjSessionManager.Count() > 0) {
						boolResult = true;
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return boolResult;
		}
	}
}
