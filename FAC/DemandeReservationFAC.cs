using System;
using System.Collections.Generic;
using WebsBO;
using WebsBL;
using WebsIFAC;

namespace WebsFAC {
	public class DemandeReservationFAC : DemandeReservationIFAC	{
		public DemandeReservationBO SelectById(String token, int pDemandeReservationId) {
			if (!Autorization.Validate(token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return DemandeReservationBL.SelectById(pDemandeReservationId);
			} catch (Exception ex) {
				throw;
			}
		}

		public List<DemandeReservationBO> SelectAll(String token) {
			if (!Autorization.Validate(token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return DemandeReservationBL.SelectAll();
			} catch (Exception ex) {
				throw;
			}
		}

		public List<DemandeReservationBO> SelectNewByClient(String token, ClientBO pClient) {
			if (!Autorization.Validate(token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return DemandeReservationBL.SelectNewByClient(pClient);
			} catch (Exception ex) {
				throw;
			}
		}

		public List<DemandeReservationBO> SelectOldByClient(String token, ClientBO pClient) {
			if (!Autorization.Validate(token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return DemandeReservationBL.SelectOldByClient(pClient);
			} catch (Exception ex) {
				throw;
			}
		}

		public DemandeReservationBO InsertDemandeReservation(String token, DemandeReservationBO pDemandeReservation) {
			if (!Autorization.Validate(token, Autorization.Role.CLIENT)) {
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
