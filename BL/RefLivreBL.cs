using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using Simple;
using WebsDAL;

namespace WebsBL {
	public static class RefLivreBL {

		public static RefLivreBO SelectById(String Token, Int32 pRefLivreId) {
			if (!Autorization.Validate(Token)) {
				return null;
			}

			RefLivreBO result = null;

			try {
				using (RefLivreDAL refLivreDal = new RefLivreDAL(Util.GetConnection())) {
					List<RefLivreBO> lstRefLivreBo = refLivreDal.RefLivreBO_SelectById(pRefLivreId).ToList();
					if (lstRefLivreBo.Count > 0) {
						result = lstRefLivreBo[0];
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return result;

		}

		public static List<RefLivreBO> FindAmazonRefByISBN(String Token, String[] pISBNs) {
			if (!Autorization.Validate(Token)) {
				return null;
			}

			List<RefLivreBO> lstRefLivre = null;

			try {
				using (AWSECommerceService awseCommerceService = new AWSECommerceService()) {
					lstRefLivre = awseCommerceService.AWSE_FindBookByISBN(pISBNs);
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstRefLivre;
		}

		public static List<RefLivreBO> FindAmazonRefByTitle(String Token, String pTitle) {
			if (!Autorization.Validate(Token)) {
				return null;
			}
			List<RefLivreBO> lstRefLivre = null;

			try {
				using (AWSECommerceService awseCommerceService = new AWSECommerceService()) {
					lstRefLivre = awseCommerceService.AWSE_FindByTitle(pTitle);
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstRefLivre;
		}

		public static List<RefLivreBO> SelectAll(String Token) {
			if (!Autorization.Validate(Token)) {
				return null;
			}
			List<RefLivreBO> lstRefLivre = null;

			try {
				using (RefLivreDAL oReflIvreDal = new RefLivreDAL(Util.GetConnection())) {
					lstRefLivre = oReflIvreDal.RefLivreBO_SelectAll().ToList();
				}
			} catch (Exception ex) {
				throw;
			}

			return lstRefLivre;
		}

		public static List<RefLivreBO> SelectByTitre(String Token, String pTitre) {
			if (!Autorization.Validate(Token)) {
				return null;
			}
			List<RefLivreBO> lstRefLivre = null;

			try {
				using (RefLivreDAL oReflIvreDal = new RefLivreDAL(Util.GetConnection())) {
					lstRefLivre = oReflIvreDal.RefLivreBO_SelectByTitre(pTitre).ToList();
				}
			} catch (Exception ex) {
				throw;
			}

			return lstRefLivre;
		}

		public static List<RefLivreBO> SelectByISBN(String Token, String pISBN) {
			if (!Autorization.Validate(Token)) {
				return null;
			}
			List<RefLivreBO> lstRefLivre = null;

			try {
				using (RefLivreDAL oReflIvreDal = new RefLivreDAL(Util.GetConnection())) {
					lstRefLivre = oReflIvreDal.RefLivreBO_SelectByISBN(pISBN).ToList();
				}
			} catch (Exception ex) {
				throw;
			}

			return lstRefLivre;
		}

		public static List<RefLivreBO> InsertLivre(
			String Token,
			String pISBN,
			String pTitre,
			String pDescription,
			String pAuteur,
			String pLangue,
			String pEditeur,
			DateTime pTimestamp,
			String pImageUrl
			) {
			if (!Autorization.Validate(Token)) {
				return new List<RefLivreBO>();
			}
				List<RefLivreBO> result;

			try {
				using (RefLivreDAL oRefLivreDal = new RefLivreDAL(Util.GetConnection())) {
					result = oRefLivreDal.RefLivreBO_InsertLivre(
						pISBN,
						pTitre,
						pDescription,
						pAuteur,
						pLangue,
						pEditeur,
						pTimestamp,
						pImageUrl
						).ToList();
				}
			} catch (Exception ex) {
				throw;
			}

			return result;
		}
	}
}
