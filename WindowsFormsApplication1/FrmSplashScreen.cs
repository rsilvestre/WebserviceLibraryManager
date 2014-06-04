using System;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApplication1.Login;

namespace WindowsFormsApplication1 {
	public partial class FrmSplashScreen : Form {

		private LoginForm _loginScreen;
		private readonly AutoResetEvent _autoEvent = new AutoResetEvent(false);

		private Int32 _iLockSplash;

		private static Boolean _connect;

		private readonly FrmMdi _oFrmMdi;

		public Int32 LockSplash {
			get { return _iLockSplash; }
			set { _iLockSplash = value; }
		}

		public Boolean Connect {
			get { return _connect; }
			set { _connect = value; }
		}

		public String LoadginText {
			set {
				CheckForIllegalCrossThreadCalls = false;
				label1.Text = value;
			}
		}

		public FrmSplashScreen() {
			InitializeComponent();
		}

		public FrmSplashScreen(FrmMdi pfrmMdi) : this() {
			_oFrmMdi = pfrmMdi;
		}

		private void FrmSplashScreen_Load(object sender, EventArgs e) {
			LockSplash = 1;
			try {
				_loginScreen = new LoginForm(this);
				_loginScreen.Show();
				//_loginScreen.EnableConnect(CGlobalCache.LoadCache(this));

				while (!_autoEvent.WaitOne(50, true)) {
					Application.DoEvents();
				}

				if (_loginScreen.Connect) {
					_loginScreen.Close();
				} else {
					_loginScreen.Close();
					Connect = false;
					Close();
				}

			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
				_loginScreen.Close();
				Close();
			}
			progressBar.Minimum = 0;
			progressBar.Maximum = CGlobalCache._iLock;
			progressBar.Step = 1;
		}

		public void Dostep(Int32 step) {
			try {
				for (int i = 0; i < step; i++) {
					progressBar.PerformStep();
				}
			} catch(Exception Ex) {
				throw;
			}
		}

		private void btnConnect_Click(object sender, EventArgs e) {
			_connect = true;
			_oFrmMdi.DecrementILockMdi();
		}

		private void btnExit_Click(object sender, EventArgs e) {
			_connect = false;
			_oFrmMdi.DecrementILockMdi();
		}


		internal Boolean EnableConnect(Boolean value) {
			try {
				btnConnect.Enabled = value;
			} catch (Exception ex) {
				throw;
			}
			return value;
		}

		public void DecrementILockSplash() {

			Interlocked.Decrement(ref _iLockSplash);
			if (_iLockSplash == 0) {
				_autoEvent.Set();
			}
		}

	}

	
}
