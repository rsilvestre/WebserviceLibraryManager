using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using WebsDAL;

namespace WebsBL {
	public static class PersonneBL {

		public static List<PersonneBO> SelectAll(String Token) {
			if (!Autorization.Validate(Token)) {
				return null;
			}
			List<PersonneBO> lstPersonne = null;
			try { 
				using(PersonneDAL pesonneDal = new PersonneDAL(Util.GetConnection())) {
					lstPersonne = pesonneDal.PersonneBO_SelectAll().ToList();
				}
			} catch (Exception Ex){
				throw;
			}
			return lstPersonne;
		}

		public static PersonneBO SelectById(String Token, Int32 pId) {
			if (!Autorization.Validate(Token)) {
				return null;
			}
			PersonneBO objPersonne = null;
			try {
				using (PersonneDAL personneDal = new PersonneDAL(Util.GetConnection())) {
					List<PersonneBO> lstPersonne = personneDal.PersonneBO_SelectById(pId).ToList();
					if (lstPersonne.Count() == 1) {
						objPersonne = lstPersonne[0];
						objPersonne.Client = ClientBL.SelectById(Token, objPersonne.PersonneId);
						objPersonne.Administrateur = AdministrateurBL.SelectById(Token, objPersonne.PersonneId);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return objPersonne;
		}

		public static List<PersonneBO> SelectByName(String Token, String pName) {
			if (!Autorization.Validate(Token)) {
				return null;
			}
			List<PersonneBO> lstPersonne;
			try {
				using (PersonneDAL personneDal = new PersonneDAL(Util.GetConnection())) {
					lstPersonne = personneDal.PersonneBO_SelectByName(pName).ToList();
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstPersonne;
		}
	}
}
