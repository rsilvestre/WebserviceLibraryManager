using System;
using System.Runtime.Serialization;

namespace WebsBO {
	[DataContract(Namespace = "WebsBO.ItemBO")]
	public class ItemBO{
		private Int32 _ItemId;
		private Int32 _EmpruntId;
		private Int32 _LivreId;
		private Int32 _ActionId;
		private Int32 _ClientId;
		private Int32 _AdministrateurId;
		private Decimal _Montant;
		private Decimal _Amende;
		private Decimal _Count;
		private DateTime _DebutDate;
		private DateTime _CreatedAt;
		private EmpruntBO _emprunt;
		private LivreBO _livre;
		private ClientBO _client;
		private AdministrateurBO _administrateur;
		private PersonneBO _personne;

		public ItemBO() { }

		public ItemBO(Int32 pItemId, Int32 pEmpruntId, Int32 pLivreId, Int32 pActionId, Int32 pClientId, Int32 pAdministrateurId, Decimal pMontant, DateTime pCreatedAt){
			ItemId = pItemId;
			EmpruntId = pEmpruntId;
			LivreId = pLivreId;
			ActionId = pActionId;
			ClientId = pClientId;
			AdministrateurId = pAdministrateurId;
			Montant = pMontant;
			CreatedAt = pCreatedAt;
		}

		[DataMember(Name = "ItemId")]
		public int ItemId{
			get { return _ItemId; }
			set { _ItemId = value; }
		}
		
		[DataMember(Name = "EmpruntId")]
		public int EmpruntId{
			get { return _EmpruntId; }
			set { _EmpruntId = value; }
		}
		
		[DataMember(Name = "LivreId")]
		public int LivreId{
			get { return _LivreId; }
			set { _LivreId = value; }
		}
		
		[DataMember(Name = "ActionId")]
		public int ActionId{
			get { return _ActionId; }
			set { _ActionId = value; }
		}
		
		[DataMember(Name = "ClientId")]
		public int ClientId{
			get { return _ClientId; }
			set { _ClientId = value; }
		}
		
		[DataMember(Name = "AdministrateurId")]
		public int AdministrateurId{
			get { return _AdministrateurId; }
			set { _AdministrateurId = value; }
		}
		
		[DataMember(Name = "Montant")]
		public Decimal Montant{
			get { return _Montant; }
			set { _Montant = value; }
		}
		
		[DataMember(Name = "Amende")]
		public decimal Amende {
			get { return _Amende; }
			set { _Amende = value; }
		}
		
		[DataMember(Name = "Count")]
		public decimal Count {
			get { return _Count; }
			set { _Count = value; }
		}
		
		[DataMember(Name = "DebutDate")]
		public DateTime DebutDate {
			get { return _DebutDate; }
			set { _DebutDate = value; }
		}
		
		[DataMember(Name = "CreatedAt")]
		public DateTime CreatedAt{
			get { return _CreatedAt; }
			set { _CreatedAt = value; }
		}
		
		[DataMember(Name = "Emprunt")]
		public EmpruntBO Emprunt{
			get { return _emprunt; }
			set{
				_emprunt = value;
				if (Emprunt == null){
					return;
				}
				Livre = value.Livre;
				Personne = value.Personne;
				Client = value.Client;
			}
		}
		
		[DataMember(Name = "Livre")]
		public LivreBO Livre{
			get { return _livre; }
			set { _livre = value; }
		}
		
		[DataMember(Name = "Client")]
		public ClientBO Client{
			get { return _client; }
			set { _client = value; }
		}
		
		[DataMember(Name = "Administrateur")]
		public AdministrateurBO Administrateur{
			get { return _administrateur; }
			set { _administrateur = value; }
		}
		
		[DataMember(Name = "Personne")]
		public PersonneBO Personne{
			get { return _personne; }
			set { _personne = value; }
		}
	}
}
