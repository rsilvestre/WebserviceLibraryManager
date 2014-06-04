using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WebsBO;

namespace WebsIFAC {
	[ServiceContract(Namespace = "urn:WebsIFAC/ReservationIFAC")]
	public interface ReservationIFAC {
		[OperationContract]
		List<ReservationBO> SelectAll(String Token);

		[OperationContract]
		ReservationBO SelectReservationById(String Token, int pId);
	}

}
