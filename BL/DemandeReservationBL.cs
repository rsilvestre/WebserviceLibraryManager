using System;
using System.Collections.Generic;
using System.Linq;
using WebsDAL;
using WebsBO;

namespace WebsBL {
	public static class DemandeReservationBL {
		public static DemandeReservationBO SelectById(Int32 pDemandeReservationId) {
			DemandeReservationBO demandeReservation = null;

			try {
				using (var demandeReservationDal = new DemandeReservationDAL(Util.GetConnection())) {
					var lstDemandeReservation = demandeReservationDal.DemandeReservationDAL_SelectById(pDemandeReservationId).ToList();
					if (lstDemandeReservation.Count == 1){
						demandeReservation = lstDemandeReservation[0];
						demandeReservation.Client = ClientBL.SelectById(demandeReservation.ClientId);
						demandeReservation.RefLivre = RefLivreBL.SelectById(demandeReservation.RefLivreId);
						demandeReservation.Personne = PersonneBL.SelectById(demandeReservation.ClientId);
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return demandeReservation;
		}

		public static List<DemandeReservationBO> SelectForClientByRefLivreId(Int32 pClientId, Int32 pRefLivreId) {
			List<DemandeReservationBO> lstDemandeReservation;

			try {
				using (var demandeReservationDal = new DemandeReservationDAL(Util.GetConnection())) {
					lstDemandeReservation = demandeReservationDal.DemandeReservationDAL_SelectForUserByRefLivreId(pClientId, pRefLivreId).ToList();
					foreach (var objDemandeReservation in lstDemandeReservation) {
						objDemandeReservation.Client = ClientBL.SelectById(objDemandeReservation.ClientId);
						objDemandeReservation.RefLivre = RefLivreBL.SelectById(objDemandeReservation.RefLivreId);
						objDemandeReservation.Personne = PersonneBL.SelectById(objDemandeReservation.ClientId);
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return lstDemandeReservation;
		}

		public static List<DemandeReservationBO> SelectAll() {
			List<DemandeReservationBO> lstDemandeReservation;

			try {
				using (var demandeReservationDal = new DemandeReservationDAL(Util.GetConnection())) {
					lstDemandeReservation = demandeReservationDal.DemandeReservationDAL_SelectAll().ToList();
					foreach (var objDemandeReservation in lstDemandeReservation){
						objDemandeReservation.Client = ClientBL.SelectById(objDemandeReservation.ClientId);
						objDemandeReservation.RefLivre = RefLivreBL.SelectById(objDemandeReservation.RefLivreId);
						objDemandeReservation.Personne = PersonneBL.SelectById(objDemandeReservation.ClientId);
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
						objDemandeReservation.Personne = PersonneBL.SelectById(objDemandeReservation.ClientId);
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
						objDemandeReservation.Personne = PersonneBL.SelectById(objDemandeReservation.ClientId);
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
						objDemandeReservation.Personne = PersonneBL.SelectById(objDemandeReservation.ClientId);
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return objDemandeReservation;
		}

		internal static List<DemandeReservationBO> SelectByEmpruntId(Int32 pEmpruntId) {
			List<DemandeReservationBO> lstDemandeReservation = null;

			try {
				using (var demandeReservationDal = new DemandeReservationDAL(Util.GetConnection())) {
					lstDemandeReservation = demandeReservationDal.DemandeReservationDAL_SelectByEmpruntId(pEmpruntId).ToList();
					foreach (var demandeReservationBo in lstDemandeReservation){
						demandeReservationBo.Client = ClientBL.SelectById(demandeReservationBo.ClientId);
						demandeReservationBo.RefLivre = RefLivreBL.SelectById(demandeReservationBo.RefLivreId);
						demandeReservationBo.Personne = PersonneBL.SelectById(demandeReservationBo.ClientId);
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return lstDemandeReservation;
		}
	}
}
