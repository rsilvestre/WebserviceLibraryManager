using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WebsBO {
	[DataContract(Namespace="uri:WebsBO.FicheLivreBO")]
	public class FicheLivreBO {
		private RefLivreBO _RefLivre;
		private List<EmpruntBO> _lstEmprunt;
		private List<DemandeReservationBO> _lstDemandeReservation;

		public FicheLivreBO() {
		}

		[DataMember(Name = "LstDemandeReservation")]
		public List<DemandeReservationBO> LstDemandeReservation {
			get { return _lstDemandeReservation; }
			set { _lstDemandeReservation = value; }
		}

		[DataMember(Name = "LstEmprunt")]
		public List<EmpruntBO> LstEmprunt {
			get { return _lstEmprunt; }
			set { _lstEmprunt = value; }
		}

		[DataMember(Name="RefLivre")]
		public RefLivreBO RefLivre {
			get { return _RefLivre; }
			set { _RefLivre = value; }
		}

	}
}
