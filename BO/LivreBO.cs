using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebsBO {
	[DataContract(Namespace="uri:WebsBO.LivreBO")]
	public class LivreBO {
		private int _LivreId;
		private int _BibliothequeId;
		private int _RefLivreId;
		private String _InternalReference;
		private DateTime _CreatedAt;

		public LivreBO() { }

		public LivreBO(int pLivreId, int pBibliotheteId, int pRefLivreId, String pInternalReference, DateTime pCreatedAt) : this() {
			LivreId = pLivreId;
			BibliothequeId = pBibliotheteId;
			RefLivreId = pRefLivreId;
			InternalReference = pInternalReference;
			CreatedAt = pCreatedAt;
		}

		[DataMember(Name="CreatedAt")]
		public DateTime CreatedAt {
			get { return _CreatedAt; }
			set { _CreatedAt = value; }
		}

		[DataMember(Name="InternalReference")]
		public String InternalReference {
			get { return _InternalReference; }
			set { _InternalReference = value; }
		}

		[DataMember(Name="RefLivreId")]
		public int RefLivreId {
			get { return _RefLivreId; }
			set { _RefLivreId = value; }
		}

		[DataMember(Name="BibliothequeId")]
		public int BibliothequeId {
			get { return _BibliothequeId; }
			set { _BibliothequeId = value; }
		}

		[DataMember(Name="LivreId")]
		public int LivreId {
			get { return _LivreId; }
			set { _LivreId = value; }
		}
	}
}
