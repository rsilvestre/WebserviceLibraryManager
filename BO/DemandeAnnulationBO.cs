using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WebsBO {
	[DataContract(Namespace="urn:WebsBO.DemandeAnnulationBO")]
	public class DemandeAnnulationBO {
		private Int32 _DemandeReservationId;
		private DateTime _CreatedAt;

		public DemandeAnnulationBO() { }

		public DemandeAnnulationBO(Int32 pDemandeReservationId, DateTime pCreatedAt) {
			DemandeReservationId = pDemandeReservationId;
			CreatedAt = pCreatedAt;
		}

		[DataMember(Name="CreatedAt")]
		public DateTime CreatedAt {
			get { return _CreatedAt; }
			set { _CreatedAt = value; }
		}

		[DataMember(Name = "DemandeReservationId")]
		public Int32 DemandeReservationId {
			get { return _DemandeReservationId; }
			set { _DemandeReservationId = value; }
		}


	}
}
