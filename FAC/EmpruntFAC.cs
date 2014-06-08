using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebsBL;
using WebsBO;
using WebsIFAC;

namespace WebsFAC {
	public class EmpruntFAC : EmpruntIFAC {
		public List<EmpruntBO> SelectAll(String token) {
			if (!Autorization.Validate(token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return EmpruntBL.SelectAll();
			} catch (Exception Ex) {
				throw;
			}
		}

		public EmpruntBO SelectEmpruntById(String token, Int32 pId) {
			if (!Autorization.Validate(token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return EmpruntBL.SelectById(pId);
			} catch (Exception Ex) {
				throw;
			}
		}

		public List<EmpruntBO> SelectEmpruntByClientId(String token, Int32 pClientId) {
			if (!Autorization.Validate(token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return EmpruntBL.SelectByClientId(pClientId);
			} catch (Exception Ex) {
				throw;
			}
		}

		public EmpruntBO ConvertReservation(String token, Int32 pAdministrateurId, Int32 pReservationId) {
			if (!Autorization.Validate(token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return EmpruntBL.ConvertReservation(pAdministrateurId, pReservationId);
			} catch (Exception Ex) {
				throw;
			}
		}

		public EmpruntBO InsertEmprunt(String token, Int32 pAdministrateurId, Int32 pPersonneId, Int32 pLivreId) {
			if (!Autorization.Validate(token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return EmpruntBL.InsertEmprunt(pAdministrateurId, pPersonneId, pLivreId);
			} catch (Exception Ex) {
				throw;
			}
		}

		public EmpruntBO InsertRetour(String token, Int32 pAdministrateurId, Int32 pLivreId) {
			if (!Autorization.Validate(token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return EmpruntBL.InsertRetour(pAdministrateurId, pLivreId);
			} catch (Exception Ex) {
				throw;
			}
		}

		public EmpruntBO InsertAnnul(String token, Int32 pAdministrateurId, Int32 pReservationId) {
			if (!Autorization.Validate(token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return EmpruntBL.InsertAnnul(pAdministrateurId, pReservationId);
			} catch (Exception Ex) {
				throw;
			}
		}
	}
}
