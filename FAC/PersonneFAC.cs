using WebsBL;
using WebsIFAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;

namespace WebsFAC {
	public class PersonneFAC : PersonneIFAC {
		public List<PersonneBO> SelectAll() {
			try {
				return PersonneBL.SelectAll();
			} catch (Exception Ex) {
				throw;
			}
		}

		public List<PersonneBO> SelectById(Int32 pId) {
			try {
				return PersonneBL.SelectById(pId);
			} catch (Exception Ex) {
				throw;
			}
		}

		public List<PersonneBO> SelectByName(String pName) {
			try {
				return PersonneBL.SelectByName(pName);
			} catch (Exception Ex) {
				throw;
			}
		}
	}
}
