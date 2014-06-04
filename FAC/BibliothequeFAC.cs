using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebsBL;
using WebsBO;
using WebsIFAC;

namespace WebsFAC {
	public class BibliothequeFAC : BibliothequeIFAC {
		public List<BibliothequeBO> SelectAll(String Token) {
			if (!Autorization.Validate(Token, Autorization.Role.ALL)) {
				return null;
			}
			try {
				return BibliothequeBL.SelectAll();
			} catch (Exception ex) {
				throw;
			}
		}
	}
}
