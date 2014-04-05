using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using WebsBL;
using WebsIFAC;

namespace WebsFAC
{
    public class ClientFAC : ClientIFAC {
		public List<ClientBO> SelectAll() {
			try {
				return ClientBL.SelectAll().ToList();
			} catch (Exception Ex) { 
				throw; 
			}
		}

		public ClientBO SelectById(Int32 pId) {
			try {
				return ClientBL.SelectById(pId);
			} catch (Exception Ex) {
				throw;
			}
		}
	}
}
