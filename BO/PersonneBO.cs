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

		private String _personneName;

		private String _personnaSurname;

		public PersonneBO() { }

		public PersonneBO(Int32 pPersonneId, String pPersonneMatricule, String pPersonneName, String pPersonneSurname ) {
			PersonneId = pPersonneId;
			PersonneMatricule = pPersonneMatricule;
			PersonneName = pPersonneName;
			PersonnaSurname = pPersonneSurname;
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

		[DataMember(Name="PersonneName")]
		public String PersonneName {
			get { return _personneName; }
			set { _personneName = value; }
		}

		[DataMember(Name="PersonneSurname")]
		public String PersonnaSurname {
			get { return _personnaSurname; }
			set { _personnaSurname = value; }
		}


	}
}
