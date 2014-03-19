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
		private String _ClientName;
		private String _ClientSurname;
		private String _ClientPhoneNumber;

		public ClientBO() { }

		public ClientBO(Int32 pClientId, String pClientName, String pClientSurname, String pClientPhoneNumber) {
			ClientId = pClientId;
			ClientName = pClientName;
			ClientSurname = pClientSurname;
			ClientPhoneNumber = pClientPhoneNumber;
		}

		[DataMember(Name="ClientId")]
		public Int32 ClientId {
			get { return _ClientId; }
			set { _ClientId = value; }
		}

		[DataMember(Name="ClientName")]
		public String ClientName {
			get { return _ClientName; }
			set { _ClientName = value; }
		}

		[DataMember(Name="ClientSurname")]
		public String ClientSurname {
			get { return _ClientSurname; }
			set { _ClientSurname = value; }
		}

		[DataMember(Name="ClientPhoneNumber")]
		public String ClientPhoneNumber {
			get { return _ClientPhoneNumber; }
			set { _ClientPhoneNumber = value; }
		}

    }
}
