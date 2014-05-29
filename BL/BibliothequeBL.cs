using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using WebsDAL;

namespace WebsBL {
	public static class BibliothequeBL {

		public static List<BibliothequeBO> SelectAll() {
			List<BibliothequeBO> result;

			try {
				using (BibliothequeDAL bibliothequeProxy = new BibliothequeDAL(Util.GetConnection())) {
					result = bibliothequeProxy.BibliothequeDAL_SelectAll().ToList();
				}
			} catch (Exception ex) {
				throw;
			}

			return result;
		}

		public static List<BibliothequeBO> SelectByAdministrateurId(Int32 pAdministrateurId) {
			List<BibliothequeBO> result;

			try {
				using (BibliothequeDAL bibliothequeProxy = new BibliothequeDAL(Util.GetConnection())) {
					result = bibliothequeProxy.BibliothequeDAL_SelectByAdministrateurId(pAdministrateurId).ToList();
				}
			} catch (Exception ex) {
				throw;
			}

			return result;
		}

		public static BibliothequeBO SelectById(Int32 pAdministrateurId) {
			BibliothequeBO result = null;

			try {
				using (BibliothequeDAL bibliothequeProxy = new BibliothequeDAL(Util.GetConnection())) {
					List<BibliothequeBO> lstBibliotheque = bibliothequeProxy.BibliothequeDAL_SelectById(pAdministrateurId).ToList();
					if (lstBibliotheque.Count() > 0) {
						result = lstBibliotheque[0];
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return result;
		}
	}
}
