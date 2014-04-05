using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebsBO {
	[DataContract(Namespace = "urn:WebsBO.PersonneBO")]
	public class PersonneBO {
		private Int32 _personneId;

		private String _personneMatricule;

		private String _personneFirstName;

		private String _personneLastName;

		public PersonneBO() { }

		public PersonneBO(Int32 pPersonneId, String pPersonneMatricule, String pPersonneFirstName, String pPersonneLastName ) {
			PersonneId = pPersonneId;
			PersonneMatricule = pPersonneMatricule;
			PersonneFirstName = pPersonneFirstName;
			PersonneLastName = pPersonneLastName;
		}

		[DataMember(Name="PersonneId")]
		public Int32 PersonneId {
			get { return _personneId; }
			set { _personneId = value; }
		}

		[DataMember(Name="PersonneMatricule")]
		public String PersonneMatricule {
			get { return _personneMatricule; }
			set { _personneMatricule = value; }
		}

		[DataMember(Name="PersonneLastName")]
		public String PersonneFirstName {
			get { return _personneFirstName; }
			set { _personneFirstName = value; }
		}

		[DataMember(Name="PersonneFirstName")]
		public String PersonneLastName {
			get { return _personneLastName; }
			set { _personneLastName = value; }
		}


	}
}
