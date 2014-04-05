using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
	public partial class FrmSplashScreen : Form {

		private static Boolean _connect = false;

		private FrmMdi _oFrmMdi;

		public Boolean Connect {
			get { return FrmSplashScreen._connect; }
			set { FrmSplashScreen._connect = value; }
		}

		public String LoadginText {
			set {
				Control.CheckForIllegalCrossThreadCalls = false;
				label1.Text = value;
			}
		}

		public FrmSplashScreen() {
			InitializeComponent();
		}

		public FrmSplashScreen(FrmMdi pfrmMdi) : this() {
			this._oFrmMdi = pfrmMdi;
		}

		private void FrmSplashScreen_Load(object sender, EventArgs e) {
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
			_oFrmMdi.DecrementILockMDI();
		}

		private void btnExit_Click(object sender, EventArgs e) {
			_connect = false;
			_oFrmMdi.DecrementILockMDI();
		}


		internal Boolean EnableConnect(Boolean Value) {
			try {
				btnConnect.Enabled = Value;
			} catch (Exception ex) {
				throw;
			}
			return Value;
		}
	}

	
}
