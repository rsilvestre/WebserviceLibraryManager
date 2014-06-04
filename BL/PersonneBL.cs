using System;
using System.Collections.Generic;
using System.Linq;
using WebsBO;
using WebsDAL;

namespace WebsBL {
	public static class PersonneBL {

		public static List<PersonneBO> SelectAll() {
			List<PersonneBO> lstPersonne;
			try { 
				using(var pesonneDal = new PersonneDAL(Util.GetConnection())) {
					lstPersonne = pesonneDal.PersonneBO_SelectAll().ToList();
				}
			} catch (Exception Ex){
				throw;
			}
			return lstPersonne;
		}

		public static PersonneBO SelectById(Int32 pId) {
			PersonneBO objPersonne = null;
			try {
				using (var personneDal = new PersonneDAL(Util.GetConnection())) {
					var lstPersonne = personneDal.PersonneBO_SelectById(pId).ToList();
					if (lstPersonne.Count() == 1) {
						objPersonne = lstPersonne[0];
						objPersonne.Client = ClientBL.SelectById(objPersonne.PersonneId);
						objPersonne.Administrateur = AdministrateurBL.SelectById(objPersonne.PersonneId);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return objPersonne;
		}

		public static List<PersonneBO> SelectByName(String pName) {
			List<PersonneBO> lstPersonne;
			try {
				using (var personneDal = new PersonneDAL(Util.GetConnection())) {
					lstPersonne = personneDal.PersonneBO_SelectByName(pName).ToList();
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstPersonne;
		}

		public static List<PersonneBO> SelectByInfo(String pInfo) {
			List<PersonneBO> lstPersonne;
			try {
				using (var personneDal = new PersonneDAL(Util.GetConnection())) {
					lstPersonne = personneDal.PersonneBO_SelectByInfo(pInfo).ToList();
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstPersonne;
		}
	}
}
