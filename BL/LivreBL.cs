using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using WebsDAL;

namespace WebsBL {
	public static class LivreBL {
		public static List<LivreBO> SelectAll() {
			List<LivreBO> result;
			try {
				using (LivreDAL livreProxy = new LivreDAL(Util.GetConnection())) {
					result = livreProxy.LivreBO_SelectAll().ToList();
				}
			} catch (Exception ex) {
				throw;
			}
			return result;
		}
	}
}
