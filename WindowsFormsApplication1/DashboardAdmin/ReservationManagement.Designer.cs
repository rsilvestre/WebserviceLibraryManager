namespace WindowsFormsApplication1.DashboardAdmin {
	partial class ReservationManagement {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.panel1 = new System.Windows.Forms.Panel();
			this.dataGridDemandeReservation = new System.Windows.Forms.DataGridView();
			this.cmbReservationToogle = new System.Windows.Forms.ComboBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnEmprunter = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.btnAnnuler = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtReservationDepassement = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtReservationDate = new System.Windows.Forms.TextBox();
			this.picBook = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtRefLivreTitre = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtClientId = new System.Windows.Forms.TextBox();
			this.lblClientName = new System.Windows.Forms.Label();
			this.txtClientName = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridDemandeReservation)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picBook)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.dataGridDemandeReservation);
			this.panel1.Location = new System.Drawing.Point(3, 30);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(391, 229);
			this.panel1.TabIndex = 0;
			// 
			// dataGridDemandeReservation
			// 
			this.dataGridDemandeReservation.AllowUserToAddRows = false;
			this.dataGridDemandeReservation.AllowUserToDeleteRows = false;
			this.dataGridDemandeReservation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridDemandeReservation.Location = new System.Drawing.Point(3, 3);
			this.dataGridDemandeReservation.Name = "dataGridDemandeReservation";
			this.dataGridDemandeReservation.ReadOnly = true;
			this.dataGridDemandeReservation.Size = new System.Drawing.Size(382, 221);
			this.dataGridDemandeReservation.TabIndex = 0;
			this.dataGridDemandeReservation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDemandeReservation_CellClick);
			this.dataGridDemandeReservation.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDemandeReservation_CellDoubleClick);
			// 
			// cmbReservationToogle
			// 
			this.cmbReservationToogle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbReservationToogle.FormattingEnabled = true;
			this.cmbReservationToogle.Location = new System.Drawing.Point(273, 3);
			this.cmbReservationToogle.Name = "cmbReservationToogle";
			this.cmbReservationToogle.Size = new System.Drawing.Size(121, 21);
			this.cmbReservationToogle.TabIndex = 1;
			this.cmbReservationToogle.SelectedIndexChanged += new System.EventHandler(this.cmbReservationToogle_SelectedIndexChanged);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.btnEmprunter);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.btnAnnuler);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.txtReservationDepassement);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.txtReservationDate);
			this.panel2.Controls.Add(this.picBook);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.txtRefLivreTitre);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.txtClientId);
			this.panel2.Controls.Add(this.lblClientName);
			this.panel2.Controls.Add(this.txtClientName);
			this.panel2.Location = new System.Drawing.Point(3, 265);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(391, 208);
			this.panel2.TabIndex = 2;
			// 
			// btnEmprunter
			// 
			this.btnEmprunter.Enabled = false;
			this.btnEmprunter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEmprunter.Location = new System.Drawing.Point(14, 169);
			this.btnEmprunter.Name = "btnEmprunter";
			this.btnEmprunter.Size = new System.Drawing.Size(92, 24);
			this.btnEmprunter.TabIndex = 19;
			this.btnEmprunter.Text = "&Emprunter";
			this.btnEmprunter.UseVisualStyleBackColor = true;
			this.btnEmprunter.Click += new System.EventHandler(this.btnEmprunter_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(137, 134);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(29, 13);
			this.label5.TabIndex = 18;
			this.label5.Text = "jours";
			// 
			// btnAnnuler
			// 
			this.btnAnnuler.Enabled = false;
			this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAnnuler.Location = new System.Drawing.Point(126, 169);
			this.btnAnnuler.Name = "btnAnnuler";
			this.btnAnnuler.Size = new System.Drawing.Size(92, 24);
			this.btnAnnuler.TabIndex = 2;
			this.btnAnnuler.Text = "&Annuler";
			this.btnAnnuler.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(40, 134);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 13);
			this.label4.TabIndex = 17;
			this.label4.Text = "Duration :";
			// 
			// txtReservationDepassement
			// 
			this.txtReservationDepassement.Location = new System.Drawing.Point(99, 131);
			this.txtReservationDepassement.Name = "txtReservationDepassement";
			this.txtReservationDepassement.ReadOnly = true;
			this.txtReservationDepassement.Size = new System.Drawing.Size(32, 20);
			this.txtReservationDepassement.TabIndex = 16;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 108);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(82, 13);
			this.label3.TabIndex = 15;
			this.label3.Text = "Réservation Id :";
			// 
			// txtReservationDate
			// 
			this.txtReservationDate.Location = new System.Drawing.Point(99, 105);
			this.txtReservationDate.Name = "txtReservationDate";
			this.txtReservationDate.ReadOnly = true;
			this.txtReservationDate.Size = new System.Drawing.Size(32, 20);
			this.txtReservationDate.TabIndex = 14;
			// 
			// picBook
			// 
			this.picBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picBook.Location = new System.Drawing.Point(235, 7);
			this.picBook.Name = "picBook";
			this.picBook.Size = new System.Drawing.Size(150, 196);
			this.picBook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBook.TabIndex = 13;
			this.picBook.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 71);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Titre :";
			// 
			// txtRefLivreTitre
			// 
			this.txtRefLivreTitre.Location = new System.Drawing.Point(57, 59);
			this.txtRefLivreTitre.Multiline = true;
			this.txtRefLivreTitre.Name = "txtRefLivreTitre";
			this.txtRefLivreTitre.ReadOnly = true;
			this.txtRefLivreTitre.Size = new System.Drawing.Size(172, 40);
			this.txtRefLivreTitre.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(29, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Id :";
			// 
			// txtClientId
			// 
			this.txtClientId.Location = new System.Drawing.Point(57, 33);
			this.txtClientId.Name = "txtClientId";
			this.txtClientId.ReadOnly = true;
			this.txtClientId.Size = new System.Drawing.Size(85, 20);
			this.txtClientId.TabIndex = 2;
			// 
			// lblClientName
			// 
			this.lblClientName.AutoSize = true;
			this.lblClientName.Location = new System.Drawing.Point(12, 10);
			this.lblClientName.Name = "lblClientName";
			this.lblClientName.Size = new System.Drawing.Size(39, 13);
			this.lblClientName.TabIndex = 1;
			this.lblClientName.Text = "Client :";
			// 
			// txtClientName
			// 
			this.txtClientName.Location = new System.Drawing.Point(57, 7);
			this.txtClientName.Name = "txtClientName";
			this.txtClientName.ReadOnly = true;
			this.txtClientName.Size = new System.Drawing.Size(136, 20);
			this.txtClientName.TabIndex = 0;
			// 
			// ReservationManagement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.cmbReservationToogle);
			this.Controls.Add(this.panel1);
			this.Name = "ReservationManagement";
			this.Size = new System.Drawing.Size(398, 477);
			this.Load += new System.EventHandler(this.ReservationManagement_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridDemandeReservation)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picBook)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView dataGridDemandeReservation;
		private System.Windows.Forms.ComboBox cmbReservationToogle;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtRefLivreTitre;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtClientId;
		private System.Windows.Forms.Label lblClientName;
		private System.Windows.Forms.TextBox txtClientName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtReservationDepassement;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtReservationDate;
		private System.Windows.Forms.PictureBox picBook;
		private System.Windows.Forms.Button btnAnnuler;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnEmprunter;
	}
}
