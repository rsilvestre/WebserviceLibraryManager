using System;
using System.Collections.Generic;
using System.Linq;
using WebsDAL;
using WebsBO;

namespace WebsBL {
	public static class DemandeAnnulationBL {
		public static List<DemandeAnnulationBO> SelectById(Int32 pDemandeAnnulationId) {
			List<DemandeAnnulationBO> lstResult;

			try {
				using (var demandeAnnulationDal = new DemandeAnnulationDAL(Util.GetConnection())) {
					lstResult = demandeAnnulationDal.DemandeAnnulationDAL_SelectById(pDemandeAnnulationId).ToList();
				}
			} catch (Exception ex) {
				throw;
			}

			return lstResult;
		}
	}
}
