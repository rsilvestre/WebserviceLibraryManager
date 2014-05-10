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

		private void InitConnection() {
			String usernameStr = txtUsername.Text, passwordStr = txtPassword.Text;
			if (usernameStr == "" || passwordStr == "") {
				MessageBox.Show("Les champs Nom d'utilisateur et Mot de passe doivent etre remplis!");
				return;
			}
			try {
				SessionManagerIFACClient objSessionIFac = new SessionManagerIFACClient();
				//SessionBO objSessionBo = objSessionIFac.OpenSession(pUsername, pPassword);
				ASyncGuiSessionOpenSession selectGuiSampleSessionDelegate = objSessionIFac.OpenSession;
				selectGuiSampleSessionDelegate.BeginInvoke(usernameStr, passwordStr, ConnectionResult, null);
			} catch (Exception ex) {
				throw;
			}
		}

		private void ConnectionResult(IAsyncResult result) {
			var sampleSessionDelegate = (ASyncGuiSessionOpenSession)((AsyncResult)result).AsyncDelegate;
			SessionManagerBO objSessionBo = sampleSessionDelegate.EndInvoke(result);
			if (objSessionBo == null || objSessionBo.Token == null) {
				MessageBox.Show("Mauvais nom d'utilisateur ou de mot de passe");
				return;
			}
			CGlobalCache.SessionManager = objSessionBo;
			Connect = true;
			_frmSplashScreen.DecrementILockSplash();
		}

		private void btnConnection_Click(object sender, EventArgs e) {
			InitConnection();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Connect = false;
			_frmSplashScreen.DecrementILockSplash();
		}

		private void txtGeneric_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				InitConnection();
			}
		}

	}
}
