using System;
using System.Runtime.Serialization;

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
		private ClientBO _Client;
		private AdministrateurBO _Administrateur;
		private SessionManagerBO _SessionManager;


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

		[DataMember(Name="SessionManager")]
		public SessionManagerBO SessionManager {
			get { return _SessionManager; }
			set { _SessionManager = value; }
		}

		[DataMember(Name = "Administrateur")]
		public AdministrateurBO Administrateur {
			get { return _Administrateur; }
			set { _Administrateur = value; }
		}
		
		[DataMember(Name="Client")]
		public ClientBO Client {
			get { return _Client; }
			set { _Client = value; }
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

		public override string ToString() {
			return this.PersonneFirstName + " " + this.PersonneLastName;
		}
	}
}
