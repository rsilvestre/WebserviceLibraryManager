using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WebsBO {
	[DataContract(Namespace="urn:WebsBO.AdministrateurClient")]
	public class AdministrateurClientBO {
		private Int32 _AdministrateurId;
		private Int32 _ClientId;
		private DateTime _CreatedAt;

		public AdministrateurClientBO() { }

		public AdministrateurClientBO(Int32 pAdministrateurId, Int32 pClientId, DateTime pCreatedAt) {
			AdministrateurId = pAdministrateurId;
			ClientId = pClientId;
			CreatedAt = pCreatedAt;
		}

		[DataMember(Name="CreatedAt")]
		public DateTime CreatedAt {
			get { return _CreatedAt; }
			set { _CreatedAt = value; }
		}

		[DataMember(Name="ClientId")]
		public Int32 ClientId {
			get { return _ClientId; }
			set { _ClientId = value; }
		}

		[DataMember(Name="AdministrateurId")]
		public Int32 AdministrateurId {
			get { return _AdministrateurId; }
			set { _AdministrateurId = value; }
		}
	}
}
