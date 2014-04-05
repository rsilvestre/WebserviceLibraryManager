using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WebsBO;

namespace WebsIFAC {
	[ServiceContract(Namespace = "urn:WebsIFAC/EmpruntIFAC")]
	public interface EmpruntIFAC {
		[OperationContract]
		List<EmpruntBO> SelectAll();

		[OperationContract]
		EmpruntBO SelectEmpruntById(int pId);
	}

}
