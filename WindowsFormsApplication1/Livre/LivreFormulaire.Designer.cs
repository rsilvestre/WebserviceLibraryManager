namespace WindowsFormsApplication1.Livre {
	partial class LivreFormulaire {
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
			this.components = new System.ComponentModel.Container();
			this.txtRef = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.txtBibliotheque = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtAuteur = new System.Windows.Forms.TextBox();
			this.datePicker = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.picBook = new System.Windows.Forms.PictureBox();
			this.webDescription = new System.Windows.Forms.WebBrowser();
			this.txtISBN = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cmbBibliotheque = new System.Windows.Forms.ComboBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.picBook)).BeginInit();
			this.SuspendLayout();
			// 
			// txtRef
			// 
			this.txtRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtRef.Location = new System.Drawing.Point(50, 8);
			this.txtRef.Name = "txtRef";
			this.txtRef.ReadOnly = true;
			this.txtRef.Size = new System.Drawing.Size(100, 20);
			this.txtRef.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(24, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Ref";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(216, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Bibliotheque";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 53);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(28, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Titre";
			// 
			// txtTitle
			// 
			this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTitle.Location = new System.Drawing.Point(50, 46);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(398, 26);
			this.txtTitle.TabIndex = 5;
			// 
			// txtBibliotheque
			// 
			this.txtBibliotheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtBibliotheque.Location = new System.Drawing.Point(156, 28);
			this.txtBibliotheque.Name = "txtBibliotheque";
			this.txtBibliotheque.ReadOnly = true;
			this.txtBibliotheque.Size = new System.Drawing.Size(161, 20);
			this.txtBibliotheque.TabIndex = 6;
			this.txtBibliotheque.Visible = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 125);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Auteur";
			// 
			// txtAuteur
			// 
			this.txtAuteur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtAuteur.Location = new System.Drawing.Point(50, 121);
			this.txtAuteur.Name = "txtAuteur";
			this.txtAuteur.Size = new System.Drawing.Size(129, 20);
			this.txtAuteur.TabIndex = 8;
			// 
			// datePicker
			// 
			this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.datePicker.Location = new System.Drawing.Point(287, 121);
			this.datePicker.Name = "datePicker";
			this.datePicker.Size = new System.Drawing.Size(161, 20);
			this.datePicker.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(221, 125);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Publication";
			// 
			// picBook
			// 
			this.picBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picBook.Location = new System.Drawing.Point(472, 9);
			this.picBook.Name = "picBook";
			this.picBook.Size = new System.Drawing.Size(229, 325);
			this.picBook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBook.TabIndex = 11;
			this.picBook.TabStop = false;
			// 
			// webDescription
			// 
			this.webDescription.Location = new System.Drawing.Point(50, 158);
			this.webDescription.MinimumSize = new System.Drawing.Size(20, 20);
			this.webDescription.Name = "webDescription";
			this.webDescription.Size = new System.Drawing.Size(398, 176);
			this.webDescription.TabIndex = 12;
			// 
			// txtISBN
			// 
			this.txtISBN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtISBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtISBN.Location = new System.Drawing.Point(50, 82);
			this.txtISBN.Name = "txtISBN";
			this.txtISBN.Size = new System.Drawing.Size(398, 26);
			this.txtISBN.TabIndex = 14;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 89);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(32, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "ISBN";
			// 
			// cmbBibliotheque
			// 
			this.cmbBibliotheque.FormattingEnabled = true;
			this.cmbBibliotheque.Location = new System.Drawing.Point(287, 7);
			this.cmbBibliotheque.Name = "cmbBibliotheque";
			this.cmbBibliotheque.Size = new System.Drawing.Size(161, 21);
			this.cmbBibliotheque.TabIndex = 15;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// LivreFormulaire
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.cmbBibliotheque);
			this.Controls.Add(this.txtISBN);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.webDescription);
			this.Controls.Add(this.picBook);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.datePicker);
			this.Controls.Add(this.txtAuteur);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtBibliotheque);
			this.Controls.Add(this.txtTitle);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtRef);
			this.Name = "LivreFormulaire";
			this.Size = new System.Drawing.Size(710, 342);
			((System.ComponentModel.ISupportInitialize)(this.picBook)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtRef;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.TextBox txtBibliotheque;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtAuteur;
		private System.Windows.Forms.DateTimePicker datePicker;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.PictureBox picBook;
		private System.Windows.Forms.WebBrowser webDescription;
		private System.Windows.Forms.TextBox txtISBN;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cmbBibliotheque;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
	}
}
