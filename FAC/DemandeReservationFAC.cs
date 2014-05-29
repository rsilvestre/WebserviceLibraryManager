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
			if (!Autorization.Validate(Token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return DemandeReservationBL.SelectById(pDemandeReservationId);
			} catch (Exception ex) {
				throw;
			}
		}

		public List<DemandeReservationBO> SelectByClient(String Token, ClientBO pClient) {
			if (!Autorization.Validate(Token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return DemandeReservationBL.SelectByClient(pClient);
			} catch (Exception ex) {
				throw;
			}
		}

		public DemandeReservationBO InsertDemandeReservation(String Token, DemandeReservationBO pDemandeReservation) {
			if (!Autorization.Validate(Token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return DemandeReservationBL.InsertDemandeReservation(pDemandeReservation);
			} catch (Exception ex) {
				throw;
			}
		}
	}
}
