using System;
using System.Collections.Generic;
using System.Linq;
using WebsBO;
using Simple;
using WebsDAL;

namespace WebsBL {
	public static class RefLivreBL {

		public static RefLivreBO SelectById(Int32 pRefLivreId) {

			RefLivreBO result = null;

			try {
				using (var refLivreDal = new RefLivreDAL(Util.GetConnection())) {
					var lstRefLivreBo = refLivreDal.RefLivreBO_SelectById(pRefLivreId).ToList();
					if (lstRefLivreBo.Count > 0) {
						result = lstRefLivreBo[0];
					}
				}
			} catch (Exception ex) {
				throw;
			}

			return result;

		}

		public static List<RefLivreBO> FindAmazonRefByISBN(String[] pISBNs) {
			List<RefLivreBO> lstRefLivre;

			try {
				using (var awseCommerceService = new AwseCommerceService()) {
					lstRefLivre = awseCommerceService.AWSE_FindBookByISBN(pISBNs);
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstRefLivre;
		}

		public static List<RefLivreBO> FindAmazonRefByTitle(String pTitle) {
			List<RefLivreBO> lstRefLivre;

			try {
				using (var awseCommerceService = new AwseCommerceService()) {
					lstRefLivre = awseCommerceService.AWSE_FindByTitle(pTitle);
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstRefLivre;
		}

		public static List<RefLivreBO> SelectAll() {
			List<RefLivreBO> lstRefLivre;

			try {
				using (var oReflIvreDal = new RefLivreDAL(Util.GetConnection())) {
					lstRefLivre = oReflIvreDal.RefLivreBO_SelectAll().ToList();
				}
			} catch (Exception ex) {
				throw;
			}

			return lstRefLivre;
		}

		public static FicheLivreBO SelectFicheLivreForClientByRefLivreId(int pClientId, int pRefLivreId) {
			FicheLivreBO result = null;

			try {
				var objRefLivre = RefLivreBL.SelectById(pRefLivreId);
				if (objRefLivre != null) {
					result = new FicheLivreBO {
						RefLivre = objRefLivre,
						LstEmprunt = null,
						LstDemandeReservation = DemandeReservationBL.SelectForClientByRefLivreId(pClientId, objRefLivre.RefLivreId)
					};
				}
			} catch (Exception ex) {
				throw;
			}
			return result;
		}

		public static List<RefLivreBO> SelectByTitre(String pTitre) {
			List<RefLivreBO> lstRefLivre;

			try {
				using (var oReflIvreDal = new RefLivreDAL(Util.GetConnection())) {
					lstRefLivre = oReflIvreDal.RefLivreBO_SelectByTitre(pTitre).ToList();
				}
			} catch (Exception ex) {
				throw;
			}

			return lstRefLivre;
		}

		public static List<RefLivreBO> SelectByISBN(String pISBN) {
			List<RefLivreBO> lstRefLivre;

			try {
				using (var oReflIvreDal = new RefLivreDAL(Util.GetConnection())) {
					lstRefLivre = oReflIvreDal.RefLivreBO_SelectByISBN(pISBN).ToList();
				}
			} catch (Exception ex) {
				throw;
			}

			return lstRefLivre;
		}

		public static List<RefLivreBO> InsertLivre(
			String pISBN,
			String pTitre,
			String pDescription,
			String pAuteur,
			String pLangue,
			String pEditeur,
			DateTime pTimestamp,
			String pImageUrl
			) {
			List<RefLivreBO> result;

			try {
				using (var oRefLivreDal = new RefLivreDAL(Util.GetConnection())) {
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
