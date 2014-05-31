namespace WindowsFormsApplication1.DashboardAdmin {
	partial class DashboardAdminManager {
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
			this.totoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.lblBibliothequeTitle = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cmbBibliotheque = new System.Windows.Forms.ComboBox();
			this.btnDemandeManagement = new System.Windows.Forms.Button();
			this.btnEmpruntManagement = new System.Windows.Forms.Button();
			this.btnRetourManagement = new System.Windows.Forms.Button();
			this.btnStatManagement = new System.Windows.Forms.Button();
			this.btnLivreManagement = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.contextMenuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// totoToolStripMenuItem
			// 
			this.totoToolStripMenuItem.Name = "totoToolStripMenuItem";
			this.totoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.totoToolStripMenuItem.Text = "Réserver un livre";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totoToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(161, 26);
			// 
			// lblBibliothequeTitle
			// 
			this.lblBibliothequeTitle.AutoSize = true;
			this.lblBibliothequeTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.lblBibliothequeTitle.Location = new System.Drawing.Point(103, 9);
			this.lblBibliothequeTitle.Name = "lblBibliothequeTitle";
			this.lblBibliothequeTitle.Size = new System.Drawing.Size(74, 13);
			this.lblBibliothequeTitle.TabIndex = 35;
			this.lblBibliothequeTitle.Text = "Bibliothèque : ";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblName.Location = new System.Drawing.Point(58, 9);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(39, 13);
			this.lblName.TabIndex = 25;
			this.lblName.Text = "Name";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 13);
			this.label2.TabIndex = 24;
			this.label2.Text = "Bonjour : ";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.btnLivreManagement);
			this.panel1.Controls.Add(this.btnStatManagement);
			this.panel1.Controls.Add(this.btnRetourManagement);
			this.panel1.Controls.Add(this.btnEmpruntManagement);
			this.panel1.Controls.Add(this.btnDemandeManagement);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Location = new System.Drawing.Point(12, 56);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(287, 477);
			this.panel1.TabIndex = 37;
			// 
			// cmbBibliotheque
			// 
			this.cmbBibliotheque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbBibliotheque.FormattingEnabled = true;
			this.cmbBibliotheque.Location = new System.Drawing.Point(178, 6);
			this.cmbBibliotheque.Name = "cmbBibliotheque";
			this.cmbBibliotheque.Size = new System.Drawing.Size(121, 21);
			this.cmbBibliotheque.TabIndex = 38;
			this.cmbBibliotheque.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// btnDemandeManagement
			// 
			this.btnDemandeManagement.Location = new System.Drawing.Point(9, 393);
			this.btnDemandeManagement.Name = "btnDemandeManagement";
			this.btnDemandeManagement.Size = new System.Drawing.Size(75, 23);
			this.btnDemandeManagement.TabIndex = 0;
			this.btnDemandeManagement.Text = "Demande";
			this.btnDemandeManagement.UseVisualStyleBackColor = true;
			// 
			// btnEmpruntManagement
			// 
			this.btnEmpruntManagement.Location = new System.Drawing.Point(101, 393);
			this.btnEmpruntManagement.Name = "btnEmpruntManagement";
			this.btnEmpruntManagement.Size = new System.Drawing.Size(75, 23);
			this.btnEmpruntManagement.TabIndex = 1;
			this.btnEmpruntManagement.Text = "Emprunt";
			this.btnEmpruntManagement.UseVisualStyleBackColor = true;
			// 
			// btnRetourManagement
			// 
			this.btnRetourManagement.Location = new System.Drawing.Point(193, 393);
			this.btnRetourManagement.Name = "btnRetourManagement";
			this.btnRetourManagement.Size = new System.Drawing.Size(75, 23);
			this.btnRetourManagement.TabIndex = 2;
			this.btnRetourManagement.Text = "Retour";
			this.btnRetourManagement.UseVisualStyleBackColor = true;
			// 
			// btnStatManagement
			// 
			this.btnStatManagement.Location = new System.Drawing.Point(9, 440);
			this.btnStatManagement.Name = "btnStatManagement";
			this.btnStatManagement.Size = new System.Drawing.Size(75, 23);
			this.btnStatManagement.TabIndex = 3;
			this.btnStatManagement.Text = "Statistiques";
			this.btnStatManagement.UseVisualStyleBackColor = true;
			// 
			// btnLivreManagement
			// 
			this.btnLivreManagement.Location = new System.Drawing.Point(193, 440);
			this.btnLivreManagement.Name = "btnLivreManagement";
			this.btnLivreManagement.Size = new System.Drawing.Size(75, 23);
			this.btnLivreManagement.TabIndex = 4;
			this.btnLivreManagement.Text = "Livre";
			this.btnLivreManagement.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Location = new System.Drawing.Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(279, 365);
			this.panel2.TabIndex = 5;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Location = new System.Drawing.Point(3, 374);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(279, 98);
			this.panel3.TabIndex = 6;
			// 
			// DashboardAdminManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(311, 588);
			this.Controls.Add(this.cmbBibliotheque);
			this.Controls.Add(this.lblBibliothequeTitle);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "DashboardAdminManager";
			this.Text = "DashboardAdminManager";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DashboardAdminManager_FormClosed);
			this.Load += new System.EventHandler(this.DashboardAdminManager_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStripMenuItem totoToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.Label lblBibliothequeTitle;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ComboBox cmbBibliotheque;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnLivreManagement;
		private System.Windows.Forms.Button btnStatManagement;
		private System.Windows.Forms.Button btnRetourManagement;
		private System.Windows.Forms.Button btnEmpruntManagement;
		private System.Windows.Forms.Button btnDemandeManagement;
		private System.Windows.Forms.Panel panel3;
	}
}