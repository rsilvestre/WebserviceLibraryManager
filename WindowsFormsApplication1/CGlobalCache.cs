﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCF.Proxies;
using WebsBO;

namespace WindowsFormsApplication1 {
	public static class CGlobalCache {
		public static Int32 _iLock = 8;
		static readonly AutoResetEvent AutoEvent = new AutoResetEvent(false);

		private delegate List<PersonneBO> AsyncGuiPersonne();
		private delegate List<EmpruntBO> AsyncGuiEmprunt();
		private delegate List<ClientBO> AsyncGuiClient();
		private delegate List<PersonneBO> AsyncGuiPersonneById(int pId);
		private delegate List<RefLivreBO> AsyncGuiRefLivreSelectAll();
		private delegate List<LivreBO> AsyncGuiLivreSelectAll();
		private delegate List<LivreStatusBO> ASyncGuiLivreStatusSelectAll();
		private delegate List<BibliothequeBO> ASyncGuiBibliothequeSelectAll();
		//private delegate List<PersonneBO> AsyncGuiPersonneByName(String pName);

		public static List<PersonneBO> LstPersonne { get; set; }
		public static List<EmpruntBO> LstEmprunt { get; set; }
		public static List<ClientBO> LstClient { get; set; }
		public static List<PersonneBO> objPersonne { get; set; }
		public static List<RefLivreBO> LstRefLivreSelectAll { get; set; }
		public static List<LivreBO> LstLivreSelectAll { get; set; }
		public static List<LivreStatusBO> LstLivreStatusSelectAll { get; set; }
		public static List<BibliothequeBO> LstBibliothequeSelectAll { get; set; }
		//public static List<PersonneBO> LstPersonneByName { get; set; }

		private static FrmMdi ofrmMdi;

		public static Boolean LoadCache(FrmMdi pFrmMdi) {
			
			var bReturn = true;
			PersonneIFACClient personneIFac = null;
			EmpruntIFACClient locationIFac = null;
			ClientIFACClient clientIFac = null;
			PersonneIFACClient personneIFacById = null;
			RefLivreIFACClient refLivreIFacSelectAll = null;
			LivreIFACClient livreIFacSelectAll = null;
			LivreStatusIFACClient livreStatusIFacSelectAll = null;
			BibliothequeIFACClient bibliothequeIFacSelectAll = null;

			try {
				ofrmMdi = pFrmMdi;
				personneIFac = new PersonneIFACClient();
				//AsyncGuiPersonne selectGuiSamplePersonneDelegate = personneIFac.SelectAll;
				var selectGuiSamplePersonneDelegate = new AsyncGuiPersonne(personneIFac.SelectAll);
				selectGuiSamplePersonneDelegate.BeginInvoke(PersonneResults, null);

				personneIFacById = new PersonneIFACClient();
				var selectGuiSamplePersonneByIdDelegate = new AsyncGuiPersonneById(personneIFacById.SelectById);
				selectGuiSamplePersonneByIdDelegate.BeginInvoke(1, PersonneByIdResult, null);

				//var selectGuiSamplePersonneByNameDelegate = new AsyncGuiPersonneByName(personneIFac.SelectByName);
				//selectGuiSamplePersonneByNameDelegate.BeginInvoke("toto", PersonneByNameResult, null);

				locationIFac = new EmpruntIFACClient();
				var selectGuiSampleEmpruntDelegate = new AsyncGuiEmprunt(locationIFac.SelectAll);
				selectGuiSampleEmpruntDelegate.BeginInvoke(EmpruntResults, null);

				clientIFac = new ClientIFACClient();
				var selectGuiSampleClientDelegate = new AsyncGuiClient(clientIFac.SelectAll);
				selectGuiSampleClientDelegate.BeginInvoke(ClientResults, null);

				refLivreIFacSelectAll = new RefLivreIFACClient();
				var selectGuiSampleRefLivreDelegate = new AsyncGuiRefLivreSelectAll(refLivreIFacSelectAll.SelectAll);
				selectGuiSampleRefLivreDelegate.BeginInvoke(RefLivreSelectAllResult, null);

				livreIFacSelectAll = new LivreIFACClient();
				var selectGuiSampleLivreDelegate = new AsyncGuiLivreSelectAll(livreIFacSelectAll.SelectAll);
				selectGuiSampleLivreDelegate.BeginInvoke(LivreSelectAllResult, null);

				livreStatusIFacSelectAll = new LivreStatusIFACClient();
				var selectGuiSampleLivreStatusDelegate = new ASyncGuiLivreStatusSelectAll(livreStatusIFacSelectAll.SelectAll);
				selectGuiSampleLivreStatusDelegate.BeginInvoke(LivreStatusSelecAllResult, null);

				bibliothequeIFacSelectAll = new BibliothequeIFACClient();
				var selectGuiSampleBibliothequeDelegate = new ASyncGuiBibliothequeSelectAll(bibliothequeIFacSelectAll.SelectAll);
				selectGuiSampleBibliothequeDelegate.BeginInvoke(BibliothequeSelectAllResult, null);

				while (!AutoEvent.WaitOne(50, true)) {
					Application.DoEvents();
				}
			
			} catch (Exception) {
				bReturn = false;
			} finally {
				if (personneIFac != null) {
					personneIFac.Close();
				}
				if (locationIFac != null) {
					locationIFac.Close();
				}
				if (clientIFac != null) {
					clientIFac.Close();
				}
				if (personneIFacById != null) {
					personneIFacById.Close();
				}
				if (refLivreIFacSelectAll != null) {
					refLivreIFacSelectAll.Close();
				}
				if (livreIFacSelectAll != null) {
					livreIFacSelectAll.Close();
				}
				if (livreStatusIFacSelectAll != null) {
					livreStatusIFacSelectAll.Close();
				}
				if (bibliothequeIFacSelectAll != null) {
					bibliothequeIFacSelectAll.Close();
				}
				ofrmMdi.DecrementILockMDI();
			}
			return bReturn;
		}

