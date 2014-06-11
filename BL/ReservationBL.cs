using System;
using System.Collections.Generic;
using System.Linq;
using WebsDAL;
using WebsBO;

namespace WebsBL {
	public static class ReservationBL {
		public static List<ReservationBO> SelectAll() {
			List<ReservationBO> lstResult;

			try {
				using (var reservationDal = new ReservationDAL(Util.GetConnection())) {
					lstResult = reservationDal.ReservationDAL_SelectAll().ToList();
					foreach (var reservationBo in lstResult){
						reservationBo.Emprunt = EmpruntBL.SelectById(reservationBo.EmpruntId);
						reservationBo.DemandeReservation = DemandeReservationBL.SelectById(reservationBo.DemandeReservationId, reservationBo.Emprunt);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstResult;
		}

		public static ReservationBO SelectById(Int32 pId) {
			ReservationBO result;
			try {
				using (var reservationDal = new ReservationDAL(Util.GetConnection())) {
					result = (ReservationBO)reservationDal.ReservationDAL_SelectById(pId);
				}
			} catch (Exception Ex) {
				throw;
			}
			return result;
		}

		public static List<ReservationBO> SelectEnCoursValidByClientId(Int32 pClientId) {
			List<ReservationBO> result;
			try {
				using (var reservationDal = new ReservationDAL(Util.GetConnection())) {
					result = reservationDal.ReservationDAL_SelectEnCoursValidByClientId(pClientId).ToList();
					foreach (var reservationBo in result){
						reservationBo.Emprunt = EmpruntBL.SelectById(reservationBo.EmpruntId);
						reservationBo.DemandeReservation = DemandeReservationBL.SelectById(reservationBo.DemandeReservationId);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return result;
		}

		public static List<ReservationBO> SelectEnCoursValidByInfo(String pInfo) {
			List<ReservationBO> result;
			try {
				using (var reservationDal = new ReservationDAL(Util.GetConnection())) {
					result = reservationDal.ReservationDAL_SelectEnCoursValidByInfo(pInfo).ToList();
					foreach (var reservationBo in result){
						reservationBo.Emprunt = EmpruntBL.SelectById(reservationBo.EmpruntId);
						reservationBo.DemandeReservation = DemandeReservationBL.SelectById(reservationBo.DemandeReservationId);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return result;
		}

		public static ReservationBO SelectEnCoursValidByReservationId(Int32 pDemandeReservationId) {
			ReservationBO result = null;
			try {
				using (var reservationDal = new ReservationDAL(Util.GetConnection())) {
					var lstResult = reservationDal.ReservationDAL_SelectEnCoursValidByReservationId(pDemandeReservationId).ToList();
					if (lstResult.Count() == 1){
						result = lstResult[0];
						result.Emprunt = EmpruntBL.SelectById(result.EmpruntId);
						result.DemandeReservation = DemandeReservationBL.SelectById(result.DemandeReservationId);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return result;
		}
	}
}
