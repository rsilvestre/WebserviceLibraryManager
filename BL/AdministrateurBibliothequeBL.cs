using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using WebsDAL;

namespace WebsBL {
	public static class AdministrateurBibliothequeBL {
		public static List<AdministrateurBibliothequeBO> ByAdministrateur(String Token, AdministrateurBO pObjAdministrateur) {
			if (!Autorization.Validate(Token)) {
				return new List<AdministrateurBibliothequeBO>();
			}
			List<AdministrateurBibliothequeBO> administrateurBibliothequeResult;

			try {
				using (AdministrateurBibliothequeDAL proxyAdministrateurBibliotheque = new AdministrateurBibliothequeDAL(Util.GetConnection())) {
					administrateurBibliothequeResult = proxyAdministrateurBibliotheque.AministrateurBibliothequeDAL_SelectByAdminId(pObjAdministrateur.AdministrateurId).ToList();
				}
			} catch (Exception ex) {
				throw;
			}

			return administrateurBibliothequeResult;
		}
		public static List<AdministrateurBibliothequeBO> ByBibliotheque(String Token, BibliothequeBO pObjBibliotheque) {
			if (!Autorization.Validate(Token)) {
				return new List<AdministrateurBibliothequeBO>();
			}
			List<AdministrateurBibliothequeBO> administrateurBibliothequeResult;

			try {
				using (AdministrateurBibliothequeDAL proxyAdministrateurBibliotheque = new AdministrateurBibliothequeDAL(Util.GetConnection())) {
					administrateurBibliothequeResult = proxyAdministrateurBibliotheque.AministrateurBibliothequeDAL_SelectByBiblioId(pObjBibliotheque.BibliothequeId).ToList();
				}
			} catch (Exception ex) {
				throw;
			}

			return administrateurBibliothequeResult;
		}
	}
}
