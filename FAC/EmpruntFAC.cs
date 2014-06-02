using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBL;
using WebsBO;
using WebsIFAC;

namespace WebsFAC {
	public class EmpruntFAC : EmpruntIFAC {
		public List<EmpruntBO> SelectAll(String Token) {
			if (!Autorization.Validate(Token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return EmpruntBL.SelectAll();
			} catch (Exception Ex) {
				throw;
			}
		}

		public EmpruntBO SelectEmpruntById(String Token, Int32 pId) {
			if (!Autorization.Validate(Token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return EmpruntBL.SelectById(pId);
			} catch (Exception Ex) {
				throw;
			}
		}


		public EmpruntBO InsertEmpruntFromReservation(String Token, ReservationBO pReservation) {
			if (!Autorization.Validate(Token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return EmpruntBL.InsertEmpruntFromReservation(pReservation);
			} catch (Exception Ex) {
				throw;
			}
		}

		public EmpruntBO InsertEmpruntFromReservation(String Token, Int32 pReservationId) {
			if (!Autorization.Validate(Token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return EmpruntBL.InsertEmpruntFromReservation(pReservationId);
			} catch (Exception Ex) {
				throw;
			}
		}

		public EmpruntBO InsertEmprunt(String Token, Int32 pBibliothequeId, Int32 pPersonneId, Int32 pLivreId) {
			if (!Autorization.Validate(Token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return EmpruntBL.InsertEmprunt(pBibliothequeId, pPersonneId, pLivreId);
			} catch (Exception Ex) {
				throw;
			}
		}
	}
}
