using System;
using System.Runtime.Serialization;

namespace WebsBO {
	[DataContract(Namespace="urn:Webs.RefLivreBO")]
	public class RefLivreBO : ICloneable {
		private Int32 _RefLivreId;
		private String _ISBN;
		private String _Titre;
		private String _Description;
		private String _Auteur;
		private String _Langue;
		private String _Editeur;
		private DateTime _Published;
		private String _ImageUrl;

		public RefLivreBO() { }

		public RefLivreBO(
			Int32 pRefLivreId,
			String pISBN,
			String pTitre,
			String pDescription,
			String pAuteur,
			String pLangue,
			String pEditeur,
			DateTime pTimestamp,
			String pImageUrl
			) {
			RefLivreId = pRefLivreId;
			ISBN = pISBN;
			Titre = pTitre;
			Description = pDescription;
			Auteur = pAuteur;
			Langue = pLangue;
			Editeur = pEditeur;
			Published = pTimestamp;
			ImageUrl = pImageUrl;
		}

		[DataMember(Name = "ImageUrl")]
		public String ImageUrl {
			get { return _ImageUrl; }
			set { _ImageUrl = value; }
		}

		[DataMember(Name = "Published")]
		public DateTime Published {
			get { return _Published; }
			set { _Published = value; }
		}

		[DataMember(Name="Editeur")]
		public String Editeur {
			get { return _Editeur; }
			set { _Editeur = value; }
		}

		[DataMember(Name="Langue")]
		public String Langue {
			get { return _Langue; }
			set { _Langue = value; }
		}

		[DataMember(Name="Auteur")]
		public String Auteur {
			get { return _Auteur; }
			set { _Auteur = value; }
		}

		[DataMember(Name="Description")]
		public String Description {
			get { return _Description; }
			set { _Description = value; }
		}

		[DataMember(Name="Titre")]
		public String Titre {
			get { return _Titre; }
			set { _Titre = value; }
		}

		[DataMember(Name="ISBN")]
		public String ISBN {
			get { return _ISBN; }
			set { _ISBN = value; }
		}

		[DataMember(Name="RefLivreId")]
		public Int32 RefLivreId {
			get { return _RefLivreId; }
			set { _RefLivreId = value; }
		}

		public object Clone() {
			return this.MemberwiseClone();
		}

		public override string ToString() {
			return Titre;
		}

	}
}
