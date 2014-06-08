using System;
using System.Runtime.Serialization;

namespace WebsBO {
	[DataContract(Namespace="uri:WebsBO.LivreStatusBO")]
	public class LivreStatusBO {
		private Int32 _LivreStatusId;
		private String _LivreStatusValue;

		public LivreStatusBO() { }

		public LivreStatusBO(Int32 pLivreStatusId, String pLivreStatusValue) {
			LivreStatusId = pLivreStatusId;
			LivreStatusValue = pLivreStatusValue;
		}

		public String LivreStatusValue {
			get { return _LivreStatusValue; }
			set { _LivreStatusValue = value; }
		}

		public Int32 LivreStatusId {
			get { return _LivreStatusId; }
			set { _LivreStatusId = value; }
		}
	}
}
