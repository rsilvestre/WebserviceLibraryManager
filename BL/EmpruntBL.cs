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
					foreach (var empruntBo in lstResult){
						empruntBo.Livre = LivreBL.SelectById(empruntBo.LivreId);
						empruntBo.LstDemandeReservation = DemandeReservationBL.SelectByEmpruntId(empruntBo.EmpruntId);
						if (empruntBo.ClientId != null){
							empruntBo.Client = ClientBL.SelectById((int)empruntBo.ClientId);
							empruntBo.Personne = PersonneBL.SelectById((int)empruntBo.ClientId);
						}
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstResult;
		}

		public static EmpruntBO SelectById(Int32 pId) {
			EmpruntBO result = null;
			try {
				using (var empruntDal = new EmpruntDAL(Util.GetConnection())) {
					var lstEmpruntBos = empruntDal.EmpruntDAL_SelectById(pId).ToList();
					if (lstEmpruntBos.Count() == 1){
						result = lstEmpruntBos[0];
						result.LstDemandeReservation = DemandeReservationBL.SelectByEmpruntId(result.EmpruntId);
						result.Livre = LivreBL.SelectById(result.LivreId);
						result.Personne = PersonneBL.SelectById((int)result.ClientId);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return result;
		}

		public static List<EmpruntBO> SelectByClientId(Int32 pClientId) {
			List<EmpruntBO> result;
			try {
				using (var empruntDal = new EmpruntDAL(Util.GetConnection())) {
					result = empruntDal.EmpruntDAL_SelectByClientId(pClientId).ToList();
					foreach (var empruntBo in result){
						empruntBo.LstDemandeReservation = DemandeReservationBL.SelectByEmpruntId(empruntBo.EmpruntId);
						empruntBo.Livre = LivreBL.SelectById(empruntBo.LivreId);
						empruntBo.Personne = PersonneBL.SelectById((int)empruntBo.ClientId);
					}
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
						objEmprunt.LstDemandeReservation = DemandeReservationBL.SelectByEmpruntId(objEmprunt.EmpruntId);
						objEmprunt.Livre = LivreBL.SelectById(objEmprunt.LivreId);
						objEmprunt.Personne = PersonneBL.SelectById((int)objEmprunt.ClientId);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstResult;
		}

		public static EmpruntBO ConvertReservation(Int32 pAdministrateurId, Int32 pReservationId) {
			EmpruntBO result = null;
			try {
				using (var empruntDal = new EmpruntDAL(Util.GetConnection())) {
					var lstEmpruntBos = empruntDal.EmpruntDAL_ConvertReservation(pAdministrateurId, pReservationId).ToList();
					if (lstEmpruntBos.Count() == 1){
						result = lstEmpruntBos[0];
						result.LstDemandeReservation = DemandeReservationBL.SelectByEmpruntId(result.EmpruntId);
						result.Livre = LivreBL.SelectById(result.LivreId);
						result.Personne = PersonneBL.SelectById((int)result.ClientId);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return result;
		}

		public static EmpruntBO InsertEmprunt(Int32 pAdministrateurId, Int32 pPersonneId, Int32 pLivreId) {
			EmpruntBO result = null;
			try {
				using (var empruntDal = new EmpruntDAL(Util.GetConnection())) {
					var lstEmpruntBos = empruntDal.EmpruntDAL_InsertEmprunt(pAdministrateurId, pPersonneId, pLivreId).ToList();
					if (lstEmpruntBos.Count() == 1){
						result = lstEmpruntBos[0];
						result.LstDemandeReservation = DemandeReservationBL.SelectByEmpruntId(result.EmpruntId);
						result.Livre = LivreBL.SelectById(result.LivreId);
						result.Personne = PersonneBL.SelectById((int)result.ClientId);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return result;
		}

		public static EmpruntBO InsertRetour(Int32 pAdministrateurId, Int32 pLivreId) {
			EmpruntBO result = null;
			try {
				using (var empruntDal = new EmpruntDAL(Util.GetConnection())) {
					var lstEmpruntBos = empruntDal.EmpruntDAL_InsertRetour(pAdministrateurId, pLivreId).ToList();
					if (lstEmpruntBos.Count() == 1){
						result = lstEmpruntBos[0];
						result.LstDemandeReservation = DemandeReservationBL.SelectByEmpruntId(result.EmpruntId);
						result.Livre = LivreBL.SelectById(result.LivreId);
						result.Personne = PersonneBL.SelectById((int)result.ClientId);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return result;
		}

		public static EmpruntBO InsertAnnul(Int32 pAdministrateurId, Int32 pReservationId) {
			EmpruntBO result = null;
			try {
				using (var empruntDal = new EmpruntDAL(Util.GetConnection())) {
					var lstEmpruntBos = empruntDal.EmpruntDAL_InsertAnnul(pAdministrateurId, pReservationId).ToList();
					if (lstEmpruntBos.Count() == 1){
						result = lstEmpruntBos[0];
						result.LstDemandeReservation = DemandeReservationBL.SelectByEmpruntId(result.EmpruntId);
						result.Livre = LivreBL.SelectById(result.LivreId);
						result.Personne = PersonneBL.SelectById((int)result.ClientId);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return result;
		}
	}
}
