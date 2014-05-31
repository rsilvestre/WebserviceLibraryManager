namespace WindowsFormsApplication1.Dashboard {
	partial class DashboardManager {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.lblDtLastVisiteTitle = new System.Windows.Forms.Label();
			this.lblDtLastVisite = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.lblBibliotheque = new System.Windows.Forms.Label();
			this.lblBibliothequeTitle = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lstReservationEnCours = new System.Windows.Forms.ListBox();
			this.lstReservationPasse = new System.Windows.Forms.ListBox();
			this.lstEmpruntPasse = new System.Windows.Forms.ListBox();
			this.lstEmpruntEnCours = new System.Windows.Forms.ListBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.lstNewLivreNetwork = new System.Windows.Forms.ListBox();
			this.lstNewLivreLocal = new System.Windows.Forms.ListBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.totoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 96);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(123, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Demande de réservation";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Bonjour : ";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblName.Location = new System.Drawing.Point(58, 9);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(39, 13);
			this.lblName.TabIndex = 4;
			this.lblName.Text = "Name";
			// 
			// lblDtLastVisiteTitle
			// 
			this.lblDtLastVisiteTitle.AutoSize = true;
			this.lblDtLastVisiteTitle.Location = new System.Drawing.Point(669, 9);
			this.lblDtLastVisiteTitle.Name = "lblDtLastVisiteTitle";
			this.lblDtLastVisiteTitle.Size = new System.Drawing.Size(83, 13);
			this.lblDtLastVisiteTitle.TabIndex = 5;
			this.lblDtLastVisiteTitle.Text = "Dernière visite : ";
			// 
			// lblDtLastVisite
			// 
			this.lblDtLastVisite.AutoSize = true;
			this.lblDtLastVisite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDtLastVisite.Location = new System.Drawing.Point(746, 9);
			this.lblDtLastVisite.Name = "lblDtLastVisite";
			this.lblDtLastVisite.Size = new System.Drawing.Size(106, 13);
			this.lblDtLastVisite.TabIndex = 6;
			this.lblDtLastVisite.Text = "Emprunt en cours";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(306, 96);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(46, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Emprunt";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(599, 96);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "Locales";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(249, 64);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(94, 24);
			this.label7.TabIndex = 11;
			this.label7.Text = "En cours";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(244, 292);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(105, 24);
			this.label8.TabIndex = 12;
			this.label8.Text = "Historique";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(306, 323);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(46, 13);
			this.label9.TabIndex = 15;
			this.label9.Text = "Emprunt";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(22, 323);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(123, 13);
			this.label10.TabIndex = 13;
			this.label10.Text = "Demande de réservation";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(599, 323);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(78, 13);
			this.label11.TabIndex = 17;
			this.label11.Text = "Dans le réseau";
			// 
			// lblBibliotheque
			// 
			this.lblBibliotheque.AutoSize = true;
			this.lblBibliotheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBibliotheque.Location = new System.Drawing.Point(545, 9);
			this.lblBibliotheque.Name = "lblBibliotheque";
			this.lblBibliotheque.Size = new System.Drawing.Size(77, 13);
			this.lblBibliotheque.TabIndex = 20;
			this.lblBibliotheque.Text = "Bibliotheque";
			// 
			// lblBibliothequeTitle
			// 
			this.lblBibliothequeTitle.AutoSize = true;
			this.lblBibliothequeTitle.Location = new System.Drawing.Point(477, 9);
			this.lblBibliothequeTitle.Name = "lblBibliothequeTitle";
			this.lblBibliothequeTitle.Size = new System.Drawing.Size(74, 13);
			this.lblBibliothequeTitle.TabIndex = 19;
			this.lblBibliothequeTitle.Text = "Bibliothèque : ";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.lstReservationEnCours);
			this.panel1.Controls.Add(this.lstReservationPasse);
			this.panel1.Controls.Add(this.lstEmpruntPasse);
			this.panel1.Controls.Add(this.lstEmpruntEnCours);
			this.panel1.Location = new System.Drawing.Point(12, 56);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(565, 477);
			this.panel1.TabIndex = 21;
			// 
			// lstReservationEnCours
			// 
			this.lstReservationEnCours.FormattingEnabled = true;
			this.lstReservationEnCours.Location = new System.Drawing.Point(12, 55);
			this.lstReservationEnCours.Name = "lstReservationEnCours";
			this.lstReservationEnCours.Size = new System.Drawing.Size(254, 160);
			this.lstReservationEnCours.TabIndex = 22;
			this.lstReservationEnCours.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LivreStatus_MouseDown);
			// 
			// lstReservationPasse
			// 
			this.lstReservationPasse.FormattingEnabled = true;
			this.lstReservationPasse.Location = new System.Drawing.Point(12, 282);
			this.lstReservationPasse.Name = "lstReservationPasse";
			this.lstReservationPasse.Size = new System.Drawing.Size(254, 160);
			this.lstReservationPasse.TabIndex = 21;
			this.lstReservationPasse.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LivreStatus_MouseDown);
			// 
			// lstEmpruntPasse
			// 
			this.lstEmpruntPasse.FormattingEnabled = true;
			this.lstEmpruntPasse.Location = new System.Drawing.Point(296, 282);
			this.lstEmpruntPasse.Name = "lstEmpruntPasse";
			this.lstEmpruntPasse.Size = new System.Drawing.Size(254, 160);
			this.lstEmpruntPasse.TabIndex = 20;
			this.lstEmpruntPasse.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LivreStatus_MouseDown);
			// 
			// lstEmpruntEnCours
			// 
			this.lstEmpruntEnCours.FormattingEnabled = true;
			this.lstEmpruntEnCours.Location = new System.Drawing.Point(296, 55);
			this.lstEmpruntEnCours.Name = "lstEmpruntEnCours";
			this.lstEmpruntEnCours.Size = new System.Drawing.Size(254, 160);
			this.lstEmpruntEnCours.TabIndex = 20;
			this.lstEmpruntEnCours.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LivreStatus_MouseDown);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.lstNewLivreNetwork);
			this.panel2.Controls.Add(this.lstNewLivreLocal);
			this.panel2.Location = new System.Drawing.Point(586, 56);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(287, 477);
			this.panel2.TabIndex = 22;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(86, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(121, 24);
			this.label3.TabIndex = 23;
			this.label3.Text = "Nouveautés";
			// 
			// lstNewLivreNetwork
			// 
			this.lstNewLivreNetwork.FormattingEnabled = true;
			this.lstNewLivreNetwork.Location = new System.Drawing.Point(15, 282);
			this.lstNewLivreNetwork.Name = "lstNewLivreNetwork";
			this.lstNewLivreNetwork.Size = new System.Drawing.Size(254, 160);
			this.lstNewLivreNetwork.TabIndex = 19;
			this.lstNewLivreNetwork.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LivreEmprunt_MouseDown);
			// 
			// lstNewLivreLocal
			// 
			this.lstNewLivreLocal.FormattingEnabled = true;
			this.lstNewLivreLocal.Location = new System.Drawing.Point(15, 55);
			this.lstNewLivreLocal.Name = "lstNewLivreLocal";
			this.lstNewLivreLocal.Size = new System.Drawing.Size(254, 160);
			this.lstNewLivreLocal.TabIndex = 0;
			this.lstNewLivreLocal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LivreEmprunt_MouseDown);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totoToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(161, 26);
			// 
			// totoToolStripMenuItem
			// 
			this.totoToolStripMenuItem.Name = "totoToolStripMenuItem";
			this.totoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.totoToolStripMenuItem.Text = "Réserver un livre";
			this.totoToolStripMenuItem.Click += new System.EventHandler(this.totoToolStripMenuItem_Click);
			// 
			// DashboardManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 588);
			this.Controls.Add(this.lblBibliotheque);
			this.Controls.Add(this.lblBibliothequeTitle);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lblDtLastVisite);
			this.Controls.Add(this.lblDtLastVisiteTitle);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "DashboardManager";
			this.Text = " ";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DashboardManager_FormClosed);
			this.Load += new System.EventHandler(this.DashboardManager_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblDtLastVisiteTitle;
		private System.Windows.Forms.Label lblDtLastVisite;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label lblBibliotheque;
		private System.Windows.Forms.Label lblBibliothequeTitle;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ListBox lstNewLivreNetwork;
		private System.Windows.Forms.ListBox lstNewLivreLocal;
		private System.Windows.Forms.ListBox lstReservationEnCours;
		private System.Windows.Forms.ListBox lstReservationPasse;
		private System.Windows.Forms.ListBox lstEmpruntPasse;
		private System.Windows.Forms.ListBox lstEmpruntEnCours;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem totoToolStripMenuItem;
	}
}