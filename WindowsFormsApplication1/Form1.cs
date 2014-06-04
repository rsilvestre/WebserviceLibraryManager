using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void LoadDatasClient() {
			/*
			using (ClientIFACClient clientProxy = new ClientIFACClient()) {
				dataGridView1.DataSource = clientProxy.SelectAll().ToList();
			}
			*/
			dataGridView1.DataSource = CGlobalCache.LstClient.ToList();
		}

		private void LoadDatasLocation() {
			dataGridView2.DataSource = CGlobalCache.LstEmprunt.ToList();
			/*
			using (LocationIFACClient locationProxy = new LocationIFACClient()) {
				dataGridView2.DataSource = locationProxy.SelectAll().ToList();
			}
			*/
		}

		private void button1_Click(object sender, EventArgs e) {
			LoadDatasClient();
		}

		private void button2_Click(object sender, EventArgs e) {
			LoadDatasLocation();
		}
	}
}
