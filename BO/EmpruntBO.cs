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
		private String _ClientName;
		private DateTime _EmpruntDate;

		public EmpruntBO() { }

		public EmpruntBO(Int32 pEmpruntId, String pClientName, DateTime pEmpruntDate) {
			EmpruntId = pEmpruntId;
			ClientName = pClientName;
			EmpruntDate = pEmpruntDate;
		}

		[DataMember(Name="EmpruntId")]
		public Int32 EmpruntId {
			get { return _EmpruntId; }
			set { _EmpruntId = value; }
		}

		[DataMember(Name="ClientName")]
		public String ClientName {
			get { return _ClientName; }
			set { _ClientName = value; }
		}

		[DataMember(Name="EmpruntDate")]
		public DateTime EmpruntDate {
			get { return _EmpruntDate; }
			set { _EmpruntDate = value; }
		}
	}
}
