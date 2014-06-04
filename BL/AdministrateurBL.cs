using System;
using System.Collections.Generic;
using System.Linq;
using WebsBO;
using WebsDAL;

namespace WebsBL {
	public static class AdministrateurBL {

		public static AdministrateurBO SelectById(Int32 pAdministrateurId) {
			AdministrateurBO administrateurResult = null;
			try {
				using (var administrateurDal = new AdministrateurDAL(Util.GetConnection())) {
					var lstAdministrateur = administrateurDal.AdministrateurDAL_SelectById(pAdministrateurId).ToList();
					if (lstAdministrateur.Any()) {
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
