using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBL;
using WebsBO;
using WebsIFAC;

namespace WebsFAC {
	public class LocationFAC : LocationIFAC {
		public List<LocationBO> SelectAll() {
			try {
				return LocationBL.SelectAll().ToList();
			} catch (Exception Ex) {
				throw;
			}
		}


		public LocationBO SelectLocationById(int pId) {
			try {
				return LocationBL.SelectLocationById(pId);
			} catch (Exception Ex) {
				throw;
			}
		}
	}
}
