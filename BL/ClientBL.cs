using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using WebsDAL;

namespace WebsBL
{
    public static class ClientBL {
		public static List<ClientBO> SelectAll(String Token) {
			if (!Autorization.Validate(Token)) {
				return new List<ClientBO>();
			}
			List<ClientBO> lstResult = null;
			try {
				using (ClientDAL clientDal = new ClientDAL(Util.GetConnection())) {
					lstResult = clientDal.ClientBO_SelectAll().ToList();
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstResult;
		}

		public static ClientBO SelectById(String Token, Int32 pId) {
			ClientBO objClientResult = null;
			try {
				using (ClientDAL clientDal = new ClientDAL(Util.GetConnection())) {
					List<ClientBO> tmpObjClient = clientDal.ClientBO_SelectById(pId).ToList();
					if (tmpObjClient.Count() > 0) {
						objClientResult = tmpObjClient[0];
						objClientResult.LstDemandeReservation = DemandeReservationBL.SelectByClientId(Token, objClientResult.ClientId);
						objClientResult.Bibliotheque = BibliothequeBL.SelectById(Token, objClientResult.BibliothequeId);
					}
				}
			} catch (Exception Ex) { 
				throw;  
			}
			return objClientResult;
		}
    }
}
