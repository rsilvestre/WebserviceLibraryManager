using System;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;
using WCF.Proxies;
using WebsBO;

namespace WindowsFormsApplication1.Login {
	public partial class LoginForm : Form {
		private readonly FrmSplashScreen _frmSplashScreen;

		private delegate SessionManagerBO ASyncGuiSessionOpenSession(String pUsername, String pPassword);

		public LoginForm() {
			InitializeComponent();
		}

		public LoginForm(FrmSplashScreen frmSplashScreen) : this() {
			_frmSplashScreen = frmSplashScreen;
		}

		internal void EnableConnect(bool p) {
			throw new NotImplementedException();
		}

		public bool Connect { get; set; }

		private void InitConnection() {
			String usernameStr = txtUsername.Text, passwordStr = txtPassword.Text;
			if (usernameStr == "" || passwordStr == "") {
				MessageBox.Show(Resources.LoginForm_InitConnection_Les_champs_Nom_d_utilisateur_et_Mot_de_passe_doivent_etre_remplis_);
				return;
			}
			try {
				var objSessionIFac = new SessionManagerIFACClient();
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
				MessageBox.Show(Resources.LoginForm_ConnectionResult_Mauvais_nom_d_utilisateur_ou_de_mot_de_passe);
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
