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
		public static List<DemandeReservationBO> SelectById(Int32 pDemandeReservationId) {
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
	}
}
