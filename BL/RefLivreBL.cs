﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using Simple;
using WebsDAL;

namespace WebsBL {
	public static class RefLivreBL {

		public static List<RefLivreBO> FindAmazonRefByISBN(String Token, String[] pISBNs) {
			if (!Autorization.Validate(Token)) {
				return new List<RefLivreBO>();
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
				return new List<RefLivreBO>();
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
				return new List<RefLivreBO>();
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
