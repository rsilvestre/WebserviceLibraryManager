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
			try {
				return BibliothequeBL.SelectAll(Token);
			} catch (Exception ex) {
				throw;
			}
		}
	}
}
