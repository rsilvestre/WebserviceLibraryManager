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
		public List<EmpruntBO> SelectAll() {
			try {
				return EmpruntBL.SelectAll().ToList();
			} catch (Exception Ex) {
				throw;
			}
		}

		public EmpruntBO SelectEmpruntById(Int32 pId) {
			try {
				return EmpruntBL.SelectById(pId);
			} catch (Exception Ex) {
				throw;
			}
		}
	}
}
