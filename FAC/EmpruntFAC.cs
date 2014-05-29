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
			if (!Autorization.Validate(Token)) {
				return null;
			}
			try {
				return EmpruntBL.SelectAll();
			} catch (Exception Ex) {
				throw;
			}
		}

		public EmpruntBO SelectEmpruntById(String Token, Int32 pId) {
			if (!Autorization.Validate(Token)) {
				return null;
			}
			try {
				return EmpruntBL.SelectById(pId);
			} catch (Exception Ex) {
				throw;
			}
		}
	}
}
