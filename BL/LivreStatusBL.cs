using System;
using System.Collections.Generic;
using System.Linq;
using WebsBO;
using WebsDAL;

namespace WebsBL {
	public static class LivreStatusBL {
		public static List<LivreStatusBO> SelectAll() {
			List<LivreStatusBO> result;

			try {
				using (var livreStatusProxy = new LivreStatusDAL(Util.GetConnection())) {
					result = livreStatusProxy.LivreStatusDAL_SelectAll().ToList();
				}
			} catch (Exception ex) {
				throw;
			}

			return result;
		}
	}
}
