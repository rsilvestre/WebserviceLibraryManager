using WebsBL;
using WebsIFAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsFAC {
	public class PersonneFAC : PersonneIFAC {
		public List<WebsBO.PersonneBO> SelectAll() {
			try {
				return PersonneBL.SelectAll();
			} catch (Exception Ex) {
				throw;
			}
		}

		public WebsBO.PersonneBO SelectById(int pId) {
			try {
				return PersonneBL.SelectById(pId);
			} catch (Exception Ex) {
				throw;
			}
		}

		public List<WebsBO.PersonneBO> SelectByName(string pName) {
			try {
				return PersonneBL.SelectByName(pName);
			} catch (Exception Ex) {
				throw;
			}
		}
	}
}
