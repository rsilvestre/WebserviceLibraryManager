using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebsBL;
using WebsBO;
using WebsIFAC;

namespace WebsFAC {
	public class ReservationFAC : ReservationIFAC {
		public List<ReservationBO> SelectAll(String Token) {
			if (!Autorization.Validate(Token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return ReservationBL.SelectAll();
			} catch (Exception Ex) {
				throw;
			}
		}

		public ReservationBO SelectReservationById(String Token, Int32 pId) {
			if (!Autorization.Validate(Token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return ReservationBL.SelectById(pId);
			} catch (Exception Ex) {
				throw;
			}
		}
	}
}
