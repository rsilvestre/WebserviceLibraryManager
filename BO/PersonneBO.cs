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
		private String _personneUsername;
		private String _personneEmail;
		private String _personnePassword;

		public PersonneBO() { }

		public PersonneBO(Int32 pPersonneId, String pPersonneMatricule, String pPersonneFirstName, String pPersonneLastName, String pPersonneUsername, String pPersonneEmail, String pPersonnePassword ) {
			PersonneId = pPersonneId;
			PersonneMatricule = pPersonneMatricule;
			PersonneFirstName = pPersonneFirstName;
			PersonneLastName = pPersonneLastName;
			PersonneUsername = pPersonneUsername;
			PersonneEmail = pPersonneEmail;
			PersonnePassword = pPersonnePassword;
		}

		[DataMember(Name="PersonnePassword")]
		public String PersonnePassword {
			get { return _personnePassword; }
			set { _personnePassword = value; }
		}

		[DataMember(Name="PersonneEmail")]
		public String PersonneEmail {
			get { return _personneEmail; }
			set { _personneEmail = value; }
		}

		[DataMember(Name="PersonneUsername")]
		public String PersonneUsername {
			get { return _personneUsername; }
			set { _personneUsername = value; }
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
