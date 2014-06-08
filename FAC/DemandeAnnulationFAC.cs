﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using WebsBL;
using WebsIFAC;

namespace WebsFAC {
	public class DemandeAnnulationFAC : DemandeAnnulationIFAC {
		public List<DemandeAnnulationBO> SelectById(String token, Int32 pDemandeAnnulationId) {
			if (!Autorization.Validate(token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return DemandeAnnulationBL.SelectById(pDemandeAnnulationId);
			} catch (Exception ex) {
				throw;
			}
		}

		public DemandeAnnulationBO InsertDemandeAnnulation(String token, Int32 pAdministrateurId, Int32 pDemandeReservationId){
			if (!Autorization.Validate(token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return DemandeAnnulationBL.InsertDemandeAnnulation(pAdministrateurId, pDemandeReservationId);
			} catch (Exception ex) {
				throw;
			}
		}
	}
}
