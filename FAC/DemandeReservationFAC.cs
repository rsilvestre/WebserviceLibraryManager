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
		public List<DemandeReservationBO> SelectById(String Token, int pDemandeReservationId) {
			try {
				return DemandeReservationBL.SelectById(Token, pDemandeReservationId);
			} catch (Exception ex) {
				throw;
			}
		}

		public List<DemandeReservationBO> SelectByClient(String Token, ClientBO pClient) {
			try {
				return DemandeReservationBL.SelectByClient(Token, pClient);
			} catch (Exception ex) {
				throw;
			}
		}

		public DemandeReservationBO InsertDemandeReservation(String Token, DemandeReservationBO pDemandeReservation) {
			try {
				return DemandeReservationBL.InsertDemandeReservation(Token, pDemandeReservation);
			} catch (Exception ex) {
				throw;
			}
		}
	}
}
