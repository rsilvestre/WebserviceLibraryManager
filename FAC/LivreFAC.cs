using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsIFAC;
using WebsBO;
using WebsBL;

namespace WebsFAC {
	public class LivreFAC : LivreIFAC {

		public List<LivreBO> SelectAll() {
			try {
				return LivreBL.SelectAll();
			} catch (Exception ex) {
				throw;
			}
		}
	}
}