		public static void PersonneResults(IAsyncResult result) {
			var samplePersDelegate = (AsyncGuiPersonne)((AsyncResult)result).AsyncDelegate;
			LstPersonne = samplePersDelegate.EndInvoke(result);
			ofrmMdi.SetLoadingText(String.Format(@"{0}", LstPersonne[0].GetType().Name));
			//Console.WriteLine(@"Lock: {0}", _iLock);
			DecrementILock();
		}

		public static void EmpruntResults(IAsyncResult result) {
			var sampleEmpDelegate = (AsyncGuiEmprunt)((AsyncResult)result).AsyncDelegate;
			LstEmprunt = sampleEmpDelegate.EndInvoke(result);
			ofrmMdi.SetLoadingText(String.Format(@"{0}", LstEmprunt[0].GetType().Name));
			//Console.WriteLine(@"Lock: {0}", _iLock);
			DecrementILock();
		}

		public static void ClientResults(IAsyncResult result) {
			var sampleCliDelegate = (AsyncGuiClient)((AsyncResult)result).AsyncDelegate;
			LstClient = sampleCliDelegate.EndInvoke(result);
			ofrmMdi.SetLoadingText(String.Format(@"{0}", LstClient[0].GetType().Name));
			//Console.WriteLine(@"Lock: {0}", _iLock);
			DecrementILock();
		}

		public static void PersonneByIdResult(IAsyncResult result) {
			var samplePersByIdDelegate = (AsyncGuiPersonneById)((AsyncResult)result).AsyncDelegate;
			//if (result.AsyncState != null) {
			objPersonne = samplePersByIdDelegate.EndInvoke(result);
			ofrmMdi.SetLoadingText(String.Format(@"{0}", objPersonne[0].GetType().Name));
			//Console.WriteLine(@"{0}", objPersonne.GetType());
			//}
			//ofrmMdi.SetLoadingText(String.Format(@"{0}", _iLock));
			DecrementILock();
		}

