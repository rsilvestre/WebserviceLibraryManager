﻿using WebsBL;
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
			if (!Autorization.Validate(Token)) {
				return null;
			}
			try {
				return PersonneBL.SelectAll();
			} catch (Exception Ex) {
				throw;
			}
		}

		public PersonneBO SelectById(String Token, Int32 pId) {
			if (!Autorization.Validate(Token)) {
				return null;
			}
			try {
				return PersonneBL.SelectById(pId);
			} catch (Exception Ex) {
				throw;
			}
		}

		public List<PersonneBO> SelectByName(String Token, String pName) {
			if (!Autorization.Validate(Token)) {
				return null;
			}
			try {
				return PersonneBL.SelectByName(pName);
			} catch (Exception Ex) {
				throw;
			}
		}
	}
}
