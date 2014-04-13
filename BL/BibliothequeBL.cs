using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using WebsDAL;

namespace WebsBL {
	public static class BibliothequeBL {

		public static List<BibliothequeBO> SelectAll() {
			List<BibliothequeBO> result;

			try {
				using (BibliothequeDAL bibliothequeProxy = new BibliothequeDAL(Util.GetConnection())) {
					result = bibliothequeProxy.BibliothequeDAL_SelectAll().ToList();
				}
			} catch (Exception ex) {
				throw;
			}

			return result;
		}
	}
}
