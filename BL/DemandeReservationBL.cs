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
						demandeReservation.RefLivre = RefLivreBL.SelectById(demandeReservation.RefLivreId);
						demandeReservation.Personne = PersonneBL.SelectById(demandeReservation.ClientId);
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return demandeReservation;
		}

		public static DemandeReservationBO SelectById(int pDemandeReservationId, EmpruntBO emprunt) {
			DemandeReservationBO demandeReservation = null;

			try {
				using (var demandeReservationDal = new DemandeReservationDAL(Util.GetConnection())) {
					var lstDemandeReservation = demandeReservationDal.DemandeReservationDAL_SelectById(pDemandeReservationId).ToList();
					if (lstDemandeReservation.Count == 1){
						demandeReservation = lstDemandeReservation[0];
						demandeReservation.RefLivre = emprunt.Livre.RefLivre;
						demandeReservation.Personne = emprunt.Personne;
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
					var lstDemandeReservation = demandeReservationDal.DemandeReservationDAL_InsertDemandeReservation(pDemandeReservation.ClientId, pDemandeReservation.RefLivreId).ToList();
					if (lstDemandeReservation.Count() == 1) {
						objDemandeReservation = lstDemandeReservation[0];
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
			List<DemandeReservationBO> lstDemandeReservation;

			try {
				using (var demandeReservationDal = new DemandeReservationDAL(Util.GetConnection())) {
					lstDemandeReservation = demandeReservationDal.DemandeReservationDAL_SelectByEmpruntId(pEmpruntId).ToList();
					foreach (var demandeReservationBo in lstDemandeReservation){
						demandeReservationBo.RefLivre = RefLivreBL.SelectById(demandeReservationBo.RefLivreId);
						demandeReservationBo.Personne = PersonneBL.SelectById(demandeReservationBo.ClientId);
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return lstDemandeReservation;
		}

		public static List<DemandeReservationBO> SelectByEmpruntId(int pEmpruntId, LivreBO pLivre) {
			List<DemandeReservationBO> lstDemandeReservation;

			try {
				using (var demandeReservationDal = new DemandeReservationDAL(Util.GetConnection())) {
					lstDemandeReservation = demandeReservationDal.DemandeReservationDAL_SelectByEmpruntId(pEmpruntId).ToList();
					foreach (var demandeReservationBo in lstDemandeReservation){
						demandeReservationBo.RefLivre = pLivre.RefLivre;
						demandeReservationBo.Personne = PersonneBL.SelectById(demandeReservationBo.ClientId);
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return lstDemandeReservation;
		}

		public static List<DemandeReservationBO> SelectByEmpruntId(int pEmpruntId, PersonneBO pPersonne, LivreBO pLivre) {
			List<DemandeReservationBO> lstDemandeReservation;

			try {
				using (var demandeReservationDal = new DemandeReservationDAL(Util.GetConnection())) {
					lstDemandeReservation = demandeReservationDal.DemandeReservationDAL_SelectByEmpruntId(pEmpruntId).ToList();
					foreach (var demandeReservationBo in lstDemandeReservation){
						demandeReservationBo.RefLivre = pLivre.RefLivre;
						demandeReservationBo.Personne = pPersonne;
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return lstDemandeReservation;
		}
	}
}
