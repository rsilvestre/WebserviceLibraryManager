using System;
using System.Collections.Generic;
using System.Linq;
using WebsBO;
using WebsDAL;

namespace WebsBL
{
    public static class ItemBL {
		public static List<ItemBO> SelectAll() {
			List<ItemBO> lstResult;
			try {
				using (var itemDal = new ItemDAL(Util.GetConnection())) {
					lstResult = itemDal.ItemBO_SelectAll().ToList();
					foreach (var itemBo in lstResult) {
						itemBo.Emprunt = EmpruntBL.SelectById(itemBo.EmpruntId);
					}
				}
			} catch (Exception Ex) {
				throw;
			}
			return lstResult;
		}

		public static ItemBO SelectByItemId(Int32 pItemId) {
			ItemBO objItemResult = null;
			try {
				using (var itemDal = new ItemDAL(Util.GetConnection())) {
					var tmpObjItem = itemDal.ItemBO_SelectByItemId(pItemId).ToList();
					if (tmpObjItem.Count() == 1) {
						objItemResult = tmpObjItem[0];
						objItemResult.Emprunt = EmpruntBL.SelectById(objItemResult.EmpruntId);
					}
				}
			} catch (Exception Ex) { 
				throw;  
			}
			return objItemResult;
		}

		public static ItemBO SelectByEmpruntId(Int32 pEmpruntId) {
			ItemBO objItemResult = null;
			try {
				using (var itemDal = new ItemDAL(Util.GetConnection())) {
					var tmpObjItem = itemDal.ItemBO_SelectByEmpruntId(pEmpruntId).ToList();
					if (tmpObjItem.Count() == 1) {
						objItemResult = tmpObjItem[0];
						objItemResult.Emprunt = EmpruntBL.SelectById(objItemResult.EmpruntId);
					}
				}
			} catch (Exception Ex) { 
				throw;  
			}
			return objItemResult;
		}

		public static List<ItemBO> SelectByAdministrateurId(Int32 pAdministrateurId) {
			List<ItemBO> lstItemResult = null;
			try {
				using (var itemDal = new ItemDAL(Util.GetConnection())) {
					lstItemResult = itemDal.ItemBO_SelectByAdministrateurId(pAdministrateurId).ToList();
					foreach (var itemBo in lstItemResult){
						itemBo.Emprunt = EmpruntBL.SelectById(itemBo.EmpruntId);
					}
				}
			} catch (Exception Ex) { 
				throw;  
			}
			return lstItemResult;
		}
    }
}
