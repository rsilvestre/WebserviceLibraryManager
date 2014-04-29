using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using WebsDAL;

namespace WebsBL {
	public static class LivreBL {
		public static List<LivreBO> SelectAll(String Token) {
			if (!Autorization.Validate(Token)) {
				return new List<LivreBO>();
			}
			List<LivreBO> result;
			try {
				using (LivreDAL livreProxy = new LivreDAL(Util.GetConnection())) {
					result = livreProxy.LivreBO_SelectAll().ToList();
				}
				using (RefLivreDAL refLivreProxy = new RefLivreDAL(Util.GetConnection())) {
					foreach (LivreBO oLivreBO in result) {
						oLivreBO.RefLivre = refLivreProxy.RefLivreBO_SelectById(oLivreBO.RefLivreId).ToList()[0];
					}
				}
			} catch (Exception ex) {
				throw;
			}
			return result;
		}

		public static LivreBO InsertLivre(String Token, LivreBO pObjLivre) {
			if (!Autorization.Validate(Token)) {
				return new LivreBO();
			}
			LivreBO result;
			try {
				using (LivreDAL livreProxy = new LivreDAL(Util.GetConnection())) {
					result = (LivreBO)livreProxy.LivreBO_InsertLivre(
						pObjLivre.BibliothequeId,
						pObjLivre.RefLivreId,
						pObjLivre.RefLivre.ISBN,
						pObjLivre.RefLivre.Titre,
						pObjLivre.RefLivre.Description,
						pObjLivre.RefLivre.Auteur,
						pObjLivre.RefLivre.Langue,
						pObjLivre.RefLivre.Editeur,
						pObjLivre.RefLivre.Published,
						pObjLivre.RefLivre.ImageUrl
						).ToList()[0];
				}
			} catch (Exception ex) {
				throw;
			}
			return result;
		}
	}
}
