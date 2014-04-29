using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsIFAC;
using WebsBO;
using WebsBL;

namespace WebsFAC {
	public class LivreStatusFAC : LivreStatusIFAC {
		public List<LivreStatusBO> SelectAll(String Token) {
			try {
				return LivreStatusBL.SelectAll(Token);
			} catch (Exception ex) {
				throw;
			}
		}
	}
}
