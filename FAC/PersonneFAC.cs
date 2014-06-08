using WebsBL;
using WebsIFAC;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebsBO;

namespace WebsFAC {
	public class PersonneFAC : PersonneIFAC {
		public List<PersonneBO> SelectAll(String token) {
			if (!Autorization.Validate(token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return PersonneBL.SelectAll();
			} catch (Exception Ex) {
				throw;
			}
		}

		public PersonneBO SelectById(String token, Int32 pId) {
			if (!Autorization.Validate(token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return PersonneBL.SelectById(pId);
			} catch (Exception Ex) {
				throw;
			}
		}

		public List<PersonneBO> SelectByName(String token, String pName) {
			if (!Autorization.Validate(token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return PersonneBL.SelectByName(pName);
			} catch (Exception Ex) {
				throw;
			}
		}

		public List<PersonneBO> SelectByInfo(String token, String pInfo) {
			if (!Autorization.Validate(token, Autorization.Role.CLIENT)) {
				return null;
			}
			try {
				return PersonneBL.SelectByInfo(pInfo);
			} catch (Exception Ex) {
				throw;
			}
		}

		public PersonneBO SelectByLivreEmpruntId(String token, Int32 pEmpruntId) {
			if (!Autorization.Validate(token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return PersonneBL.SelectByLivreEmpruntId(pEmpruntId);
			} catch (Exception Ex) {
				throw;
			}
		}
	}
}
