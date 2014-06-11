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
					foreach (var objEmpruntBo in lstResult) {
						FillObjEmpruntBo(objEmpruntBo);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstResult;
		}

		public static EmpruntBO SelectById(Int32 pId) {
			EmpruntBO objEmpruntBo = null;
			try {
				using (var empruntDal = new EmpruntDAL(Util.GetConnection())) {
					var lstEmpruntBos = empruntDal.EmpruntDAL_SelectById(pId).ToList();
					if (lstEmpruntBos.Count() == 1){
						objEmpruntBo = lstEmpruntBos[0];
						FillObjEmpruntBo(objEmpruntBo);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return objEmpruntBo;
		}

		public static List<EmpruntBO> SelectByClientId(Int32 pClientId) {
			List<EmpruntBO> lstEmpruntBo;
			try {
				using (var empruntDal = new EmpruntDAL(Util.GetConnection())) {
					lstEmpruntBo = empruntDal.EmpruntDAL_SelectByClientId(pClientId).ToList();
					foreach (var objEmpruntBo in lstEmpruntBo){
						objEmpruntBo.Livre = LivreBL.SelectById(objEmpruntBo.LivreId);
						FillObjEmpruntBo(objEmpruntBo);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstEmpruntBo;
		}

		internal static List<EmpruntBO> SelectForClientByLivreId(int pClientId, int pLivreId) {
			List<EmpruntBO> lstEmpruntBo;

			try {
				using (var empruntDal = new EmpruntDAL(Util.GetConnection())) {
					lstEmpruntBo = empruntDal.EmpruntDAL_SelectForUserByLivreId(pClientId, pLivreId).ToList();
					foreach (var objEmpruntBo in lstEmpruntBo) {
						objEmpruntBo.Livre = LivreBL.SelectById(objEmpruntBo.LivreId);
						FillObjEmpruntBo(objEmpruntBo);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstEmpruntBo;
		}

		public static EmpruntBO ConvertReservation(Int32 pAdministrateurId, Int32 pReservationId) {
			EmpruntBO objEmpruntBo = null;
			try {
				using (var empruntDal = new EmpruntDAL(Util.GetConnection())) {
					var lstEmpruntBos = empruntDal.EmpruntDAL_ConvertReservation(pAdministrateurId, pReservationId).ToList();
					if (lstEmpruntBos.Count() == 1){
						objEmpruntBo = lstEmpruntBos[0];
						FillObjEmpruntBo(objEmpruntBo);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return objEmpruntBo;
		}

		public static EmpruntBO InsertEmprunt(Int32 pAdministrateurId, Int32 pPersonneId, Int32 pLivreId) {
			EmpruntBO objEmpruntBo = null;
			try {
				using (var empruntDal = new EmpruntDAL(Util.GetConnection())) {
					var lstEmpruntBos = empruntDal.EmpruntDAL_InsertEmprunt(pAdministrateurId, pPersonneId, pLivreId).ToList();
					if (lstEmpruntBos.Count() == 1){
						objEmpruntBo = lstEmpruntBos[0];
						FillObjEmpruntBo(objEmpruntBo);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return objEmpruntBo;
		}

		public static EmpruntBO InsertRetour(Int32 pAdministrateurId, Int32 pLivreId) {
			EmpruntBO objEmpruntBo = null;
			try {
				using (var empruntDal = new EmpruntDAL(Util.GetConnection())) {
					var lstEmpruntBo = empruntDal.EmpruntDAL_InsertRetour(pAdministrateurId, pLivreId).ToList();
					if (lstEmpruntBo.Count() == 1){
						objEmpruntBo = lstEmpruntBo[0];
						FillObjEmpruntBo(objEmpruntBo);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return objEmpruntBo;
		}

		public static EmpruntBO InsertAnnul(Int32 pAdministrateurId, Int32 pReservationId) {
			EmpruntBO objEmpruntBo = null;
			try {
				using (var empruntDal = new EmpruntDAL(Util.GetConnection())) {
					var lstEmpruntBo = empruntDal.EmpruntDAL_InsertAnnul(pAdministrateurId, pReservationId).ToList();
					if (lstEmpruntBo.Count() == 1){
						objEmpruntBo = lstEmpruntBo[0];
						FillObjEmpruntBo(objEmpruntBo);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return objEmpruntBo;
		}

		private static void FillObjEmpruntBo(EmpruntBO objEmpruntBo) {
			objEmpruntBo.Livre = LivreBL.SelectById(objEmpruntBo.LivreId);
			if (objEmpruntBo.ClientId != null) {
				objEmpruntBo.Personne = PersonneBL.SelectById((int)objEmpruntBo.ClientId);
				objEmpruntBo.LstDemandeReservation = DemandeReservationBL.SelectByEmpruntId(objEmpruntBo.EmpruntId, objEmpruntBo.Personne, objEmpruntBo.Livre);
			} else {
				objEmpruntBo.LstDemandeReservation = DemandeReservationBL.SelectByEmpruntId(objEmpruntBo.EmpruntId, objEmpruntBo.Livre);
			}
		}
	}
}
