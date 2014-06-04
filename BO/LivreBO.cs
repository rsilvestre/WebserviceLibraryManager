using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebsBO {
	[DataContract(Namespace="urn:WebsBO.LivreBO")]
	public class LivreBO : ICloneable {
		private Int32 _LivreId;
		private Int32 _BibliothequeId;
		private Int32 _RefLivreId;
		private String _InternalReference;
		private DateTime _CreatedAt;
		private RefLivreBO _RefLivre;
		private BibliothequeBO _Bibliotheque;

		public LivreBO() { }

		public LivreBO(int pLivreId, int pBibliotheteId, int pRefLivreId, String pInternalReference, DateTime pCreatedAt) : this() {
			LivreId = pLivreId;
			BibliothequeId = pBibliotheteId;
			RefLivreId = pRefLivreId;
			InternalReference = pInternalReference;
			CreatedAt = pCreatedAt;
		}

		[DataMember(Name="Bibliotheque")]
		public BibliothequeBO Bibliotheque {
			get { return _Bibliotheque; }
			set {
				_Bibliotheque = value;
				if (value != null && this.BibliothequeId == 0 && value.BibliothequeId != 0) {
					this.BibliothequeId = value.BibliothequeId;
				}
			}
		}

		[DataMember(Name="RefLivre")]
		public RefLivreBO RefLivre {
			get { return _RefLivre; }
			set {
				_RefLivre = value;
				if (value != null && this.RefLivreId == 0 && value.RefLivreId != 0) {
					this.RefLivreId = value.RefLivreId;
				}
			}
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
		public Int32 RefLivreId {
			get { return _RefLivreId; }
			set { _RefLivreId = value; }
		}

		[DataMember(Name="BibliothequeId")]
		public Int32 BibliothequeId {
			get { return _BibliothequeId; }
			set { _BibliothequeId = value; }
		}

		[DataMember(Name="LivreId")]
		public Int32 LivreId {
			get { return _LivreId; }
			set { _LivreId = value; }
		}

		public object Clone() {
			return this.MemberwiseClone();
		}

		public override string ToString() {
			return RefLivre.Titre;
		}
	}
}
