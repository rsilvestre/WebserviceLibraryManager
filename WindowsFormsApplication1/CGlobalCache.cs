using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows.Forms;
using WCF.Proxies;
using WebsBO;

namespace WindowsFormsApplication1 {
	public static class CGlobalCache {
		public delegate void ActualBibliothequeChangeHandler(Object value, EventArgs e);
		public static event ActualBibliothequeChangeHandler ActualBibliothequeChangeEventHandler;

		public delegate void ActualLstDemandeReservationHandler(DemandeReservationBO value, EventArgs e);
		public static event ActualLstDemandeReservationHandler ActualLstDemandeReservationEventHandlser;

		public delegate void LstLivreChangeHandler(Object value, EventArgs e);
		public static event LstLivreChangeHandler LstLivreChangeEvent;

		private static void OnLstLivreChangeEvent(object value){
			var handler = LstLivreChangeEvent;
			if (handler != null){
				handler(value, EventArgs.Empty);
			}
		}

		public delegate void OnReloadCallback();

		public static Int32 Lock = 13;
		static readonly AutoResetEvent AutoEvent = new AutoResetEvent(false);

		private delegate List<PersonneBO> AsyncGuiPersonne(String token);
		private delegate List<ClientBO> AsyncGuiClient(String token);
		//private delegate PersonneBO AsyncGuiPersonneById(String Token, int pId);
		private delegate List<RefLivreBO> AsyncGuiRefLivreSelectAll(String token);
		private delegate List<LivreBO> AsyncGuiLivreSelectAll(String token);
		private delegate List<LivreBO> AsyncGuiLivreSelectByBibliotheque(String token, BibliothequeBO pBibliotheque);
		private delegate List<LivreStatusBO> ASyncGuiLivreStatusSelectAll(String token);
		private delegate List<BibliothequeBO> ASyncGuiBibliothequeSelectAll(String token);
		private delegate List<DemandeReservationBO> ASyncGuiDemandeReservationSelectByClient(String token, ClientBO pClient);
		private delegate List<DemandeReservationBO> ASyncGuiDemandeReservationSelectAll(String token);
		private delegate List<EmpruntBO> AyncGuiEmpruntSelectAllByClientId(String token, Int32 pClientId);
		private delegate List<EmpruntBO> AsyncGuiEmpruntSelectAll(String token); 
		private delegate List<ReservationBO> AsyncGuiReservationSelectAll(String token); 

		private static BibliothequeBO _actualBibliotheque;
		
		//private delegate List<PersonneBO> AsyncGuiPersonneByName(String pName);

		public static List<PersonneBO> LstPersonne { get; set; }
		public static List<EmpruntBO> LstEmpruntByClient { get; set; }
		public static List<EmpruntBO> LstEmpruntSelectAll { get; set; }
		public static List<ClientBO> LstClient { get; set; }
		public static PersonneBO ObjPersonne { get; set; }
		public static List<RefLivreBO> LstRefLivreSelectAll { get; set; }

		public static ObservableCollection<LivreBO> LstLivreSelectAll {
			get { return _lstLivreSelectAll; }
			set{
				_lstLivreSelectAll = value; 
				OnLstLivreChangeEvent(value);
			}
		}

		public static List<LivreBO> LstLivreByBibliotheque { get; set; }
		public static List<LivreStatusBO> LstLivreStatusSelectAll { get; set; }
		public static List<BibliothequeBO> LstBibliothequeSelectAll { get; set; }
		public static SessionManagerBO SessionManager { get; set; }
		public static ObservableCollection<DemandeReservationBO> LstNewDemandeReservationByClient { get; set; }
		public static ObservableCollection<DemandeReservationBO> LstOldDemandeReservationByClient { get; set; }
		public static ObservableCollection<DemandeReservationBO> LstDemandeReservationSelectAll { get; set; } 
		public static ObservableCollection<ReservationBO> LstReservationSelectAll { get; set; } 

		public static BibliothequeBO ActualBibliotheque { 
			get { return _actualBibliotheque; } 
			set { 
				_actualBibliotheque = value;
				ActualBibliothequeChangeEventHandler(value, new EventArgs());
			}
		}
		//public static List<PersonneBO> LstPersonneByName { get; set; }

		private static FrmMdi _ofrmMdi;
		private static ObservableCollection<LivreBO> _lstLivreSelectAll;

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
			ReservationIFACClient reservationIfacClient = null;

