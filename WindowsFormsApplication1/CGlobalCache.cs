using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows.Forms;
using WCF.Proxies;
using WebsBO;

namespace WindowsFormsApplication1 {
	public static class CGlobalCache {
		public delegate void ActualBibliothequeChangeHandler(Object value, EventArgs e);
		public static event ActualBibliothequeChangeHandler actualBibliothequeChangeEventHandler;

		public delegate void ActualLstDemandeReservationHandler(DemandeReservationBO value, EventArgs e);
		public static event ActualLstDemandeReservationHandler actualLstDemandeReservationEventHandlser;

		public static Int32 _iLock = 10;
		static readonly AutoResetEvent AutoEvent = new AutoResetEvent(false);

		private delegate List<PersonneBO> AsyncGuiPersonne(String Token);
		private delegate List<EmpruntBO> AsyncGuiEmprunt(String Token);
		private delegate List<ClientBO> AsyncGuiClient(String Token);
		//private delegate PersonneBO AsyncGuiPersonneById(String Token, int pId);
		private delegate List<RefLivreBO> AsyncGuiRefLivreSelectAll(String Token);
		private delegate List<LivreBO> AsyncGuiLivreSelectAll(String Token);
		private delegate List<LivreBO> AsyncGuiLivreSelectByBibliotheque(String Token, BibliothequeBO pBibliotheque);
		private delegate List<LivreStatusBO> ASyncGuiLivreStatusSelectAll(String Token);
		private delegate List<BibliothequeBO> ASyncGuiBibliothequeSelectAll(String Token);
		private delegate List<DemandeReservationBO> ASyncGuiDemandeReservationSelectByClient(String Token, ClientBO pClient);

		private static BibliothequeBO _ActualBibliotheque;
		
		//private delegate List<PersonneBO> AsyncGuiPersonneByName(String pName);

		public static List<PersonneBO> LstPersonne { get; set; }
		public static List<EmpruntBO> LstEmprunt { get; set; }
		public static List<ClientBO> LstClient { get; set; }
		public static PersonneBO objPersonne { get; set; }
		public static List<RefLivreBO> LstRefLivreSelectAll { get; set; }
		public static List<LivreBO> LstLivreSelectAll { get; set; }
		public static List<LivreBO> LstLivreByBibliotheque { get; set; }
		public static List<LivreStatusBO> LstLivreStatusSelectAll { get; set; }
		public static List<BibliothequeBO> LstBibliothequeSelectAll { get; set; }
		public static SessionManagerBO SessionManager { get; set; }
		public static List<DemandeReservationBO> LstNewDemandeReservationByClient { get; set; }
		public static List<DemandeReservationBO> LstOldDemandeReservationByClient { get; set; }
		public static BibliothequeBO ActualBibliotheque { 
			get { return _ActualBibliotheque; } 
			set { 
				_ActualBibliotheque = value;
				actualBibliothequeChangeEventHandler(value, new EventArgs());
			}
		}
		//public static List<PersonneBO> LstPersonneByName { get; set; }

		private static FrmMdi ofrmMdi;

