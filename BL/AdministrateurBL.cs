using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using WebsDAL;

namespace WebsBL {
	public static class AdministrateurBL {

		public static AdministrateurBO SelectById(String Token, Int32 pAdministrateurId) {
			if (!Autorization.Validate(Token)) {
				return new AdministrateurBO();
			}
			AdministrateurBO administrateurResult = null;
			try {
				using (AdministrateurDAL administrateurDal = new AdministrateurDAL(Util.GetConnection())) {
					List<AdministrateurBO> lstAdministrateur = administrateurDal.AdministrateurDAL_SelectById(pAdministrateurId).ToList();
					if (lstAdministrateur.Count() > 0) {
						administrateurResult = lstAdministrateur[0];
						administrateurResult.LstBibliotheque = BibliothequeBL.SelectByAdministrateurId(Token, administrateurResult.AdministrateurId);
					}
				}
			} catch (Exception ex) {
				throw;
			}
			return administrateurResult;
		}
	}
}
