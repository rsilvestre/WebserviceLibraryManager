using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsDAL;
using WebsBO;

namespace WebsBL {
	public static class EmpruntBL {
		public static List<EmpruntBO> SelectAll() {
			List<EmpruntBO> lstResult;

			try {
				using (EmpruntDAL empruntDal = new EmpruntDAL(Util.GetConnection())) {
					lstResult = empruntDal.EmpruntDAL_SelectAll().ToList();
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstResult;
		}

		public static EmpruntBO SelectById(Int32 pId) {
			EmpruntBO result = null;
			try {
				using (EmpruntDAL empruntDal = new EmpruntDAL(Util.GetConnection())) {
					result = (EmpruntBO)empruntDal.EmpruntDAL_SelectById(pId);
				}
			} catch (Exception Ex) {
				throw;
			}
			return result;
		}

		internal static List<EmpruntBO> SelectForClientByLivreId(int pClientId, int pLivreId) {
			List<EmpruntBO> lstResult;

			try {
				using (EmpruntDAL empruntDal = new EmpruntDAL(Util.GetConnection())) {
					lstResult = empruntDal.EmpruntDAL_SelectForUserByLivreId(pClientId, pLivreId).ToList();
					foreach (EmpruntBO objEmprunt in lstResult) {
						objEmprunt.Livre = LivreBL.SelectById(objEmprunt.LivreId);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstResult;
		}
	}
}
