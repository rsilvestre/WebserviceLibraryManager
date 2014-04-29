using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using WebsBL;
using WebsIFAC;

namespace WebsFAC {
	public class DemandeAnnulationFAC : DemandeAnnulationIFAC {
		public List<DemandeAnnulationBO> SelectById(String Token, int pDemandeAnnulationId) {
			try {
				return DemandeAnnulationBL.SelectById(Token, pDemandeAnnulationId);
			} catch (Exception ex) {
				throw;
			}
		}
	}
}
