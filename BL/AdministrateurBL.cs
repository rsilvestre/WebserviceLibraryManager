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
			AdministrateurBO administrateurResult;
			try {
				using (AdministrateurDAL administrateurDal = new AdministrateurDAL(Util.GetConnection())) {
					List<AdministrateurBO> lstAdministrateur = administrateurDal.AdministrateurDAL_SelectById(pAdministrateurId).ToList();
					if (lstAdministrateur.Count() > 0) {
						administrateurResult = lstAdministrateur[0];
					} else {
						administrateurResult = new AdministrateurBO();
					}
				}
			} catch (Exception ex) {
				throw;
			}
			return administrateurResult;
		}
	}
}
