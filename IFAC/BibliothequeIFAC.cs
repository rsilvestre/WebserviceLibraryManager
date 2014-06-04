using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WebsBO;

namespace WebsIFAC {
	[ServiceContract(Namespace="urn:WebsIFAC/BibliothequeIFAC")]
	public interface BibliothequeIFAC {
		[OperationContract]
		List<BibliothequeBO> SelectAll(String Token);

	}
}
