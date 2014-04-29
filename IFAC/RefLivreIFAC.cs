using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WebsBO;

namespace WebsIFAC {
	[ServiceContract(Namespace="urn:WebsIFAC/RefLivreIFAC")]
	public interface RefLivreIFAC {
		[OperationContract]
		List<RefLivreBO> FindAmazonRefByISBN(String Token, String[] pISBNs);

		[OperationContract]
		List<RefLivreBO> FindAmazonRefByTitle(String Token, String pTitle);

		[OperationContract]
		List<RefLivreBO> SelectAll(String Token);

		[OperationContract]
		List<RefLivreBO> InsertLivre(
			String Token,
			String pISBN,
			String pTitre,
			String pDescription,
			String pAuteur,
			String pLangue,
			String pEditeur,
			DateTime pPublished,
			String pImageUrl
			);
	}
}
