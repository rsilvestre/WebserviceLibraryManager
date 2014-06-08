using System;
using System.Collections.Generic;
using System.Linq;
using WebsBO;
using WebsDAL;

namespace WebsBL {
	public static class LivreBL {
		public static List<LivreBO> SelectAll() {
			List<LivreBO> result;

			try {
				using (var livreProxy = new LivreDAL(Util.GetConnection())) {
					result = livreProxy.LivreDAL_SelectAll().ToList();
					if (result.Count > 0) {
						foreach (var oLivreBO in result) {
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
		public static LivreBO SelectById(Int32 pLivreId) {
			LivreBO result = null;

			try {
				using (var livreProxy = new LivreDAL(Util.GetConnection())) {
					var lstLivre = livreProxy.LivreDAL_SelectById(pLivreId).ToList();
					if (lstLivre.Count == 1) {
						result = lstLivre[0];
						result.RefLivre = RefLivreBL.SelectById(lstLivre[0].RefLivreId);
						result.Bibliotheque = BibliothequeBL.SelectById(lstLivre[0].BibliothequeId);
					}
				}
			} catch (Exception ex) {
				throw;
			}
			return result;
		}

		public static List<LivreBO> SelectByBibliotheque(BibliothequeBO pBibliotheque) {
			List<LivreBO> result;

			try {
				using (var livreProxy = new LivreDAL(Util.GetConnection())) {
					result = livreProxy.LivreDAL_SelectByBibliothequeId(pBibliotheque.BibliothequeId).ToList();
					if (result.Count > 0) {
						foreach (var oLivreBo in result) {
							oLivreBo.RefLivre = RefLivreBL.SelectById(oLivreBo.RefLivreId);
							oLivreBo.Bibliotheque = BibliothequeBL.SelectById(oLivreBo.BibliothequeId);
						}
					}
				}
			} catch (Exception ex) {
				throw;
			}
			return result;
		}

		public static FicheLivreBO SelectFicheLivreForClientByLivreId(int pClientId, int pLivreId) {
			FicheLivreBO result = null;

			try {
				var objLivre = LivreBL.SelectById(pLivreId);
				if (objLivre != null) {
					result = new FicheLivreBO {
						RefLivre = objLivre.RefLivre,
						LstEmprunt = EmpruntBL.SelectForClientByLivreId(pClientId, pLivreId),
						LstDemandeReservation = DemandeReservationBL.SelectForClientByRefLivreId(pClientId, objLivre.RefLivre.RefLivreId)
					};
				}
			} catch (Exception ex) {
				throw;
			}
			return result;
		}

		public static LivreBO InsertLivre(LivreBO pObjLivre, Int32 AdministrateurId) {
			LivreBO oLivreBoResult;
			try {
				using (var livreProxy = new LivreDAL(Util.GetConnection())) {
					oLivreBoResult = (LivreBO)livreProxy.LivreDAL_InsertLivre(
						pObjLivre.BibliothequeId,
						pObjLivre.RefLivreId,
						pObjLivre.RefLivre.ISBN,
						pObjLivre.RefLivre.Titre,
						pObjLivre.RefLivre.Description,
						pObjLivre.RefLivre.Auteur,
						pObjLivre.RefLivre.Langue,
						pObjLivre.RefLivre.Editeur,
						pObjLivre.RefLivre.Published,
						pObjLivre.RefLivre.ImageUrl,
						AdministrateurId
						).ToList()[0];
					
						oLivreBoResult.RefLivre = RefLivreBL.SelectById(oLivreBoResult.RefLivreId);
						oLivreBoResult.Bibliotheque = BibliothequeBL.SelectById(oLivreBoResult.BibliothequeId);
				}
			} catch (Exception ex) {
				throw;
			}
			return oLivreBoResult;
		}

		public static List<LivreBO> SelectByInfo(String pLivreInfo, Int32 pBibliothequeId) {
			List<LivreBO> lstLivre;

			try {
				using (var livreProxy = new LivreDAL(Util.GetConnection())) {
					lstLivre = livreProxy.LivreDAL_SelectByInfo(pLivreInfo, pBibliothequeId).ToList();
					if (lstLivre.Count > 0) {
						foreach (var objLivre in lstLivre) {
							objLivre.RefLivre = RefLivreBL.SelectById(objLivre.RefLivreId);
							objLivre.Bibliotheque = BibliothequeBL.SelectById(objLivre.BibliothequeId);
						}
					}
				}
			} catch (Exception ex) {
				throw;
			}
			return lstLivre;
		}
	}
}
