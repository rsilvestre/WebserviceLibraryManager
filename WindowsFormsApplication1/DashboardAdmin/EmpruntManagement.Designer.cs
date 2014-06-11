namespace WindowsFormsApplication1.DashboardAdmin {
	partial class EmpruntManagement {
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cmbLivreField = new System.Windows.Forms.ComboBox();
			this.cmbReservationField = new System.Windows.Forms.ComboBox();
			this.cmbClientField = new System.Windows.Forms.ComboBox();
			this.btnLivreGo = new System.Windows.Forms.Button();
			this.btnReservationGo = new System.Windows.Forms.Button();
			this.btnClientGo = new System.Windows.Forms.Button();
			this.txtLivreField = new System.Windows.Forms.TextBox();
			this.txtReservationField = new System.Windows.Forms.TextBox();
			this.txtClientField = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.cbAdministrateur = new System.Windows.Forms.CheckBox();
			this.lblBibliotheque = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.lblAlert = new System.Windows.Forms.Label();
			this.lblLivreReference = new System.Windows.Forms.Label();
			this.txtLivreReference = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnValider = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtReservationDepassement = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtReservationDate = new System.Windows.Forms.TextBox();
			this.picBook = new System.Windows.Forms.PictureBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtRefLivreTitre = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtClientId = new System.Windows.Forms.TextBox();
			this.lblClientName = new System.Windows.Forms.Label();
			this.txtClientName = new System.Windows.Forms.TextBox();
			this.lblInfo = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picBook)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(52, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Client :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(21, 95);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Réservation :";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(55, 134);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Livre :";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.cmbLivreField);
			this.panel1.Controls.Add(this.cmbReservationField);
			this.panel1.Controls.Add(this.cmbClientField);
			this.panel1.Controls.Add(this.btnLivreGo);
			this.panel1.Controls.Add(this.btnReservationGo);
			this.panel1.Controls.Add(this.btnClientGo);
			this.panel1.Controls.Add(this.txtLivreField);
			this.panel1.Controls.Add(this.txtReservationField);
			this.panel1.Controls.Add(this.txtClientField);
			this.panel1.Location = new System.Drawing.Point(3, 30);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(455, 147);
			this.panel1.TabIndex = 9;
			// 
			// cmbLivreField
			// 
			this.cmbLivreField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLivreField.Enabled = false;
			this.cmbLivreField.FormattingEnabled = true;
			this.cmbLivreField.Location = new System.Drawing.Point(271, 100);
			this.cmbLivreField.Name = "cmbLivreField";
			this.cmbLivreField.Size = new System.Drawing.Size(150, 21);
			this.cmbLivreField.TabIndex = 9;
			this.cmbLivreField.SelectedValueChanged += new System.EventHandler(this.cmbLivreField_SelectedValueChanged);
			// 
			// cmbReservationField
			// 
			this.cmbReservationField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbReservationField.Enabled = false;
			this.cmbReservationField.FormattingEnabled = true;
			this.cmbReservationField.Location = new System.Drawing.Point(271, 61);
			this.cmbReservationField.Name = "cmbReservationField";
			this.cmbReservationField.Size = new System.Drawing.Size(150, 21);
			this.cmbReservationField.TabIndex = 8;
			this.cmbReservationField.SelectedValueChanged += new System.EventHandler(this.cmbReservationField_SelectedValueChanged);
			// 
			// cmbClientField
			// 
			this.cmbClientField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbClientField.Enabled = false;
			this.cmbClientField.FormattingEnabled = true;
			this.cmbClientField.Location = new System.Drawing.Point(271, 24);
			this.cmbClientField.Name = "cmbClientField";
			this.cmbClientField.Size = new System.Drawing.Size(150, 21);
			this.cmbClientField.TabIndex = 7;
			this.cmbClientField.SelectedValueChanged += new System.EventHandler(this.cmbClientField_SelectedValueChanged);
			// 
			// btnLivreGo
			// 
			this.btnLivreGo.Enabled = false;
			this.btnLivreGo.Location = new System.Drawing.Point(236, 98);
			this.btnLivreGo.Name = "btnLivreGo";
			this.btnLivreGo.Size = new System.Drawing.Size(29, 23);
			this.btnLivreGo.TabIndex = 5;
			this.btnLivreGo.Text = "Go";
			this.btnLivreGo.UseVisualStyleBackColor = true;
			this.btnLivreGo.Click += new System.EventHandler(this.btnLivreGo_Click);
			// 
			// btnReservationGo
			// 
			this.btnReservationGo.Enabled = false;
			this.btnReservationGo.Location = new System.Drawing.Point(236, 59);
			this.btnReservationGo.Name = "btnReservationGo";
			this.btnReservationGo.Size = new System.Drawing.Size(29, 23);
			this.btnReservationGo.TabIndex = 4;
			this.btnReservationGo.Text = "Go";
			this.btnReservationGo.UseVisualStyleBackColor = true;
			this.btnReservationGo.Click += new System.EventHandler(this.btnReservationGo_Click);
			// 
			// btnClientGo
			// 
			this.btnClientGo.Location = new System.Drawing.Point(236, 22);
			this.btnClientGo.Name = "btnClientGo";
			this.btnClientGo.Size = new System.Drawing.Size(29, 23);
			this.btnClientGo.TabIndex = 3;
			this.btnClientGo.Text = "Go";
			this.btnClientGo.UseVisualStyleBackColor = true;
			this.btnClientGo.Click += new System.EventHandler(this.btnClientGo_Click);
			// 
			// txtLivreField
			// 
			this.txtLivreField.Location = new System.Drawing.Point(93, 100);
			this.txtLivreField.Name = "txtLivreField";
			this.txtLivreField.Size = new System.Drawing.Size(136, 20);
			this.txtLivreField.TabIndex = 2;
			this.txtLivreField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLivreField_KeyDown);
			// 
			// txtReservationField
			// 
			this.txtReservationField.Enabled = false;
			this.txtReservationField.Location = new System.Drawing.Point(93, 61);
			this.txtReservationField.Name = "txtReservationField";
			this.txtReservationField.Size = new System.Drawing.Size(136, 20);
			this.txtReservationField.TabIndex = 1;
			this.txtReservationField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReservationField_KeyDown);
			// 
			// txtClientField
			// 
			this.txtClientField.Location = new System.Drawing.Point(93, 24);
			this.txtClientField.Name = "txtClientField";
			this.txtClientField.Size = new System.Drawing.Size(136, 20);
			this.txtClientField.TabIndex = 0;
			this.txtClientField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClientField_KeyDown);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.cbAdministrateur);
			this.panel2.Controls.Add(this.lblBibliotheque);
			this.panel2.Controls.Add(this.label9);
			this.panel2.Controls.Add(this.lblAlert);
			this.panel2.Controls.Add(this.lblLivreReference);
			this.panel2.Controls.Add(this.txtLivreReference);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.btnValider);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.txtReservationDepassement);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Controls.Add(this.txtReservationDate);
			this.panel2.Controls.Add(this.picBook);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Controls.Add(this.txtRefLivreTitre);
			this.panel2.Controls.Add(this.label8);
			this.panel2.Controls.Add(this.txtClientId);
			this.panel2.Controls.Add(this.lblClientName);
			this.panel2.Controls.Add(this.txtClientName);
			this.panel2.Location = new System.Drawing.Point(3, 183);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(455, 291);
			this.panel2.TabIndex = 10;
			// 
			// cbAdministrateur
			// 
			this.cbAdministrateur.AutoCheck = false;
			this.cbAdministrateur.AutoSize = true;
			this.cbAdministrateur.Location = new System.Drawing.Point(201, 10);
			this.cbAdministrateur.Name = "cbAdministrateur";
			this.cbAdministrateur.Size = new System.Drawing.Size(15, 14);
			this.cbAdministrateur.TabIndex = 23;
			this.cbAdministrateur.UseVisualStyleBackColor = true;
			// 
			// lblBibliotheque
			// 
			this.lblBibliotheque.AutoSize = true;
			this.lblBibliotheque.Location = new System.Drawing.Point(207, 36);
			this.lblBibliotheque.Name = "lblBibliotheque";
			this.lblBibliotheque.Size = new System.Drawing.Size(64, 13);
			this.lblBibliotheque.TabIndex = 22;
			this.lblBibliotheque.Text = "bibliotheque";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(132, 36);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(71, 13);
			this.label9.TabIndex = 14;
			this.label9.Text = "Bibliotheque :";
			// 
			// lblAlert
			// 
			this.lblAlert.AutoSize = true;
			this.lblAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAlert.ForeColor = System.Drawing.Color.Red;
			this.lblAlert.Location = new System.Drawing.Point(45, 209);
			this.lblAlert.Name = "lblAlert";
			this.lblAlert.Size = new System.Drawing.Size(40, 16);
			this.lblAlert.TabIndex = 21;
			this.lblAlert.Text = "Alert";
			this.lblAlert.Visible = false;
			// 
			// lblLivreReference
			// 
			this.lblLivreReference.AutoSize = true;
			this.lblLivreReference.Location = new System.Drawing.Point(45, 137);
			this.lblLivreReference.Name = "lblLivreReference";
			this.lblLivreReference.Size = new System.Drawing.Size(48, 13);
			this.lblLivreReference.TabIndex = 20;
			this.lblLivreReference.Text = "Livre Id :";
			this.lblLivreReference.Visible = false;
			// 
			// txtLivreReference
			// 
			this.txtLivreReference.Location = new System.Drawing.Point(95, 134);
			this.txtLivreReference.Name = "txtLivreReference";
			this.txtLivreReference.ReadOnly = true;
			this.txtLivreReference.Size = new System.Drawing.Size(98, 20);
			this.txtLivreReference.TabIndex = 19;
			this.txtLivreReference.Visible = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(236, 108);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(29, 13);
			this.label5.TabIndex = 18;
			this.label5.Text = "jours";
			// 
			// btnValider
			// 
			this.btnValider.Enabled = false;
			this.btnValider.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnValider.Location = new System.Drawing.Point(57, 168);
			this.btnValider.Name = "btnValider";
			this.btnValider.Size = new System.Drawing.Size(153, 24);
			this.btnValider.TabIndex = 2;
			this.btnValider.Text = "&Valider";
			this.btnValider.UseVisualStyleBackColor = true;
			this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(148, 108);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 13);
			this.label4.TabIndex = 17;
			this.label4.Text = "Duration :";
			// 
			// txtReservationDepassement
			// 
			this.txtReservationDepassement.Location = new System.Drawing.Point(201, 105);
			this.txtReservationDepassement.Name = "txtReservationDepassement";
			this.txtReservationDepassement.ReadOnly = true;
			this.txtReservationDepassement.Size = new System.Drawing.Size(32, 20);
			this.txtReservationDepassement.TabIndex = 16;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(11, 108);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(82, 13);
			this.label6.TabIndex = 15;
			this.label6.Text = "Réservation Id :";
			// 
			// txtReservationDate
			// 
			this.txtReservationDate.Location = new System.Drawing.Point(95, 105);
			this.txtReservationDate.Name = "txtReservationDate";
			this.txtReservationDate.ReadOnly = true;
			this.txtReservationDate.Size = new System.Drawing.Size(53, 20);
			this.txtReservationDate.TabIndex = 14;
			// 
			// picBook
			// 
			this.picBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picBook.Location = new System.Drawing.Point(300, 3);
			this.picBook.Name = "picBook";
			this.picBook.Size = new System.Drawing.Size(150, 196);
			this.picBook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBook.TabIndex = 13;
			this.picBook.TabStop = false;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(17, 71);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(34, 13);
			this.label7.TabIndex = 5;
			this.label7.Text = "Titre :";
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
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(29, 36);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(22, 13);
			this.label8.TabIndex = 3;
			this.label8.Text = "Id :";
			// 
			// txtClientId
			// 
			this.txtClientId.Location = new System.Drawing.Point(57, 33);
			this.txtClientId.Name = "txtClientId";
			this.txtClientId.ReadOnly = true;
			this.txtClientId.Size = new System.Drawing.Size(69, 20);
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
			// lblInfo
			// 
			this.lblInfo.AutoSize = true;
			this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInfo.ForeColor = System.Drawing.Color.DodgerBlue;
			this.lblInfo.Location = new System.Drawing.Point(21, 6);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(33, 16);
			this.lblInfo.TabIndex = 12;
			this.lblInfo.Text = "Info";
			this.lblInfo.Visible = false;
			// 
			// EmpruntManagement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.Name = "EmpruntManagement";
			this.Size = new System.Drawing.Size(461, 477);
			this.Load += new System.EventHandler(this.EmpruntManagement_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picBook)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnValider;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtReservationDepassement;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtReservationDate;
		private System.Windows.Forms.PictureBox picBook;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtRefLivreTitre;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtClientId;
		private System.Windows.Forms.Label lblClientName;
		private System.Windows.Forms.TextBox txtClientName;
		private System.Windows.Forms.Button btnLivreGo;
		private System.Windows.Forms.Button btnReservationGo;
		private System.Windows.Forms.Button btnClientGo;
		private System.Windows.Forms.TextBox txtLivreField;
		private System.Windows.Forms.TextBox txtReservationField;
		private System.Windows.Forms.TextBox txtClientField;
		private System.Windows.Forms.ComboBox cmbLivreField;
		private System.Windows.Forms.ComboBox cmbReservationField;
		private System.Windows.Forms.ComboBox cmbClientField;
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.Label lblLivreReference;
		private System.Windows.Forms.TextBox txtLivreReference;
		private System.Windows.Forms.Label lblAlert;
		private System.Windows.Forms.Label lblBibliotheque;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.CheckBox cbAdministrateur;
	}
}
