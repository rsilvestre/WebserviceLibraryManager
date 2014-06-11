using System;
using System.Collections.Generic;
using WebsBO;
using WebsBL;
using WebsIFAC;

namespace WebsFAC
{
    public class ItemFAC : ItemIFAC {
		public List<ItemBO> SelectAll(String token) {
			if (!Autorization.Validate(token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return ItemBL.SelectAll();
			} catch (Exception Ex) { 
				throw; 
			}
		}

		public ItemBO SelectByItemId(String token, Int32 pItemId) {
			if (!Autorization.Validate(token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return ItemBL.SelectByItemId(pItemId);
			} catch (Exception Ex) {
				throw;
			}
		}

		public ItemBO SelectByEmpruntId(String token, Int32 pEmpruntId) {
			if (!Autorization.Validate(token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return ItemBL.SelectByEmpruntId(pEmpruntId);
			} catch (Exception Ex) {
				throw;
			}
		}

		public List<ItemBO> SelectByAdministrateurId(String token, Int32 pAdministrateurId) {
			if (!Autorization.Validate(token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return ItemBL.SelectByAdministrateurId(pAdministrateurId);
			} catch (Exception Ex) {
				throw;
			}
		}
	}
}
