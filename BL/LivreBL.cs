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
			List<LivreBO> result = null;

			try {
				using (LivreDAL livreProxy = new LivreDAL(Util.GetConnection())) {
					result = livreProxy.LivreBO_SelectAll().ToList();
					if (result.Count > 0) {
						foreach (LivreBO oLivreBO in result) {
							oLivreBO.RefLivre = RefLivreBL.SelectById(oLivreBO.RefLivreId);
							oLivreBO.Bibliotheque = BibliothequeBL.SelectById(oLivreBO.BibliothequeId);
						}
					}
				}
			} catch (Exception ex) {
				throw;
			}
			return result;
		}
		public static List<LivreBO> SelectByBibliotheque(BibliothequeBO pBibliotheque) {
			List<LivreBO> result = null;

			try {
				using (LivreDAL livreProxy = new LivreDAL(Util.GetConnection())) {
					result = livreProxy.LivreBO_SelectByBibliothequeId(pBibliotheque.BibliothequeId).ToList();
					if (result.Count > 0) {
						foreach (LivreBO oLivreBO in result) {
							oLivreBO.RefLivre = RefLivreBL.SelectById(oLivreBO.RefLivreId);
							oLivreBO.Bibliotheque = BibliothequeBL.SelectById(oLivreBO.BibliothequeId);
						}
					}
				}
			} catch (Exception ex) {
				throw;
			}
			return result;
		}

		public static LivreBO InsertLivre(LivreBO pObjLivre) {
			LivreBO oLivreBOResult;
			try {
				using (LivreDAL livreProxy = new LivreDAL(Util.GetConnection())) {
					oLivreBOResult = (LivreBO)livreProxy.LivreBO_InsertLivre(
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
					
						oLivreBOResult.RefLivre = RefLivreBL.SelectById(oLivreBOResult.RefLivreId);
						oLivreBOResult.Bibliotheque = BibliothequeBL.SelectById(oLivreBOResult.BibliothequeId);
				}
			} catch (Exception ex) {
				throw;
			}
			return oLivreBOResult;
		}
	}
}
