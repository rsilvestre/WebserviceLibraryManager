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
		public List<ClientBO> SelectAll(String Token) {
			try {
				return ClientBL.SelectAll(Token);
			} catch (Exception Ex) { 
				throw; 
			}
		}

		public ClientBO SelectById(String Token, Int32 pId) {
			try {
				return ClientBL.SelectById(Token, pId);
			} catch (Exception Ex) {
				throw;
			}
		}
	}
}
