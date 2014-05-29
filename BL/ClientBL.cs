﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsBO;
using WebsDAL;

namespace WebsBL
{
    public static class ClientBL {
		public static List<ClientBO> SelectAll() {
			List<ClientBO> lstResult = null;
			try {
				using (ClientDAL clientDal = new ClientDAL(Util.GetConnection())) {
					lstResult = clientDal.ClientBO_SelectAll().ToList();
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstResult;
		}

		public static ClientBO SelectById(Int32 pId) {
			ClientBO objClientResult = null;
			try {
				using (ClientDAL clientDal = new ClientDAL(Util.GetConnection())) {
					List<ClientBO> tmpObjClient = clientDal.ClientBO_SelectById(pId).ToList();
					if (tmpObjClient.Count() == 1) {
						objClientResult = tmpObjClient[0];
						objClientResult.Bibliotheque = BibliothequeBL.SelectById(objClientResult.BibliothequeId);
					}
				}
			} catch (Exception Ex) { 
				throw;  
			}
			return objClientResult;
		}
    }
}
