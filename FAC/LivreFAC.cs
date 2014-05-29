﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsIFAC;
using WebsBO;
using WebsBL;

namespace WebsFAC {
	public class LivreFAC : LivreIFAC {

		public List<LivreBO> SelectAll(String Token) {
			if (!Autorization.Validate(Token)) {
				return null;
			}
			try {
				return LivreBL.SelectAll();
			} catch (Exception ex) {
				throw;
			}
		}

		public List<LivreBO> SelectByBibliotheque(String Token, BibliothequeBO pBibliotheque) {
			if (!Autorization.Validate(Token)) {
				return null;
			}
			try {
				return LivreBL.SelectByBibliotheque(pBibliotheque);
			} catch (Exception ex) {
				throw;
			}
		}

		public LivreBO InsertLivre(String Token, LivreBO pObjLivre) {
			if (!Autorization.Validate(Token)) {
				return null;
			}
			try {
				return LivreBL.InsertLivre(pObjLivre);
			} catch (Exception ex) {
				throw;
			}
		}
	}
}
