using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsDAL;
using WebsBO;

namespace WebsBL {
	public static class LocationBL {
		public static List<LocationBO> SelectAll() {
			List<LocationBO> lstResult;

			try {
				using (LocationDAL locationDal = new LocationDAL(Util.GetConnection())) {
					lstResult = locationDal.LocationBO_SelectAll().ToList();
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstResult;
		}

		public static LocationBO SelectLocationById(int pId) {
			LocationBO result = null;
			try {
				using (LocationDAL locationDal = new LocationDAL(Util.GetConnection())) {
					result = (LocationBO)locationDal.LocationBOSelectLocationById(pId);
				}
			} catch (Exception Ex) {
				throw;
			}
			return result;
		}
	}
}
