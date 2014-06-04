using System;
using System.Collections.Generic;
using System.Linq;
using WebsDAL;
using WebsBO;

namespace WebsBL {
	public static class EmpruntBL {

		public static List<EmpruntBO> SelectAll() {
			List<EmpruntBO> lstResult;

			try {
				using (var empruntDal = new EmpruntDAL(Util.GetConnection())) {
					lstResult = empruntDal.EmpruntDAL_SelectAll().ToList();
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstResult;
		}

		public static EmpruntBO SelectById(Int32 pId) {
			EmpruntBO result;
			try {
				using (var empruntDal = new EmpruntDAL(Util.GetConnection())) {
					result = (EmpruntBO)empruntDal.EmpruntDAL_SelectById(pId);
				}
			} catch (Exception Ex) {
				throw;
			}
			return result;
		}

		internal static List<EmpruntBO> SelectForClientByLivreId(int pClientId, int pLivreId) {
			List<EmpruntBO> lstResult;

			try {
				using (var empruntDal = new EmpruntDAL(Util.GetConnection())) {
					lstResult = empruntDal.EmpruntDAL_SelectForUserByLivreId(pClientId, pLivreId).ToList();
					foreach (var objEmprunt in lstResult) {
						objEmprunt.Livre = LivreBL.SelectById(objEmprunt.LivreId);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstResult;
		}

		public static EmpruntBO InsertEmpruntFromReservation(Int32 pAdministrateurId, Int32 pReservationId) {
			EmpruntBO result;
			try {
				using (var empruntDal = new EmpruntDAL(Util.GetConnection())) {
					result = (EmpruntBO)empruntDal.EmpruntDAL_InsertEmpruntFromReservation(pAdministrateurId, pReservationId);
				}
			} catch (Exception Ex) {
				throw;
			}
			return result;
		}

		public static EmpruntBO InsertEmprunt(Int32 pAdministrateurId, Int32 pPersonneId, Int32 pLivreId) {
			EmpruntBO result;
			try {
				using (var empruntDal = new EmpruntDAL(Util.GetConnection())) {
					result = (EmpruntBO)empruntDal.EmpruntDAL_InsertEmprunt(pAdministrateurId, pPersonneId, pLivreId);
				}
			} catch (Exception Ex) {
				throw;
			}
			return result;
		}

		public static EmpruntBO InsertRetour(Int32 pAdministrateurId, Int32 pLivreId) {
			EmpruntBO result;
			try {
				using (var empruntDal = new EmpruntDAL(Util.GetConnection())) {
					result = (EmpruntBO)empruntDal.EmpruntDAL_InsertRetour(pAdministrateurId, pLivreId);
				}
			} catch (Exception Ex) {
				throw;
			}
			return result;
		}

		public static EmpruntBO InsertAnnul(Int32 pAdministrateurId, Int32 pLivreId) {
			EmpruntBO result;
			try {
				using (var empruntDal = new EmpruntDAL(Util.GetConnection())) {
					result = (EmpruntBO)empruntDal.EmpruntDAL_InsertAnnul(pAdministrateurId, pLivreId);
				}
			} catch (Exception Ex) {
				throw;
			}
			return result;
		}
	}
}