		public static void RefLivreSelectAllResult(IAsyncResult result) {
			var sampleRefLivreSelectAllDelegate = (AsyncGuiRefLivreSelectAll)((AsyncResult)result).AsyncDelegate;
			LstRefLivreSelectAll = sampleRefLivreSelectAllDelegate.EndInvoke(result);
			ofrmMdi.SetLoadingText(String.Format(@"{0}", "RefLivre"));
			DecrementILock();
		}

		public static void LivreSelectAllResult(IAsyncResult result) {
			var sampleLivreSelectAllDelegate = (AsyncGuiLivreSelectAll)((AsyncResult)result).AsyncDelegate;
			LstLivreSelectAll = sampleLivreSelectAllDelegate.EndInvoke(result);
			ofrmMdi.SetLoadingText(String.Format(@"{0}", "Livre"));
			DecrementILock();
		}

		public static void LivreStatusSelecAllResult(IAsyncResult result) {
			var sampleLivreStatusSelectAllDelegate = (ASyncGuiLivreStatusSelectAll)((AsyncResult)result).AsyncDelegate;
			LstLivreStatusSelectAll = sampleLivreStatusSelectAllDelegate.EndInvoke(result);
			ofrmMdi.SetLoadingText(String.Format(@"{0}", "LivreStatus"));
			DecrementILock();
		}

		public static void BibliothequeSelectAllResult(IAsyncResult result) {
			var sampleBibliothequeSelectAllDelegate = (ASyncGuiBibliothequeSelectAll)((AsyncResult)result).AsyncDelegate;
			LstBibliothequeSelectAll = sampleBibliothequeSelectAllDelegate.EndInvoke(result);
			ofrmMdi.SetLoadingText(String.Format(@"{0}", "Bibliotheque"));
			DecrementILock();
		}

		/*
		public static void PersonneByNameResult(IAsyncResult result) {
			var samplePersByNameDelegate = (AsyncGuiPersonneByName)((AsyncResult)result).AsyncDelegate;
			LstPersonneByName = samplePersByNameDelegate.EndInvoke(result);
			Console.WriteLine(@"Select List<T> de type: {0}", objPersonne.GetType());
			Console.WriteLine(@"Lock: {0}", _iLock);
			DecrementILock();
		}
		*/

		private static void DecrementILock() {

			Interlocked.Decrement(ref _iLock);
			if (_iLock == 0) {
				AutoEvent.Set();
			}
		}

		public static Boolean ReloadRefLivreCache() {
			_iLock = 1;
			Boolean bReturn = true;
			RefLivreIFACClient refLivreIFacSelectAll = null;

			try {
				refLivreIFacSelectAll = new RefLivreIFACClient();
				var selectGuiSampleRefLivreDelegate = new AsyncGuiRefLivreSelectAll(refLivreIFacSelectAll.SelectAll);
				selectGuiSampleRefLivreDelegate.BeginInvoke(RefLivreSelectAllResult, null);

				while (!AutoEvent.WaitOne(50, true)) {
					Application.DoEvents();
				}
			} catch (Exception) {
				bReturn = false;
			} finally {
				if (refLivreIFacSelectAll != null) {
					refLivreIFacSelectAll.Close();
				}
			}
			return bReturn;
		}

		public static Boolean ReloadLivreCache() {
			_iLock = 1;
			Boolean bReturn = true;
			LivreIFACClient LivreIFacSelectAll = null;

			try {
				LivreIFacSelectAll = new LivreIFACClient();
				var selectGuiSampleRefLivreDelegate = new AsyncGuiLivreSelectAll(LivreIFacSelectAll.SelectAll);
				selectGuiSampleRefLivreDelegate.BeginInvoke(RefLivreSelectAllResult, null);

				while (!AutoEvent.WaitOne(50, true)) {
					Application.DoEvents();
				}
			} catch (Exception) {
				bReturn = false;
			} finally {
				if (LivreIFacSelectAll != null) {
					LivreIFacSelectAll.Close();
				}
			}
			return bReturn;
		}
	}
}
