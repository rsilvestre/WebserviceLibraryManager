using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using WebsDAL;

namespace WebsBL {
	public static class AdministrateurBL {

		public static AdministrateurBO SelectById(Int32 pAdministrateurId) {
			AdministrateurBO administrateurResult = null;
			try {
				using (AdministrateurDAL administrateurDal = new AdministrateurDAL(Util.GetConnection())) {
					List<AdministrateurBO> lstAdministrateur = administrateurDal.AdministrateurDAL_SelectById(pAdministrateurId).ToList();
					if (lstAdministrateur.Count() > 0) {
						administrateurResult = lstAdministrateur[0];
						administrateurResult.LstBibliotheque = BibliothequeBL.SelectByAdministrateurId(administrateurResult.AdministrateurId);
					}
				}
			} catch (Exception ex) {
				throw;
			}
			return administrateurResult;
		}
	}
}
