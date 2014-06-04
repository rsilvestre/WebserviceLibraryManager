using System;
using System.Collections.Generic;
using System.Linq;
using WebsDAL;
using WebsBO;

namespace WebsBL {
	public static class DemandeReservationBL {
		public static List<DemandeReservationBO> SelectById(Int32 pDemandeReservationId) {
			List<DemandeReservationBO> lstDemandeReservation = null;

			try {
				using (var demandeReservationDal = new DemandeReservationDAL(Util.GetConnection())) {
					lstDemandeReservation = demandeReservationDal.DemandeReservationDAL_SelectById(pDemandeReservationId).ToList();
					foreach (var objDemandeReservation in lstDemandeReservation) {
						objDemandeReservation.Client = ClientBL.SelectById(objDemandeReservation.ClientId);
						objDemandeReservation.RefLivre = RefLivreBL.SelectById(objDemandeReservation.RefLivreId);
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return lstDemandeReservation;
		}
		public static List<DemandeReservationBO> SelectForClientByRefLivreId(Int32 pClientId, Int32 pRefLivreId) {
			List<DemandeReservationBO> lstDemandeReservation;

			try {
				using (var demandeReservationDal = new DemandeReservationDAL(Util.GetConnection())) {
					lstDemandeReservation = demandeReservationDal.DemandeReservationDAL_SelectForUserByRefLivreId(pClientId, pRefLivreId).ToList();
					foreach (var objDemandeReservation in lstDemandeReservation) {
						objDemandeReservation.Client = ClientBL.SelectById(objDemandeReservation.ClientId);
						objDemandeReservation.RefLivre = RefLivreBL.SelectById(objDemandeReservation.RefLivreId);
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return lstDemandeReservation;
		}

		public static List<DemandeReservationBO> SelectNewByClient(ClientBO pClient) {
			List<DemandeReservationBO> lstDemandeReservation;

			try {
				using (var demandeReservationDal = new DemandeReservationDAL(Util.GetConnection())) {
					lstDemandeReservation = demandeReservationDal.DemandeReservationDAL_SelectNewByClientId(pClient.ClientId).ToList();
					foreach (var objDemandeReservation in lstDemandeReservation) {
						objDemandeReservation.Client = pClient;
						objDemandeReservation.RefLivre = RefLivreBL.SelectById(objDemandeReservation.RefLivreId);
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return lstDemandeReservation;
		}

		public static List<DemandeReservationBO> SelectOldByClient(ClientBO pClient) {
			List<DemandeReservationBO> lstDemandeReservation;

			try {
				using (var demandeReservationDal = new DemandeReservationDAL(Util.GetConnection())) {
					lstDemandeReservation = demandeReservationDal.DemandeReservationDAL_SelectOldByClientId(pClient.ClientId).ToList();
					foreach (var objDemandeReservation in lstDemandeReservation) {
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
				using (var demandeReservationDal = new DemandeReservationDAL(Util.GetConnection())) {
					List<DemandeReservationBO> lstDemandeReservation = demandeReservationDal.DemandeReservationDAL_InsertDemandeReservation(pDemandeReservation.ClientId, pDemandeReservation.RefLivreId).ToList();
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