			try {
				_ofrmMdi = pFrmMdi;
				personneIFac = new PersonneIFACClient();
				//AsyncGuiPersonne selectGuiSamplePersonneDelegate = personneIFac.SelectAll;
				var selectGuiSamplePersonneDelegate = new AsyncGuiPersonne(personneIFac.SelectAll);
				selectGuiSamplePersonneDelegate.BeginInvoke(SessionManager.Token, PersonneResults, null);
				
				empruntIFac = new EmpruntIFACClient();
				AsyncGuiEmpruntSelectAll selectGuiSampleEmpruntSelectAll = empruntIFac.SelectAll;
				selectGuiSampleEmpruntSelectAll.BeginInvoke(SessionManager.Token, EmpruntSelectAllResult, null);
				//personneIFacById = new PersonneIFACClient();
				//var selectGuiSamplePersonneByIdDelegate = new AsyncGuiPersonneById(personneIFacById.SelectById);
				//selectGuiSamplePersonneByIdDelegate.BeginInvoke(SessionManager.Token, 1, PersonneByIdResult, null);

				//var selectGuiSamplePersonneByNameDelegate = new AsyncGuiPersonneByName(personneIFac.SelectByName);
				//selectGuiSamplePersonneByNameDelegate.BeginInvoke("toto", PersonneByNameResult, null);

				clientIFac = new ClientIFACClient();
				var selectGuiSampleClientDelegate = new AsyncGuiClient(clientIFac.SelectAll);
				selectGuiSampleClientDelegate.BeginInvoke(SessionManager.Token, ClientResults, null);

				refLivreIFacSelectAll = new RefLivreIFACClient();
				var selectGuiSampleRefLivreDelegate = new AsyncGuiRefLivreSelectAll(refLivreIFacSelectAll.SelectAll);
				selectGuiSampleRefLivreDelegate.BeginInvoke(SessionManager.Token, RefLivreSelectAllResult, null);

				livreIFacSelectAll = new LivreIFACClient();
				var selectGuiSampleLivreDelegate = new AsyncGuiLivreSelectAll(livreIFacSelectAll.SelectAll);
				selectGuiSampleLivreDelegate.BeginInvoke(SessionManager.Token, LivreSelectAllResult, null);

				
				livreIFacSelectByBliotheque = new LivreIFACClient();
				AsyncGuiLivreSelectByBibliotheque selectGuiSampleLivreByBibliothequeDelegate = livreIFacSelectByBliotheque.SelectByBibliotheque;
				selectGuiSampleLivreByBibliothequeDelegate.BeginInvoke(SessionManager.Token, SessionManager.Personne.Client.Bibliotheque, LivreSelectByBibliothequeResult, null);

				demandeReservationIFacByClient = new DemandeReservationIFACClient();
				ASyncGuiDemandeReservationSelectByClient selectGuiSampleNewDemandeReservationByClientDelegate = demandeReservationIFacByClient.SelectNewByClient;
				selectGuiSampleNewDemandeReservationByClientDelegate.BeginInvoke(SessionManager.Token, SessionManager.Personne.Client, NewDemandeReservationResults, null);

				ASyncGuiDemandeReservationSelectByClient selectGuiSampleOldDemandeReservationByClientDelegate = demandeReservationIFacByClient.SelectOldByClient;
				selectGuiSampleOldDemandeReservationByClientDelegate.BeginInvoke(SessionManager.Token, SessionManager.Personne.Client, OldDemandeReservationResults, null);

				AyncGuiEmpruntSelectAllByClientId selectGuiSampleEmpruntDelegate = empruntIFac.SelectEmpruntByClientId;
				selectGuiSampleEmpruntDelegate.BeginInvoke(SessionManager.Token, SessionManager.PersonneId ,EmpruntResults, null);


					
				

				if (SessionManager.Personne.Administrateur != null){
					reservationIfacClient = new ReservationIFACClient();
					AsyncGuiReservationSelectAll selectGuiSampleReservationDelegate = reservationIfacClient.SelectAll;
					selectGuiSampleReservationDelegate.BeginInvoke(SessionManager.Token, ReservationResults, null);

					ASyncGuiDemandeReservationSelectAll selectGuiSampleDemandeReservationByClientDelegate = demandeReservationIFacByClient.SelectAll;
					selectGuiSampleDemandeReservationByClientDelegate.BeginInvoke(SessionManager.Token, DemandeReservationResults, null);
				} else{
					_ofrmMdi.SetLoadingText(String.Format(@"{0}", "ReservationSelectAll"));
					_ofrmMdi.SetLoadingText(String.Format(@"{0}", "DemandeReservationSelectAll"));
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
				if (reservationIfacClient != null){
					reservationIfacClient.Close();
				}
				_ofrmMdi.DecrementILockMdi();
			}
			return bReturn;
		}

