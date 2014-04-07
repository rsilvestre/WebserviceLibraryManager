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

		public List<RefLivreBO> FindAmazonRefByISBN(string[] pISBNs) {
			try {
				return RefLivreBL.FindAmazonRefByISBN(pISBNs);
			} catch (Exception Ex) {
				throw;
			}
		}

		public List<RefLivreBO> FindAmazonRefByTitle(string pTitle) {
			try {
				return RefLivreBL.FindAmazonRefByTitle(pTitle);
			} catch (Exception Ex) {
				throw;
			}
		}


		public List<RefLivreBO> SelectAll() {
			try {
				return RefLivreBL.SelectAll();
			} catch (Exception ex) {
				throw;
			}
		}

		public List<RefLivreBO> InsertLivre(
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
