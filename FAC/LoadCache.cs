using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebsBO;
using WebsBL;

namespace WebservicePerso {
	public class LoadCache {
		private Int32 _iLock;
		private AutoResetEvent autoEvent = new AutoResetEvent(false);

		private delegate List<PersonneBO> ASyncPersonne();
		private delegate void ShowHim();

		public LoadCache() {
			LoadCache load = new LoadCache();
			ASyncPersonne asyncPerson = new ASyncPersonne(PersonneBL.SelectAll);
			asyncPerson.BeginInvoke(ShowPersonne, null);

			while (autoEvent.WaitOne(50, true)) {
				
			}
		}

		public void ShowPersonne(IAsyncResult toto) {
			//var finish = ((ASyncPersonne));
			// finish.EndInvoke(toto);
		}

		private void Decrement() {
			Interlocked.Decrement(ref _iLock);
			if (_iLock == 0) {
				autoEvent.Set();
			}
		}
	}
}