		private static void ReservationResults(IAsyncResult result){
			var sampleReservationDelegate = (AsyncGuiReservationSelectAll)((AsyncResult)result).AsyncDelegate;
			LstReservationSelectAll = new ObservableCollection<ReservationBO>(sampleReservationDelegate.EndInvoke(result));
			_ofrmMdi.SetLoadingText(String.Format(@"ReservationSelectAll"));
			DecrementILock();
		}

		public static void PersonneResults(IAsyncResult result) {
			var samplePersDelegate = (AsyncGuiPersonne)((AsyncResult)result).AsyncDelegate;
			LstPersonne = samplePersDelegate.EndInvoke(result);
			_ofrmMdi.SetLoadingText(String.Format(@"{0}", "AllPersonne"));
			//Console.WriteLine(@"Lock: {0}", _iLock);
			DecrementILock();
		}

		public static void EmpruntResults(IAsyncResult result) {
			var sampleEmpDelegate = (AyncGuiEmpruntSelectAllByClientId)((AsyncResult)result).AsyncDelegate;
			LstEmpruntByClient = sampleEmpDelegate.EndInvoke(result);
			_ofrmMdi.SetLoadingText(String.Format(@"{0}", "EmpruntByClient"));
			//Console.WriteLine(@"Lock: {0}", _iLock);
			DecrementILock();
		}

		public static void EmpruntSelectAllResult(IAsyncResult result) {
			var sampleEmpDelegate = (AsyncGuiEmpruntSelectAll)((AsyncResult)result).AsyncDelegate;
			LstEmpruntSelectAll = sampleEmpDelegate.EndInvoke(result);
			_ofrmMdi.SetLoadingText(String.Format(@"{0}", "EmpruntSelectAll"));
			//Console.WriteLine(@"Lock: {0}", _iLock);
			DecrementILock();
		}

		public static void ClientResults(IAsyncResult result) {
			var sampleCliDelegate = (AsyncGuiClient)((AsyncResult)result).AsyncDelegate;
			LstClient = sampleCliDelegate.EndInvoke(result);
			_ofrmMdi.SetLoadingText(String.Format(@"{0}", "AllClient"));
			//Console.WriteLine(@"Lock: {0}", _iLock);
			DecrementILock();
		}
		
		public static void NewDemandeReservationResults(IAsyncResult result) {
			var sampleCliDelegate = (ASyncGuiDemandeReservationSelectByClient)((AsyncResult)result).AsyncDelegate;
			LstNewDemandeReservationByClient = new ObservableCollection<DemandeReservationBO>(sampleCliDelegate.EndInvoke(result));
			_ofrmMdi.SetLoadingText(String.Format(@"{0}", "AllNewDemandeReservation"));
			//Console.WriteLine(@"Lock: {0}", _iLock);
			DecrementILock();
		}
		
		public static void OldDemandeReservationResults(IAsyncResult result) {
			var sampleCliDelegate = (ASyncGuiDemandeReservationSelectByClient)((AsyncResult)result).AsyncDelegate;
			LstOldDemandeReservationByClient = new ObservableCollection<DemandeReservationBO>(sampleCliDelegate.EndInvoke(result));
			_ofrmMdi.SetLoadingText(String.Format(@"{0}", "AllOldDemandeReservation"));
			//Console.WriteLine(@"Lock: {0}", _iLock);
			DecrementILock();
		}
		
		public static void DemandeReservationResults(IAsyncResult result) {
			var sampleCliDelegate = (ASyncGuiDemandeReservationSelectAll)((AsyncResult)result).AsyncDelegate;
			LstDemandeReservationSelectAll = new ObservableCollection<DemandeReservationBO>(sampleCliDelegate.EndInvoke(result));
			_ofrmMdi.SetLoadingText(String.Format(@"{0}", "AllDemandeReservation"));
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
			_ofrmMdi.SetLoadingText(String.Format(@"{0}", "RefLivre"));
			DecrementILock();
		}

		public static void LivreSelectAllResult(IAsyncResult result) {
			var sampleLivreSelectAllDelegate = (AsyncGuiLivreSelectAll)((AsyncResult)result).AsyncDelegate;
			LstLivreSelectAll = new ObservableCollection<LivreBO>(sampleLivreSelectAllDelegate.EndInvoke(result));
			_ofrmMdi.SetLoadingText(String.Format(@"{0}", "Livre"));
			DecrementILock();
		}

		public static void LivreSelectByBibliothequeResult(IAsyncResult result) {
			var sampleLivreSelectAllDelegate = (AsyncGuiLivreSelectByBibliotheque)((AsyncResult)result).AsyncDelegate;
			LstLivreByBibliotheque = sampleLivreSelectAllDelegate.EndInvoke(result);
			_ofrmMdi.SetLoadingText(String.Format(@"{0}", "LivreByBibliotheque"));
			DecrementILock();
		}

