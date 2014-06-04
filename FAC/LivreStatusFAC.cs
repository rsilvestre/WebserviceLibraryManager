using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebsIFAC;
using WebsBO;
using WebsBL;

namespace WebsFAC {
	public class LivreStatusFAC : LivreStatusIFAC {
		public List<LivreStatusBO> SelectAll(String Token) {
			if (!Autorization.Validate(Token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return LivreStatusBL.SelectAll();
			} catch (Exception ex) {
				throw;
			}
		}
	}
}
