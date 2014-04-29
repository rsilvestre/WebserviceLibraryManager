using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebsBO
{
	[DataContract(Namespace = "urn:WebsBO.ClientBO")]
    public class ClientBO {
		private Int32 _ClientId;
		private Int32 _BibliothequeId;
		private List<DemandeReservationBO> _LstDemandeReservation;

		public ClientBO() { }

		public ClientBO(Int32 pClientId, Int32 pBibliothequeId) {
			ClientId = pClientId;
			BibliothequeId = pBibliothequeId;
		}

		[DataMember(Name = "DemandeReservation")]
		public List<DemandeReservationBO> LstDemandeReservation {
			get { return _LstDemandeReservation; }
			set { _LstDemandeReservation = value; }
		}

		[DataMember(Name="ClientId")]
		public Int32 ClientId {
			get { return _ClientId; }
			set { _ClientId = value; }
		}

		[DataMember(Name = "BibliothequeId")]

		public Int32 BibliothequeId {
			get { return _BibliothequeId; }
			set { _BibliothequeId = value; }
		}

    }
}
