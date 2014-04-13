using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using WebsIFAC;
using WebsBL;

namespace WebsFAC {
	public class AdministrateurFAC : AdministrateurIFAC {
		public AdministrateurBO SelectById(int pAdministrateurId) {
			try {
				return AdministrateurBL.SelectById(pAdministrateurId);
			} catch (Exception ex) {
				throw;
			}
		}
	}
}
