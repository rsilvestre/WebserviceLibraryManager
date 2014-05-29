using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBL;
using WebsBO;
using WebsIFAC;

namespace WebsFAC {
	public class BibliothequeFAC : BibliothequeIFAC {
		public List<BibliothequeBO> SelectAll(String Token) {
			if (!Autorization.Validate(Token)) {
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
