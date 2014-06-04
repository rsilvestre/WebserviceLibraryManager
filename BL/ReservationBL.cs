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
	}
}
