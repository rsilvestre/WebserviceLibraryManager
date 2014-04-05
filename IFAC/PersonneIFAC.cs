using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WebsBO;

namespace WebsIFAC {
	[ServiceContract(Namespace="urn:WebsIFAC/PersonneIFAC")]
	public interface PersonneIFAC {

		[OperationContract]
		List<PersonneBO> SelectAll();

		[OperationContract]
		List<PersonneBO> SelectById(Int32 pId);

		[OperationContract]
		List<PersonneBO> SelectByName(String pName);
	}
}
