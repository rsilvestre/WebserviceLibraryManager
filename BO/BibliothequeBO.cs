using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebsBO {
	[DataContract(Namespace = "uri:WebsBO.BibliothequeBO")]
	public class BibliothequeBO {
		private Int32 _BibliothequeId;
		private String _BibliothequeName;

		public BibliothequeBO() { }

		public BibliothequeBO(Int32 pBibliothequeId, String pBibliothequeName) : this() {
			BibliothequeId = pBibliothequeId;
			BibliothequeName = pBibliothequeName;
		}

		[DataMember(Name="BibliothequeName")]
		public String BibliothequeName {
			get { return _BibliothequeName; }
			set { _BibliothequeName = value; }
		}

		[DataMember(Name="BibliothequeId")]
		public Int32 BibliothequeId {
			get { return _BibliothequeId; }
			set { _BibliothequeId = value; }
		}

		public override string ToString() {
			return BibliothequeName;
		}
	}
}
