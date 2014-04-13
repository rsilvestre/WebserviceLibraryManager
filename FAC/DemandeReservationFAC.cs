using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using WebsBL;
using WebsIFAC;

namespace WebsFAC {
	public class DemandeReservationFAC : DemandeReservationIFAC	{
		public List<DemandeReservationBO> SelectById(int pDemandeReservationId) {
			try {
				return DemandeReservationBL.SelectById(pDemandeReservationId);
			} catch (Exception ex) {
				throw;
			}
		}
	}
}
