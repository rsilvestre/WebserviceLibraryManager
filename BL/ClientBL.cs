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
		public static List<ClientBO> SelectAll() {
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

		public static ClientBO SelectClientById(Int32 pId) {
			ClientBO result = null;
			try {
				using (ClientDAL clientDal = new ClientDAL(Util.GetConnection())) {
					result = (ClientBO)clientDal.ClientBO_SelectClientById(pId);
				}
			} catch (Exception Ex) { 
				throw;  
			}
			return result;
		}
    }
}
