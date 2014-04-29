using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBL;
using WebsIFAC;
using WebsBO;

namespace WebsFAC {
	public class RefLivreFAC : RefLivreIFAC {

		public List<RefLivreBO> FindAmazonRefByISBN(String Token, string[] pISBNs) {
			try {
				return RefLivreBL.FindAmazonRefByISBN(Token, pISBNs);
			} catch (Exception Ex) {
				throw;
			}
		}

		public List<RefLivreBO> FindAmazonRefByTitle(String Token, string pTitle) {
			try {
				return RefLivreBL.FindAmazonRefByTitle(Token, pTitle);
			} catch (Exception Ex) {
				throw;
			}
		}


		public List<RefLivreBO> SelectAll(String Token) {
			try {
				return RefLivreBL.SelectAll(Token);
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
			try {
				return RefLivreBL.InsertLivre(
					Token,
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
