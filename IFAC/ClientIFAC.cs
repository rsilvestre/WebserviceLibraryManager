using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using System.ServiceModel;

namespace WebsIFAC {
	[ServiceContract(Namespace = "urn:WebsIFAC/ClientIFAC")]
    public interface ClientIFAC {
		[OperationContract]
		List<ClientBO> SelectAll();

		[OperationContract]
		ClientBO SelectionClientById(int pId);
    }
}
