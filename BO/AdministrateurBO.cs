using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebsBO {
	[DataContract(Namespace="WebsBO.AdministrateurBO")]
	public class AdministrateurBO {
		private Int32 _AdministrateurId;
		private List<BibliothequeBO> _LstBibliotheque;

		public AdministrateurBO() { }

		public AdministrateurBO(Int32 pAdministrateurId) {
			AdministrateurId = pAdministrateurId;
		}
		
		[DataMember(Name="LstBibliotheque")]
		public List<BibliothequeBO> LstBibliotheque {
			get { return _LstBibliotheque; }
			set { _LstBibliotheque = value; }
		}

		[DataMember(Name="AdministrateurId")]
		public Int32 AdministrateurId {
			get { return _AdministrateurId; }
			set { _AdministrateurId = value; }
		}

	}
}
