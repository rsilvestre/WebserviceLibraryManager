using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCF.Proxies;
using WebsBO;

namespace WindowsFormsApplication1.Login {
	public partial class LoginForm : Form {
		private FrmSplashScreen _frmSplashScreen;
		private Boolean _Connect;

		private delegate SessionManagerBO ASyncGuiSessionOpenSession(String pUsername, String pPassword);

		public LoginForm() {
			InitializeComponent();
		}

		public LoginForm(FrmSplashScreen frmSplashScreen) : this() {
			this._frmSplashScreen = frmSplashScreen;
		}

		internal void EnableConnect(bool p) {
			throw new NotImplementedException();
		}

		public Boolean Connect {
			get { return _Connect; }
			set { _Connect = value; }
		}

		private void InitConnection(string pUsername, string pPassword) {
			SessionManagerIFACClient objSessionIFac = new SessionManagerIFACClient();
			//SessionBO objSessionBo = objSessionIFac.OpenSession(pUsername, pPassword);
			var selectGuiSampleSessionDelegate = new ASyncGuiSessionOpenSession(objSessionIFac.OpenSession);
			selectGuiSampleSessionDelegate.BeginInvoke(pUsername, pPassword, ConnectionResult, null);
		}

		private void ConnectionResult(IAsyncResult result) {
			var sampleSessionDelegate = (ASyncGuiSessionOpenSession)((AsyncResult)result).AsyncDelegate;
			SessionManagerBO objSessionBo = sampleSessionDelegate.EndInvoke(result);
			if (objSessionBo.Token == null) {
				MessageBox.Show("Mauvais nom d'utilisateur ou de mot de passe");
			}
			CGlobalCache.SessionManager = objSessionBo;
			Connect = true;
			_frmSplashScreen.DecrementILockSplash();
		}

		private void btnConnection_Click(object sender, EventArgs e) {
			if (txtUsername.Text == "" || txtPassword.Text == "") {
				MessageBox.Show("Les champs de login doivent etre rempli");
				return;
			}
			try {
				InitConnection(txtUsername.Text, txtPassword.Text);
			} catch (Exception ex) {
				throw;
			}
		}

	}
}
