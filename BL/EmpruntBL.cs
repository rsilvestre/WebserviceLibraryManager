using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsDAL;
using WebsBO;

namespace WebsBL {
	public static class EmpruntBL {
		public static List<EmpruntBO> SelectAll(String Token) {
			if (!Autorization.Validate(Token)) {
				return new List<EmpruntBO>();
			}
			List<EmpruntBO> lstResult;

			try {
				using (EmpruntDAL empruntDal = new EmpruntDAL(Util.GetConnection())) {
					lstResult = empruntDal.EmpruntBO_SelectAll().ToList();
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstResult;
		}

		public static EmpruntBO SelectById(String Token, Int32 pId) {
			if (!Autorization.Validate(Token)) {
				return new EmpruntBO();
			}
			EmpruntBO result = null;
			try {
				using (EmpruntDAL empruntDal = new EmpruntDAL(Util.GetConnection())) {
					result = (EmpruntBO)empruntDal.EmpruntBO_SelectById(pId);
				}
			} catch (Exception Ex) {
				throw;
			}
			return result;
		}
	}
}
