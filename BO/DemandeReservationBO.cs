using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WebsBO {
	[DataContract(Namespace = "urn:WebsBO.DemandeReservationBO")]
	public class DemandeReservationBO {
		private Int32 _DemandeReservationId;
		private Int32 _ClientId;
		private ClientBO _Client;
		private Int32 _RefLivreId;
		private RefLivreBO _RefLivre;
		private DateTime _CreatedAt;
		private Int32 _Valide;
		private PersonneBO _personne;

		public DemandeReservationBO() { }

		public DemandeReservationBO(Int32 pDemandeReservationId, Int32 pClientId, Int32 pRefLivreId, DateTime pCreatedAt, Int32 pValide = 0) : this() {
			DemandeReservationId = pDemandeReservationId;
			ClientId = pClientId;
			RefLivreId = pRefLivreId;
			CreatedAt = pCreatedAt;
			Valide = pValide;
		}

		[DataMember(Name="Valide")]
		public Int32 Valide {
			get { return _Valide; }
			set { _Valide = value; }
		}

		[DataMember(Name="CreatedAt")]
		public DateTime CreatedAt {
			get { return _CreatedAt; }
			set { _CreatedAt = value; }
		}

		[DataMember(Name="RefLivre")]
		public RefLivreBO RefLivre {
			get { return _RefLivre; }
			set { 
				_RefLivre = value;
				if (value != null && RefLivreId == 0) {
					RefLivreId = value.RefLivreId;
				}
			}
		}

		[DataMember(Name = "RefLivreId")]
		public Int32 RefLivreId {
			get { return _RefLivreId; }
			set { _RefLivreId = value; }
		}

		[DataMember(Name = "Client")]
		public ClientBO Client {
			get { return _Client; }
			set { 
				_Client = value;
				if (value != null && ClientId == 0) {
					ClientId = value.ClientId;
				}
			}
		}

		[DataMember(Name = "ClientId")]
		public Int32 ClientId {
			get { return _ClientId; }
			set { _ClientId = value; }
		}

		[DataMember(Name = "DemandeReservationId")]
		public Int32 DemandeReservationId {
			get { return _DemandeReservationId; }
			set { _DemandeReservationId = value; }
		}
		
		[DataMember(Name = "Personne")]
		public PersonneBO Personne{
			get { return _personne; }
			set { _personne = value; }
		}

		public override string ToString() {
			return this.RefLivre.ToString();
		}
	}
}
