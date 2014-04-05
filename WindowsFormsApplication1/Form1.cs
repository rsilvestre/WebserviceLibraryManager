using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCF.Proxies;

namespace WindowsFormsApplication1 {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
			CGlobalCache.LoadCache(new FrmMdi());
		}

		private void loadDatasClient() {
			/*
			using (ClientIFACClient clientProxy = new ClientIFACClient()) {
				dataGridView1.DataSource = clientProxy.SelectAll().ToList();
			}
			*/
			dataGridView1.DataSource = CGlobalCache.LstClient.ToList();
		}

		private void loadDatasLocation() {
			dataGridView2.DataSource = CGlobalCache.LstEmprunt.ToList();
			/*
			using (LocationIFACClient locationProxy = new LocationIFACClient()) {
				dataGridView2.DataSource = locationProxy.SelectAll().ToList();
			}
			*/
		}

		private void button1_Click(object sender, EventArgs e) {
			loadDatasClient();
		}

		private void button2_Click(object sender, EventArgs e) {
			loadDatasLocation();
		}
	}
}
