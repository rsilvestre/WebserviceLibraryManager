using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WebsBO {
	[DataContract(Namespace = "urn:WebsBO.AdministrateurBibliotheque")]
	public class AdministrateurBibliothequeBO {
		private Int32 _BibliothequeId;
		private Int32 _AdministrateurId;
		private DateTime _CreatedAt;

		public AdministrateurBibliothequeBO() { }

		public AdministrateurBibliothequeBO(Int32 pBibliothequeId, Int32 pAdministrateurId, DateTime pCreatedAt) {
			Created_at = pCreatedAt;
			AdministrateurId = pAdministrateurId;
			BibliothequeId = pBibliothequeId;
		}

		[DataMember(Name="CreatedAt")]
		public DateTime Created_at {
			get { return _CreatedAt; }
			set { _CreatedAt = value; }
		}

		[DataMember(Name="AdministrateurId")]
		public Int32 AdministrateurId {
			get { return _AdministrateurId; }
			set { _AdministrateurId = value; }
		}

		[DataMember(Name="BibliothequeId")]
		public Int32 BibliothequeId {
			get { return _BibliothequeId; }
			set { _BibliothequeId = value; }
		}
	}
}
