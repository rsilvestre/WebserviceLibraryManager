using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsDAL;
using WebsBO;
using WebsBL;

namespace WebsBL {
	public static class DemandeAnnulationBL {
		public static List<DemandeAnnulationBO> SelectById(String Token, Int32 pDemandeAnnulationId) {
			if (!Autorization.Validate(Token)) {
				return new List<DemandeAnnulationBO>();
			}
			List<DemandeAnnulationBO> lstResult;

			try {
				using (DemandeAnnulationDAL demandeAnnulationDal = new DemandeAnnulationDAL(Util.GetConnection())) {
					lstResult = demandeAnnulationDal.DemandeAnnulationDAL_SelectById(pDemandeAnnulationId).ToList();
				}
			} catch (Exception ex) {
				throw;
			}

			return lstResult;
		}
	}
}