		public static Boolean LoadCache(FrmMdi pFrmMdi) {
			
			var bReturn = true;
			PersonneIFACClient personneIFac = null;
			EmpruntIFACClient empruntIFac = null;
			ClientIFACClient clientIFac = null;
			PersonneIFACClient personneIFacById = null;
			RefLivreIFACClient refLivreIFacSelectAll = null;
			LivreIFACClient livreIFacSelectAll = null;
			LivreIFACClient livreIFacSelectByBliotheque = null;
			LivreStatusIFACClient livreStatusIFacSelectAll = null;
			BibliothequeIFACClient bibliothequeIFacSelectAll = null;
			DemandeReservationIFACClient demandeReservationIFacByClient = null;

			try {
				ofrmMdi = pFrmMdi;
				personneIFac = new PersonneIFACClient();
				//AsyncGuiPersonne selectGuiSamplePersonneDelegate = personneIFac.SelectAll;
				var selectGuiSamplePersonneDelegate = new AsyncGuiPersonne(personneIFac.SelectAll);
				selectGuiSamplePersonneDelegate.BeginInvoke(SessionManager.Token, PersonneResults, null);

				//personneIFacById = new PersonneIFACClient();
				//var selectGuiSamplePersonneByIdDelegate = new AsyncGuiPersonneById(personneIFacById.SelectById);
				//selectGuiSamplePersonneByIdDelegate.BeginInvoke(SessionManager.Token, 1, PersonneByIdResult, null);

				//var selectGuiSamplePersonneByNameDelegate = new AsyncGuiPersonneByName(personneIFac.SelectByName);
				//selectGuiSamplePersonneByNameDelegate.BeginInvoke("toto", PersonneByNameResult, null);

				empruntIFac = new EmpruntIFACClient();
				var selectGuiSampleEmpruntDelegate = new AsyncGuiEmprunt(empruntIFac.SelectAll);
				selectGuiSampleEmpruntDelegate.BeginInvoke(SessionManager.Token, EmpruntResults, null);

				clientIFac = new ClientIFACClient();
				var selectGuiSampleClientDelegate = new AsyncGuiClient(clientIFac.SelectAll);
				selectGuiSampleClientDelegate.BeginInvoke(SessionManager.Token, ClientResults, null);

				refLivreIFacSelectAll = new RefLivreIFACClient();
				var selectGuiSampleRefLivreDelegate = new AsyncGuiRefLivreSelectAll(refLivreIFacSelectAll.SelectAll);
				selectGuiSampleRefLivreDelegate.BeginInvoke(SessionManager.Token, RefLivreSelectAllResult, null);

				livreIFacSelectAll = new LivreIFACClient();
				var selectGuiSampleLivreDelegate = new AsyncGuiLivreSelectAll(livreIFacSelectAll.SelectAll);
				selectGuiSampleLivreDelegate.BeginInvoke(SessionManager.Token, LivreSelectAllResult, null);

				if (SessionManager.Personne.Client != null) {
					livreIFacSelectByBliotheque = new LivreIFACClient();
					AsyncGuiLivreSelectByBibliotheque selectGuiSampleLivreByBibliothequeDelegate = livreIFacSelectByBliotheque.SelectByBibliotheque;
					selectGuiSampleLivreByBibliothequeDelegate.BeginInvoke(SessionManager.Token, SessionManager.Personne.Client.Bibliotheque, LivreSelectByBibliothequeResult, null);

					demandeReservationIFacByClient = new DemandeReservationIFACClient();
					ASyncGuiDemandeReservationSelectByClient selectGuiSampleNewDemandeReservationByClientDelegate = demandeReservationIFacByClient.SelectNewByClient;
					selectGuiSampleNewDemandeReservationByClientDelegate.BeginInvoke(SessionManager.Token, SessionManager.Personne.Client, NewDemandeReservationResults, null);

					demandeReservationIFacByClient = new DemandeReservationIFACClient();
					ASyncGuiDemandeReservationSelectByClient selectGuiSampleOldDemandeReservationByClientDelegate = demandeReservationIFacByClient.SelectOldByClient;
					selectGuiSampleOldDemandeReservationByClientDelegate.BeginInvoke(SessionManager.Token, SessionManager.Personne.Client, OldDemandeReservationResults, null);


					
				} else {
					DecrementILock();
					DecrementILock();
				}

				livreStatusIFacSelectAll = new LivreStatusIFACClient();
				var selectGuiSampleLivreStatusDelegate = new ASyncGuiLivreStatusSelectAll(livreStatusIFacSelectAll.SelectAll);
				selectGuiSampleLivreStatusDelegate.BeginInvoke(SessionManager.Token, LivreStatusSelecAllResult, null);

				bibliothequeIFacSelectAll = new BibliothequeIFACClient();
				var selectGuiSampleBibliothequeDelegate = new ASyncGuiBibliothequeSelectAll(bibliothequeIFacSelectAll.SelectAll);
				selectGuiSampleBibliothequeDelegate.BeginInvoke(SessionManager.Token, BibliothequeSelectAllResult, null);

				while (!AutoEvent.WaitOne(50, true)) {
					Application.DoEvents();
				}
			
			} catch (Exception) {
				bReturn = false;
			} finally {
				if (personneIFac != null) {
					personneIFac.Close();
				}
				if (empruntIFac != null) {
					empruntIFac.Close();
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
				if (livreIFacSelectByBliotheque != null) {
					livreIFacSelectByBliotheque.Close();
				}
				if (livreStatusIFacSelectAll != null) {
					livreStatusIFacSelectAll.Close();
				}
				if (bibliothequeIFacSelectAll != null) {
					bibliothequeIFacSelectAll.Close();
				}
				if (demandeReservationIFacByClient != null) {
					demandeReservationIFacByClient.Close();
				}
				ofrmMdi.DecrementILockMdi();
			}
			return bReturn;
		}

		public static void PersonneResults(IAsyncResult result) {
			var samplePersDelegate = (AsyncGuiPersonne)((AsyncResult)result).AsyncDelegate;
			LstPersonne = samplePersDelegate.EndInvoke(result);
			ofrmMdi.SetLoadingText(String.Format(@"{0}", "AllPersonne"));
			//Console.WriteLine(@"Lock: {0}", _iLock);
			DecrementILock();
		}

		public static void EmpruntResults(IAsyncResult result) {
			var sampleEmpDelegate = (AsyncGuiEmprunt)((AsyncResult)result).AsyncDelegate;
			LstEmprunt = sampleEmpDelegate.EndInvoke(result);
			ofrmMdi.SetLoadingText(String.Format(@"{0}", "AllEmprunt"));
			//Console.WriteLine(@"Lock: {0}", _iLock);
			DecrementILock();
		}

		public static void ClientResults(IAsyncResult result) {
			var sampleCliDelegate = (AsyncGuiClient)((AsyncResult)result).AsyncDelegate;
			LstClient = sampleCliDelegate.EndInvoke(result);
			ofrmMdi.SetLoadingText(String.Format(@"{0}", "AllClient"));
			//Console.WriteLine(@"Lock: {0}", _iLock);
			DecrementILock();
		}
		
		public static void NewDemandeReservationResults(IAsyncResult result) {
			var sampleCliDelegate = (ASyncGuiDemandeReservationSelectByClient)((AsyncResult)result).AsyncDelegate;
			LstNewDemandeReservationByClient = sampleCliDelegate.EndInvoke(result);
			ofrmMdi.SetLoadingText(String.Format(@"{0}", "AllNewDemandeReservation"));
			//Console.WriteLine(@"Lock: {0}", _iLock);
			DecrementILock();
		}
		
		public static void OldDemandeReservationResults(IAsyncResult result) {
			var sampleCliDelegate = (ASyncGuiDemandeReservationSelectByClient)((AsyncResult)result).AsyncDelegate;
			LstOldDemandeReservationByClient = sampleCliDelegate.EndInvoke(result);
			ofrmMdi.SetLoadingText(String.Format(@"{0}", "AllOldDemandeReservation"));
			//Console.WriteLine(@"Lock: {0}", _iLock);
			DecrementILock();
		}
		

		/*
		public static void PersonneByIdResult(IAsyncResult result) {
			var samplePersByIdDelegate = (AsyncGuiPersonneById)((AsyncResult)result).AsyncDelegate;
			//if (result.AsyncState != null) {
			objPersonne = samplePersByIdDelegate.EndInvoke(result);
			ofrmMdi.SetLoadingText(String.Format(@"{0}", objPersonne.GetType().Name));
			//Console.WriteLine(@"{0}", objPersonne.GetType());
			//}
			//ofrmMdi.SetLoadingText(String.Format(@"{0}", _iLock));
			DecrementILock();
		}
		*/

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

		public static void LivreSelectByBibliothequeResult(IAsyncResult result) {
			var sampleLivreSelectAllDelegate = (AsyncGuiLivreSelectByBibliotheque)((AsyncResult)result).AsyncDelegate;
			LstLivreByBibliotheque = sampleLivreSelectAllDelegate.EndInvoke(result);
			ofrmMdi.SetLoadingText(String.Format(@"{0}", "LivreByBibliotheque"));
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
				selectGuiSampleRefLivreDelegate.BeginInvoke(SessionManager.Token, RefLivreSelectAllResult, null);

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
				selectGuiSampleRefLivreDelegate.BeginInvoke(SessionManager.Token, LivreSelectAllResult, null);

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

		internal static bool LoadCache(FrmSplashScreen frmSplashScreen) {
			throw new NotImplementedException();
		}

		internal static void AddNewDemandeReservationByClient(DemandeReservationBO demandeReservationResult) {
			LstNewDemandeReservationByClient.Add(demandeReservationResult);
			actualLstDemandeReservationEventHandlser(demandeReservationResult, new EventArgs());
		}
	}
}
