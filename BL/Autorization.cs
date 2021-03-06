﻿using System;
using System.Linq;
using WebsDAL;

namespace WebsBL {
	public static class Autorization {

		public enum Role { NONE, CLIENT, ADMIN, ALL }
		static public Boolean Validate(String Token, Role pRole) {
			if (Role.ALL == pRole) {
				return true;
			}

			var boolResult = false;

			try {
				using(var sessionManagerDal = new SessionManagerDAL(Util.GetConnection())) {
					var lstObjSessionManager = sessionManagerDal.SessionManagerDAL_ById(Token).ToList();
					if (lstObjSessionManager.Count() == 1) {
						switch ((Role)lstObjSessionManager[0].UserRole) {
							case Role.ADMIN: case Role.CLIENT:
									boolResult = true;
								break;
							case Role.NONE:
								boolResult = false;
								break;
							default:
								throw new Exception("Not accessible, unknow userRole");
						}
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return boolResult;
		}
	}
}
