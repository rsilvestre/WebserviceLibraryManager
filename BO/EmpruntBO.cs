using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebsBO {
	[DataContract(Namespace = "urn:WebsBO.EmpruntBO")]
	public class EmpruntBO {

		private Int32 _EmpruntId;
		private Int32 _LivreId;
		private Int32 _ActionId;
		private String _State;
		private DateTime _CreatedAt;
		private Int32 ?_AdministrateurId;
		private Int32 ?_ClientId;
		private LivreBO _Livre;
		private List<DemandeReservationBO> _lstDemandeReservation;
		private ClientBO _Client;
		private PersonneBO _personne;

		public EmpruntBO() { }

		public EmpruntBO(Int32 pEmpruntId, Int32 pLivreId, Int32 pActionId, String pState, DateTime pCreatedAt, Int32 pAdministrateurId, Int32 pClientId) {
			EmpruntId = pEmpruntId;
			LivreId = pLivreId;
			ActionId = pActionId;
			State = pState;
			CreatedAt = pCreatedAt;
			AdministrateurId = pAdministrateurId;
			ClientId = pClientId;
		}
		
		[DataMember(Name="Livre")]
		public LivreBO Livre {
			get { return _Livre; }
			set { _Livre = value; }
		}

		[DataMember(Name="ClientId")]
		public Int32? ClientId {
			get { return _ClientId; }
			set { _ClientId = value; }
		}
		
		[DataMember(Name="AdministrateurId")]
		public Int32? AdministrateurId {
			get { return _AdministrateurId; }
			set { _AdministrateurId = value; }
		}
		
		[DataMember(Name="CreatedAt")]
		public DateTime CreatedAt {
			get { return _CreatedAt; }
			set { _CreatedAt = value; }
		}
		
		[DataMember(Name="State")]
		public String State {
			get { return _State; }
			set { _State = value; }
		}
		
		[DataMember(Name="ActionId")]
		public Int32 ActionId {
			get { return _ActionId; }
			set { _ActionId = value; }
		}
		
		[DataMember(Name="LivreId")]
		public Int32 LivreId {
			get { return _LivreId; }
			set { _LivreId = value; }
		}
		
		[DataMember(Name="EmpruntId")]
		public Int32 EmpruntId {
			get { return _EmpruntId; }
			set { _EmpruntId = value; }
		}

		[DataMember(Name = "LstDemandeReservation")]
		public List<DemandeReservationBO> LstDemandeReservation{
			get { return _lstDemandeReservation; }
			set { _lstDemandeReservation = value; }
		}
		
		[DataMember(Name = "Client")]
		public ClientBO Client{
			get { return _Client; }
			set { _Client = value; }
		}
		
		[DataMember(Name="Personne")]
		public PersonneBO Personne{
			get { return _personne; }
			set { _personne = value; }
		}
	}
}
