using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WebsBO;

namespace WebsIFAC {
	[ServiceContract(Namespace = "urn:WebsIFAC/LocationIFAC")]
	public interface LocationIFAC {
		[OperationContract]
		List<LocationBO> SelectAll();

		[OperationContract]
		LocationBO SelectLocationById(int pId);
	}

}
