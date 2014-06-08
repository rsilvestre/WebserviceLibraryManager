using System;
using System.Collections.Generic;
using WebsBO;
using WebsBL;
using WebsIFAC;

namespace WebsFAC
{
    public class ClientFAC : ClientIFAC {
		public List<ClientBO> SelectAll(String Token) {
			if (!Autorization.Validate(Token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return ClientBL.SelectAll();
			} catch (Exception Ex) { 
				throw; 
			}
		}

		public ClientBO SelectById(String Token, Int32 pId) {
			if (!Autorization.Validate(Token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return ClientBL.SelectById(pId);
			} catch (Exception Ex) {
				throw;
			}
		}
	}
}
