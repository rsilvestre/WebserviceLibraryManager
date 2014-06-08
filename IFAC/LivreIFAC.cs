using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WebsBO;

namespace WebsIFAC {
	[ServiceContract(Namespace = "urn:WebsIFAC/LivreIFAC")]
	public interface LivreIFAC {
		[OperationContract]
		List<LivreBO> SelectAll(String token);
		[OperationContract]
		List<LivreBO> SelectByInfo(String token, String pLivreInfo, Int32 pBibliothequeId);

		[OperationContract]
		List<LivreBO> SelectByBibliotheque(String token, BibliothequeBO pBibliotheque);

		[OperationContract]
		FicheLivreBO SelectFicheLivreForClientByLivreId(String token, Int32 pClientId, Int32 pLivreId);

		[OperationContract]
		LivreBO InsertLivre(String token, LivreBO pObjLivre, Int32 pAdministrateurId);
	}
}
