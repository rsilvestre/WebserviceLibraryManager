using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using WebsDAL;

namespace WebsBL {
	public static class LivreStatusBL {
		public static List<LivreStatusBO> SelectAll(String Token) {
			if (!Autorization.Validate(Token)) {
				return new List<LivreStatusBO>();
			}
			List<LivreStatusBO> result;

			try {
				using (LivreStatusDAL livreStatusProxy = new LivreStatusDAL(Util.GetConnection())) {
					result = livreStatusProxy.LivreStatusDAL_SelectAll().ToList();
				}
			} catch (Exception ex) {
				throw;
			}

			return result;
		}
	}
}
