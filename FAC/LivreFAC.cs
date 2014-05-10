using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsIFAC;
using WebsBO;
using WebsBL;

namespace WebsFAC {
	public class LivreFAC : LivreIFAC {

		public List<LivreBO> SelectAll(String Token) {
			try {
				return LivreBL.SelectAll(Token);
			} catch (Exception ex) {
				throw;
			}
		}

		public List<LivreBO> SelectByBibliotheque(String Token, BibliothequeBO pBibliotheque) {
			try {
				return LivreBL.SelectByBibliotheque(Token, pBibliotheque);
			} catch (Exception ex) {
				throw;
			}
		}

		public LivreBO InsertLivre(String Token, LivreBO pObjLivre) {
			try {
				return LivreBL.InsertLivre(Token, pObjLivre);
			} catch (Exception ex) {
				throw;
			}
		}
	}
}
