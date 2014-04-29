using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsDAL;
using WebsBO;
using WebsBL;

namespace WebsBL {
	public static class DemandeReservationBL {
		public static List<DemandeReservationBO> SelectById(String Token, Int32 pDemandeReservationId) {
			if (!Autorization.Validate(Token)) {
				return new List<DemandeReservationBO>();
			}
			List<DemandeReservationBO> lstResult;

			try {
				using (DemandeReservationDAL demandeReservationDal = new DemandeReservationDAL(Util.GetConnection())) {
					lstResult = demandeReservationDal.DemandeReservationDAL_SelectById(pDemandeReservationId).ToList();
				}
			} catch (Exception ex) {
				throw;
			}

			return lstResult;
		}

		public static List<DemandeReservationBO> SelectByClientId(String Token, Int32 pClientId) {
			if (!Autorization.Validate(Token)) {
				return new List<DemandeReservationBO>();
			}
			List<DemandeReservationBO> lstDemandeReservation;

			try {
				using (DemandeReservationDAL demandeReservationDal = new DemandeReservationDAL(Util.GetConnection())) {
					lstDemandeReservation = demandeReservationDal.DemandeReservationDAL_SelectByClientId(pClientId).ToList();
				}
			} catch (Exception ex) {
				throw;
			}

			return lstDemandeReservation;
		}
	}
}
