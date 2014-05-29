using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WebsBO {
	[DataContract(Namespace = "urn:WebsBO.SessionManagerBO")]
	public class SessionManagerBO {
		private Int32 _SessionId;
		private Int32 _PersonneId;
		private String _Token;
		private DateTime _CreatedAt;
		private Int32 _UserRole;
		private PersonneBO _Personne;
		private Boolean _IsAdministrateur;

		public SessionManagerBO() { }

		public SessionManagerBO(Int32 pSessionId, Int32 pPersonneId, String pToken, DateTime pCreatedAt, Int32 pUserRole) {
			SessionId = pSessionId;
			PersonneId = pPersonneId;
			Token = pToken;
			CreatedAt = pCreatedAt;
			UserRole = pUserRole;
		}

		[DataMember(Name="IsAdministrateur")]
		public Boolean IsAdministrateur {
			get { return _IsAdministrateur; }
			set { _IsAdministrateur = value; }
		}

		[DataMember(Name="Personne")]
		public PersonneBO Personne {
			get { return _Personne; }
			set { 
				_Personne = value;
				if (value != null && this.PersonneId == 0 && value.PersonneId != 0) {
					this.PersonneId = value.PersonneId;
				}
			}
		}

		[DataMember(Name="SessionId")]
		public Int32 SessionId {
			get { return _SessionId; }
			set { _SessionId = value; }
		}

		[DataMember(Name = "PersonneId")]
		public Int32 PersonneId {
			get { return _PersonneId; }
			set { _PersonneId = value; }
		}

		[DataMember(Name = "Token")]
		public String Token {
			get { return _Token; }
			set { _Token = value; }
		}

		[DataMember(Name = "CreatedAt")]
		public DateTime CreatedAt {
			get { return _CreatedAt; }
			set { _CreatedAt = value; }
		}

		[DataMember(Name="UserRole")]
		public Int32 UserRole {
			get { return _UserRole; }
			set { _UserRole = value; }
		}
	}
}
