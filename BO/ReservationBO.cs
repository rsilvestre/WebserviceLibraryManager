using System;
using System.Runtime.Serialization;

namespace WebsBO {
	[DataContract(Namespace = "urn:WebsBO.ReservationBO")]
	public class ReservationBO {
		private Int32 _ReservationId;
		private Int32 _EmpruntId;
		private Int32 _LivreId;
		private Int32 _ActionId;
		private Int32 _DemandeReservationId;
		private DateTime _CreatedAt;
		private EmpruntBO _emprunt;
		private DemandeReservationBO _demandeReservation;

		public ReservationBO() { }

		public ReservationBO(Int32 pReservationId, Int32 pEmpruntId, Int32 pActionId, Int32 pLivreId, Int32 pDemandeReservationId, DateTime pCreatedAt) {
			ReservationId = pReservationId;
			EmpruntId = pEmpruntId;
			ActionId = pActionId;
			LivreId = pLivreId;
			CreatedAt = pCreatedAt;
			DemandeReservationId = pDemandeReservationId;
		}
		
		[DataMember(Name="DemandeReservationId")]
		public Int32 DemandeReservationId {
			get { return _DemandeReservationId; }
			set { _DemandeReservationId = value; }
		}
		
		[DataMember(Name="CreatedAt")]
		public DateTime CreatedAt {
			get { return _CreatedAt; }
			set { _CreatedAt = value; }
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
		
		[DataMember(Name="ReservationId")]
		public Int32 ReservationId {
			get { return _ReservationId; }
			set { _ReservationId = value; }
		}
		
		[DataMember(Name="Emprunt")]
		public EmpruntBO Emprunt{
			get { return _emprunt; }
			set { _emprunt = value; }
		}
		
		[DataMember(Name="DemandeReservation")]
		public DemandeReservationBO DemandeReservation{
			get { return _demandeReservation; }
			set { _demandeReservation = value; }
		}
	}
}
