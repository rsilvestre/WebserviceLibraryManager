using System;
using System.Collections.Generic;
using WebsBL;
using WebsBO;
using WebsIFAC;

namespace WebsFAC {
	public class ReservationFAC : ReservationIFAC {
		public List<ReservationBO> SelectAll(String token) {
			if (!Autorization.Validate(token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return ReservationBL.SelectAll();
			} catch (Exception Ex) {
				throw;
			}
		}

		public ReservationBO SelectReservationById(String token, Int32 pId) {
			if (!Autorization.Validate(token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return ReservationBL.SelectById(pId);
			} catch (Exception Ex) {
				throw;
			}
		}

		public List<ReservationBO> SelectEnCoursValidByClientId(String token, Int32 pClientId) {
			if (!Autorization.Validate(token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return ReservationBL.SelectEnCoursValidByClientId(pClientId);
			} catch (Exception Ex) {
				throw;
			}
		}

		public List<ReservationBO> SelectEnCoursValidByInfo(String token, String pInfo){
			if (!Autorization.Validate(token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return ReservationBL.SelectEnCoursValidByInfo(pInfo);
			} catch (Exception Ex) {
				throw;
			}
		}

		public ReservationBO SelectEnCoursValidByReservationId(String token, Int32 pDemandeReservationId){
			if (!Autorization.Validate(token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return ReservationBL.SelectEnCoursValidByReservationId(pDemandeReservationId);
			} catch (Exception Ex) {
				throw;
			}
		}
	}
}