		public static void LivreStatusSelecAllResult(IAsyncResult result) {
			var sampleLivreStatusSelectAllDelegate = (ASyncGuiLivreStatusSelectAll)((AsyncResult)result).AsyncDelegate;
			LstLivreStatusSelectAll = sampleLivreStatusSelectAllDelegate.EndInvoke(result);
			_ofrmMdi.SetLoadingText(String.Format(@"{0}", "LivreStatus"));
			DecrementILock();
		}

		public static void BibliothequeSelectAllResult(IAsyncResult result) {
			var sampleBibliothequeSelectAllDelegate = (ASyncGuiBibliothequeSelectAll)((AsyncResult)result).AsyncDelegate;
			LstBibliothequeSelectAll = sampleBibliothequeSelectAllDelegate.EndInvoke(result);
			_ofrmMdi.SetLoadingText(String.Format(@"{0}", "Bibliotheque"));
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

			Interlocked.Decrement(ref Lock);
			if (Lock == 0) {
				AutoEvent.Set();
			}
		}

		public static Boolean ReloadRefLivreCache() {
			Lock = 1;
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

		public static void ReloadLivreCache() {
			Lock = 1;
			LivreIFACClient livreIFacSelectAll = null;

			try {
				livreIFacSelectAll = new LivreIFACClient();
				var selectGuiSampleRefLivreDelegate = new AsyncGuiLivreSelectAll(livreIFacSelectAll.SelectAll);
				selectGuiSampleRefLivreDelegate.BeginInvoke(SessionManager.Token, result =>{
					LivreSelectAllResult(result);
					livreIFacSelectAll.Close();
				}, null);
			} catch (Exception){
				if (livreIFacSelectAll != null){
					livreIFacSelectAll.Close();
				}
			} 
		}

		public static void ReloadSelectAllEmpruntCache(OnReloadCallback cbCallback = null) {
			var empruntIFacSelectAll = new EmpruntIFACClient();
			AsyncGuiEmpruntSelectAll selectGuiSampleEmpruntDelegate = empruntIFacSelectAll.SelectAll;
			selectGuiSampleEmpruntDelegate.BeginInvoke(SessionManager.Token, result => {
				var sampleEmpDelegate = (AsyncGuiEmpruntSelectAll)((AsyncResult)result).AsyncDelegate;
				LstEmpruntSelectAll = sampleEmpDelegate.EndInvoke(result);
				empruntIFacSelectAll.Close();
				if (cbCallback == null){
					return;
				}
				cbCallback();
			}, null);
		}

		public static void ReloadSelectAllDemandeReservationCache() {
			var demandeReservationIFacSelectNew = new DemandeReservationIFACClient();
			ASyncGuiDemandeReservationSelectByClient selectGuiSampleDemandeReservationNewDelegate = demandeReservationIFacSelectNew.SelectNewByClient;
			selectGuiSampleDemandeReservationNewDelegate.BeginInvoke(SessionManager.Token, SessionManager.Personne.Client, result => {
				var sampleEmpDelegate = (ASyncGuiDemandeReservationSelectByClient)((AsyncResult)result).AsyncDelegate;
				LstNewDemandeReservationByClient = new ObservableCollection<DemandeReservationBO>(sampleEmpDelegate.EndInvoke(result));
				demandeReservationIFacSelectNew.Close();
			}, null);

			var demandeReservationIFacSelectOld = new DemandeReservationIFACClient();
			ASyncGuiDemandeReservationSelectByClient selectGuiSampleDemandeReservationOldDelegate = demandeReservationIFacSelectNew.SelectNewByClient;
			selectGuiSampleDemandeReservationOldDelegate.BeginInvoke(SessionManager.Token, SessionManager.Personne.Client, result => {
				var sampleEmpDelegate = (ASyncGuiDemandeReservationSelectByClient)((AsyncResult)result).AsyncDelegate;
				LstNewDemandeReservationByClient = new ObservableCollection<DemandeReservationBO>(sampleEmpDelegate.EndInvoke(result));
				demandeReservationIFacSelectOld.Close();
			}, null);
		}

		internal static bool LoadCache(FrmSplashScreen frmSplashScreen) {
			throw new NotImplementedException();
		}

		internal static void AddNewDemandeReservationByClient(DemandeReservationBO demandeReservationResult) {
			LstNewDemandeReservationByClient.Add(demandeReservationResult);
			ActualLstDemandeReservationEventHandlser(demandeReservationResult, new EventArgs());
		}
	}
}
