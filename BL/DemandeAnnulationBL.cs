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
		public static DemandeAnnulationBO InsertDemandeAnnulation(Int32 pAdministrateurId, Int32 pDemandeReservationId) {
			DemandeAnnulationBO result = null;

			try {
				using (var demandeAnnulationDal = new DemandeAnnulationDAL(Util.GetConnection())) {
					var lstResult = demandeAnnulationDal.DemandeAnnulationDAL_InsertDemandeAnnulation(pAdministrateurId, pDemandeReservationId).ToList();
					if (lstResult.Count() == 1){
						result = lstResult[0];
						result.DemandeReservation = DemandeReservationBL.SelectById(result.DemandeReservationId);
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return result;
		}
	}
}
