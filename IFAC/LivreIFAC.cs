using System;
using System.Collections.Generic;
using System.Linq;
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
		LivreBO InsertLivre(String Token, LivreBO pObjLivre);
	}
}
