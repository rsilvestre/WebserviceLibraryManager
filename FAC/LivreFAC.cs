using System;
using System.Collections.Generic;
using WebsIFAC;
using WebsBO;
using WebsBL;

namespace WebsFAC {
	public class LivreFAC : LivreIFAC {

		public List<LivreBO> SelectAll(String token) {
			if (!Autorization.Validate(token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return LivreBL.SelectAll();
			} catch (Exception ex) {
				throw;
			}
		}

		public List<LivreBO> SelectByBibliotheque(String token, BibliothequeBO pBibliotheque) {
			if (!Autorization.Validate(token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return LivreBL.SelectByBibliotheque(pBibliotheque);
			} catch (Exception ex) {
				throw;
			}
		}

		public FicheLivreBO SelectFicheLivreForClientByLivreId(String token, Int32 pClientId, Int32 pLivreId) {
			if (!Autorization.Validate(token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return LivreBL.SelectFicheLivreForClientByLivreId(pClientId, pLivreId);
			} catch (Exception ex) {
				throw;
			}
		}

		public LivreBO InsertLivre(String token, LivreBO pObjLivre, Int32 pAdministrateurId) {
			if (!Autorization.Validate(token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return LivreBL.InsertLivre(pObjLivre, pAdministrateurId);
			} catch (Exception ex) {
				throw;
			}
		}


		public List<LivreBO> SelectByInfo(string token, String pLivreInfo, Int32 pBibliothequeId) {
			if (!Autorization.Validate(token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return LivreBL.SelectByInfo(pLivreInfo, pBibliothequeId);
			} catch (Exception ex) {
				throw;
			}
		}
	}
}
