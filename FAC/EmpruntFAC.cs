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
			try {
				return EmpruntBL.SelectAll(Token);
			} catch (Exception Ex) {
				throw;
			}
		}

		public EmpruntBO SelectEmpruntById(String Token, Int32 pId) {
			try {
				return EmpruntBL.SelectById(Token, pId);
			} catch (Exception Ex) {
				throw;
			}
		}
	}
}
