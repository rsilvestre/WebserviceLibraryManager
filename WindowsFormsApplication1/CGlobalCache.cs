using System;
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
		public static Int32 _iLock = 4;
		static readonly AutoResetEvent AutoEvent = new AutoResetEvent(false);

		private delegate List<PersonneBO> AsyncGuiPersonne();
		private delegate List<EmpruntBO> AsyncGuiEmprunt();
		private delegate List<ClientBO> AsyncGuiClient();
		private delegate List<PersonneBO> AsyncGuiPersonneById(int pId);
		//private delegate List<PersonneBO> AsyncGuiPersonneByName(String pName);

		public static List<PersonneBO> LstPersonne { get; set; }
		public static List<EmpruntBO> LstEmprunt { get; set; }
		public static List<ClientBO> LstClient { get; set; }
		public static List<PersonneBO> objPersonne { get; set; }
		//public static List<PersonneBO> LstPersonneByName { get; set; }

		private static FrmMdi ofrmMdi;

		public static Boolean LoadCache(FrmMdi pFrmMdi) {
			
			var bReturn = true;
			PersonneIFACClient personneIFac = null;
			EmpruntIFACClient locationIFac = null;
			ClientIFACClient clientIFac = null;
			PersonneIFACClient personneIFacById = null;

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
				ofrmMdi.DecrementILockMDI();
			}
			return bReturn;
		}

		public static void PersonneResults(IAsyncResult result) {
			var samplePersDelegate = (AsyncGuiPersonne)((AsyncResult)result).AsyncDelegate;
			LstPersonne = samplePersDelegate.EndInvoke(result);
			ofrmMdi.SetLoadingText(String.Format(@"Select List<T> de type: {0}", LstPersonne.GetType()));
			//Console.WriteLine(@"Lock: {0}", _iLock);
			DecrementILock();
		}

		public static void EmpruntResults(IAsyncResult result) {
			var sampleEmpDelegate = (AsyncGuiEmprunt)((AsyncResult)result).AsyncDelegate;
			LstEmprunt = sampleEmpDelegate.EndInvoke(result);
			ofrmMdi.SetLoadingText(String.Format(@"Select List<T> de type: {0}", LstEmprunt.GetType()));
			//Console.WriteLine(@"Lock: {0}", _iLock);
			DecrementILock();
		}

		public static void ClientResults(IAsyncResult result) {
			var sampleCliDelegate = (AsyncGuiClient)((AsyncResult)result).AsyncDelegate;
			LstClient = sampleCliDelegate.EndInvoke(result);
			ofrmMdi.SetLoadingText(String.Format(@"Select List<T> de type: {0}", LstClient.GetType()));
			//Console.WriteLine(@"Lock: {0}", _iLock);
			DecrementILock();
		}

		public static void PersonneByIdResult(IAsyncResult result) {
			var samplePersByIdDelegate = (AsyncGuiPersonneById)((AsyncResult)result).AsyncDelegate;
			if (result.AsyncState != null) {
				objPersonne = samplePersByIdDelegate.EndInvoke(result);
				Console.WriteLine(@"Select List<T> de type: {0}", objPersonne.GetType());
			}
			ofrmMdi.SetLoadingText(String.Format(@"Lock: {0}", _iLock));
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
	}
}
