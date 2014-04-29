using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebsBO {
	[DataContract(Namespace = "urn:WebsBO.EmpruntBO")]
	public class EmpruntBO {
		private Int32 _EmpruntId;
		private Int32 _ClientId;
		private DateTime _EmpruntDate;

		public EmpruntBO() { }

		public EmpruntBO(Int32 pEmpruntId, Int32 pClientId, DateTime pEmpruntDate) {
			EmpruntId = pEmpruntId;
			ClientId = pClientId;
			EmpruntDate = pEmpruntDate;
		}

		[DataMember(Name="EmpruntId")]
		public Int32 EmpruntId {
			get { return _EmpruntId; }
			set { _EmpruntId = value; }
		}

		[DataMember(Name = "ClientId")]
		public Int32 ClientId {
			get { return _ClientId; }
			set { _ClientId = value; }
		}

		[DataMember(Name="EmpruntDate")]
		public DateTime EmpruntDate {
			get { return _EmpruntDate; }
			set { _EmpruntDate = value; }
		}
	}
}
