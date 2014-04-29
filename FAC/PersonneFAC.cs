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
		public List<PersonneBO> SelectAll(String Token) {
			try {
				return PersonneBL.SelectAll(Token);
			} catch (Exception Ex) {
				throw;
			}
		}

		public PersonneBO SelectById(String Token, Int32 pId) {
			try {
				return PersonneBL.SelectById(Token, pId);
			} catch (Exception Ex) {
				throw;
			}
		}

		public List<PersonneBO> SelectByName(String Token, String pName) {
			try {
				return PersonneBL.SelectByName(Token, pName);
			} catch (Exception Ex) {
				throw;
			}
		}
	}
}
