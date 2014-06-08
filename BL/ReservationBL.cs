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
				using (var ReservationDal = new ReservationDAL(Util.GetConnection())) {
					lstResult = ReservationDal.ReservationDAL_SelectAll().ToList();
					foreach (var reservationBo in lstResult){
						reservationBo.Emprunt = EmpruntBL.SelectById(reservationBo.EmpruntId);
						reservationBo.DemandeReservation = DemandeReservationBL.SelectById(reservationBo.DemandeReservationId);
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
				using (var ReservationDal = new ReservationDAL(Util.GetConnection())) {
					result = (ReservationBO)ReservationDal.ReservationDAL_SelectById(pId);
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
	}
}
