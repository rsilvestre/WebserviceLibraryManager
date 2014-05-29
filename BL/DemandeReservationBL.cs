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
			List<DemandeReservationBO> lstDemandeReservation = null;

			try {
				using (DemandeReservationDAL demandeReservationDal = new DemandeReservationDAL(Util.GetConnection())) {
					lstDemandeReservation = demandeReservationDal.DemandeReservationDAL_SelectById(pDemandeReservationId).ToList();
					foreach (DemandeReservationBO objDemandeReservation in lstDemandeReservation) {
						objDemandeReservation.Client = ClientBL.SelectById(objDemandeReservation.ClientId);
						objDemandeReservation.RefLivre = RefLivreBL.SelectById(objDemandeReservation.RefLivreId);
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return lstDemandeReservation;
		}

		public static List<DemandeReservationBO> SelectByClient(ClientBO pClient) {
			List<DemandeReservationBO> lstDemandeReservation = null;

			try {
				using (DemandeReservationDAL demandeReservationDal = new DemandeReservationDAL(Util.GetConnection())) {
					lstDemandeReservation = demandeReservationDal.DemandeReservationDAL_SelectByClientId(pClient.ClientId).ToList();
					foreach (DemandeReservationBO objDemandeReservation in lstDemandeReservation) {
						objDemandeReservation.Client = pClient;
						objDemandeReservation.RefLivre = RefLivreBL.SelectById(objDemandeReservation.RefLivreId);
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return lstDemandeReservation;
		}

		public static DemandeReservationBO InsertDemandeReservation(DemandeReservationBO pDemandeReservation) {
			DemandeReservationBO objDemandeReservation = null;

			try {
				using (DemandeReservationDAL demandeReservationDal = new DemandeReservationDAL(Util.GetConnection())) {
					List<DemandeReservationBO> lstDemandeReservation;
					lstDemandeReservation = demandeReservationDal.DemandeReservationDAL_InsertDemandeReservation(pDemandeReservation.ClientId, pDemandeReservation.RefLivreId).ToList();
					if (lstDemandeReservation.Count() == 1) {
						objDemandeReservation = lstDemandeReservation[0];
						objDemandeReservation.Client = pDemandeReservation.Client;
						objDemandeReservation.RefLivre = pDemandeReservation.RefLivre;
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return objDemandeReservation;
		}
	}
}
