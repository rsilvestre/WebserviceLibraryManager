﻿using System;
using WebsBO;
using WebsIFAC;
using WebsBL;

namespace WebsFAC {
	public class AdministrateurFAC : AdministrateurIFAC {
		public AdministrateurBO SelectById(String Token, int pAdministrateurId) {
			if (!Autorization.Validate(Token, Autorization.Role.ADMIN)) {
				return null;
			}
			try {
				return AdministrateurBL.SelectById(pAdministrateurId);
			} catch (Exception ex) {
				throw;
			}
		}
	}
}
