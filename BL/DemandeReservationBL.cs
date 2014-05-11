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
				return null;
			}
			List<DemandeReservationBO> lstDemandeReservation = null;

			try {
				using (DemandeReservationDAL demandeReservationDal = new DemandeReservationDAL(Util.GetConnection())) {
					lstDemandeReservation = demandeReservationDal.DemandeReservationDAL_SelectById(pDemandeReservationId).ToList();
					foreach (DemandeReservationBO objDemandeReservation in lstDemandeReservation) {
						objDemandeReservation.Client = ClientBL.SelectById(Token, objDemandeReservation.ClientId);
						objDemandeReservation.RefLivre = RefLivreBL.SelectById(Token, objDemandeReservation.RefLivreId);
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return lstDemandeReservation;
		}

		public static List<DemandeReservationBO> SelectByClient(String Token, ClientBO pClient) {
			if (!Autorization.Validate(Token)) {
				return null;
			}
			List<DemandeReservationBO> lstDemandeReservation = null;

			try {
				using (DemandeReservationDAL demandeReservationDal = new DemandeReservationDAL(Util.GetConnection())) {
					lstDemandeReservation = demandeReservationDal.DemandeReservationDAL_SelectByClientId(pClient.ClientId).ToList();
					foreach (DemandeReservationBO objDemandeReservation in lstDemandeReservation) {
						objDemandeReservation.Client = pClient;
						objDemandeReservation.RefLivre = RefLivreBL.SelectById(Token, objDemandeReservation.RefLivreId);
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return lstDemandeReservation;
		}

		public static DemandeReservationBO InsertDemandeReservation(String Token, DemandeReservationBO pDemandeReservation) {
			if (!Autorization.Validate(Token)) {
				return null;
			}
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
