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
		public List<DemandeAnnulationBO> SelectById(int pDemandeAnnulationId) {
			try {
				return DemandeAnnulationBL.SelectById(pDemandeAnnulationId);
			} catch (Exception ex) {
				throw;
			}
		}
	}
}
