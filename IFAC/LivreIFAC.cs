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
		List<LivreBO> SelectAll(String Token);
		[OperationContract]
		List<LivreBO> SelectByInfo(String Token, String pLivreInfo, Int32 pBibliothequeId);

		[OperationContract]
		List<LivreBO> SelectByBibliotheque(String Token, BibliothequeBO pBibliotheque);

		[OperationContract]
		FicheLivreBO SelectFicheLivreForClientByLivreId(String Token, Int32 pClientId, Int32 pLivreId);

		[OperationContract]
		LivreBO InsertLivre(String Token, LivreBO pObjLivre, Int32 AdministrateurId);
	}
}
