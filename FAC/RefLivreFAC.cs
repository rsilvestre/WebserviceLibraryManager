using System;
using System.Collections.Generic;
using WebsBL;
using WebsIFAC;
using WebsBO;

namespace WebsFAC {
	public class RefLivreFAC : RefLivreIFAC {

		public List<RefLivreBO> FindAmazonRefByISBN(String Token, string[] pISBNs) {
			if (!Autorization.Validate(Token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return RefLivreBL.FindAmazonRefByISBN(pISBNs);
			} catch (Exception Ex) {
				throw;
			}
		}

		public List<RefLivreBO> FindAmazonRefByTitle(String Token, string pTitle) {
			if (!Autorization.Validate(Token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return RefLivreBL.FindAmazonRefByTitle(pTitle);
			} catch (Exception Ex) {
				throw;
			}
		}


		public List<RefLivreBO> SelectAll(String Token) {
			if (!Autorization.Validate(Token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return RefLivreBL.SelectAll();
			} catch (Exception ex) {
				throw;
			}
		}

		public FicheLivreBO SelectFicheLivreForClientByRefLivreId(String Token, Int32 pClientId, Int32 pRefLivreId) {
			if (!Autorization.Validate(Token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return RefLivreBL.SelectFicheLivreForClientByRefLivreId(pClientId, pRefLivreId);
			} catch (Exception ex) {
				throw;
			}
		}

		public List<RefLivreBO> SelectByTitre(String Token, String pTitre) {
			if (!Autorization.Validate(Token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return RefLivreBL.SelectByTitre(pTitre);
			} catch (Exception ex) {
				throw;
			}
		}

		public List<RefLivreBO> SelectByISBN(String Token, String pISBN) {
			if (!Autorization.Validate(Token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return RefLivreBL.SelectByISBN(pISBN);
			} catch (Exception ex) {
				throw;
			}
		}

		public List<RefLivreBO> InsertLivre(
			String Token,
			String pISBN,
			String pTitre,
			String pDescription,
			String pAuteur,
			String pLangue,
			String pEditeur,
			DateTime pPublished,
			String pImageUrl
			) {
			if (!Autorization.Validate(Token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return RefLivreBL.InsertLivre(
					pISBN,
					pTitre,
					pDescription,
					pAuteur,
					pLangue,
					pEditeur,
					pPublished,
					pImageUrl
					);
			} catch (Exception ex) {
				throw;
			}
		}
	}
}
