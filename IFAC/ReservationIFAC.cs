using System;
using System.Collections.Generic;
using System.ServiceModel;
using WebsBO;

namespace WebsIFAC {
	[ServiceContract(Namespace = "urn:WebsIFAC/ReservationIFAC")]
	public interface ReservationIFAC {
		[OperationContract]
		List<ReservationBO> SelectAll(String token);

		[OperationContract]
		ReservationBO SelectReservationById(String token, Int32 pId);

		[OperationContract]
		List<ReservationBO> SelectEnCoursValidByClientId(String token, Int32 pClientId);

		[OperationContract]
		List<ReservationBO> SelectEnCoursValidByInfo(String token, String pInfo);

		[OperationContract]
		ReservationBO SelectEnCoursValidByReservationId(String token, Int32 pDemandeReservationId);
	}

}
