﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsIFAC;
using WebsBL;
using WebsBO;

namespace WebsFAC {
	public class SessionManagerFAC : SessionManagerIFAC {
		public SessionManagerBO OpenSession(string pUsername, string pPassword) {
			try {
				return SessionManagerBL.OpenSession(pUsername, pPassword);
			} catch (Exception ex) {
				throw;
			}
		}
	}
}
