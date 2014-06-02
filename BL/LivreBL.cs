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
					result = livreProxy.LivreDAL_SelectAll().ToList();
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
		public static LivreBO SelectById(Int32 pLivreId) {
			LivreBO result = null;

			try {
				using (LivreDAL livreProxy = new LivreDAL(Util.GetConnection())) {
					List<LivreBO> lstLivre = livreProxy.LivreDAL_SelectById(pLivreId).ToList();
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
			List<LivreBO> result = null;

			try {
				using (LivreDAL livreProxy = new LivreDAL(Util.GetConnection())) {
					result = livreProxy.LivreDAL_SelectByBibliothequeId(pBibliotheque.BibliothequeId).ToList();
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

		public static FicheLivreBO SelectFicheLivreForClientByLivreId(int pClientId, int pLivreId) {
			FicheLivreBO result = null;

			try {
				LivreBO objLivre = LivreBL.SelectById(pLivreId);
				if (objLivre != null) {
					result = new FicheLivreBO();
					result.RefLivre = objLivre.RefLivre;
					result.LstEmprunt = EmpruntBL.SelectForClientByLivreId(pClientId, pLivreId);
					result.LstDemandeReservation = DemandeReservationBL.SelectForClientByRefLivreId(pClientId, objLivre.RefLivre.RefLivreId);
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
					oLivreBOResult = (LivreBO)livreProxy.LivreDAL_InsertLivre(
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

		public static List<LivreBO> SelectByInfo(String pLivreInfo, Int32 pBibliothequeId) {
			List<LivreBO> lstLivre = null;

			try {
				using (LivreDAL livreProxy = new LivreDAL(Util.GetConnection())) {
					lstLivre = livreProxy.LivreDAL_SelectByInfo(pLivreInfo, pBibliothequeId).ToList();
					if (lstLivre.Count > 0) {
						foreach (LivreBO objLivre in lstLivre) {
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
