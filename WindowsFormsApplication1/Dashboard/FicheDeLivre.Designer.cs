namespace WindowsFormsApplication1.Dashboard {
	partial class FicheDeLivre {
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
			this.picBook = new System.Windows.Forms.PictureBox();
			this.lblTitre = new System.Windows.Forms.Label();
			this.lblAuteurs = new System.Windows.Forms.Label();
			this.lblPublication = new System.Windows.Forms.Label();
			this.webDescription = new System.Windows.Forms.WebBrowser();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblBibliotheque = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblEmpruntStatus = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lblReservationStatus = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.picBook)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// picBook
			// 
			this.picBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picBook.Location = new System.Drawing.Point(414, 3);
			this.picBook.Name = "picBook";
			this.picBook.Size = new System.Drawing.Size(159, 206);
			this.picBook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBook.TabIndex = 12;
			this.picBook.TabStop = false;
			// 
			// lblTitre
			// 
			this.lblTitre.AutoSize = true;
			this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitre.Location = new System.Drawing.Point(3, 3);
			this.lblTitre.Name = "lblTitre";
			this.lblTitre.Size = new System.Drawing.Size(55, 20);
			this.lblTitre.TabIndex = 13;
			this.lblTitre.Text = "lblTitre";
			// 
			// lblAuteurs
			// 
			this.lblAuteurs.AutoSize = true;
			this.lblAuteurs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAuteurs.Location = new System.Drawing.Point(3, 153);
			this.lblAuteurs.Name = "lblAuteurs";
			this.lblAuteurs.Size = new System.Drawing.Size(80, 20);
			this.lblAuteurs.TabIndex = 15;
			this.lblAuteurs.Text = "lblAuteurs";
			// 
			// lblPublication
			// 
			this.lblPublication.AutoSize = true;
			this.lblPublication.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPublication.Location = new System.Drawing.Point(4, 186);
			this.lblPublication.Name = "lblPublication";
			this.lblPublication.Size = new System.Drawing.Size(69, 13);
			this.lblPublication.TabIndex = 16;
			this.lblPublication.Text = "lblPublication";
			// 
			// webDescription
			// 
			this.webDescription.Location = new System.Drawing.Point(7, 31);
			this.webDescription.MinimumSize = new System.Drawing.Size(20, 20);
			this.webDescription.Name = "webDescription";
			this.webDescription.Size = new System.Drawing.Size(401, 108);
			this.webDescription.TabIndex = 17;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.lblBibliotheque);
			this.panel1.Controls.Add(this.lblPublication);
			this.panel1.Controls.Add(this.webDescription);
			this.panel1.Controls.Add(this.lblAuteurs);
			this.panel1.Controls.Add(this.picBook);
			this.panel1.Controls.Add(this.lblTitre);
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(578, 213);
			this.panel1.TabIndex = 18;
			// 
			// lblBibliotheque
			// 
			this.lblBibliotheque.AutoSize = true;
			this.lblBibliotheque.Location = new System.Drawing.Point(144, 186);
			this.lblBibliotheque.Name = "lblBibliotheque";
			this.lblBibliotheque.Size = new System.Drawing.Size(75, 13);
			this.lblBibliotheque.TabIndex = 18;
			this.lblBibliotheque.Text = "lblBibliotheque";
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.lblEmpruntStatus);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Location = new System.Drawing.Point(3, 222);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(286, 250);
			this.panel2.TabIndex = 19;
			// 
			// lblEmpruntStatus
			// 
			this.lblEmpruntStatus.AutoSize = true;
			this.lblEmpruntStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEmpruntStatus.Location = new System.Drawing.Point(5, 44);
			this.lblEmpruntStatus.Name = "lblEmpruntStatus";
			this.lblEmpruntStatus.Size = new System.Drawing.Size(56, 20);
			this.lblEmpruntStatus.TabIndex = 20;
			this.lblEmpruntStatus.Text = "Status";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(109, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 20);
			this.label2.TabIndex = 18;
			this.label2.Text = "Emprunt";
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.lblReservationStatus);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Location = new System.Drawing.Point(295, 222);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(286, 250);
			this.panel3.TabIndex = 20;
			// 
			// lblReservationStatus
			// 
			this.lblReservationStatus.AutoSize = true;
			this.lblReservationStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblReservationStatus.Location = new System.Drawing.Point(3, 44);
			this.lblReservationStatus.Name = "lblReservationStatus";
			this.lblReservationStatus.Size = new System.Drawing.Size(56, 20);
			this.lblReservationStatus.TabIndex = 20;
			this.lblReservationStatus.Text = "Status";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(95, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 20);
			this.label1.TabIndex = 19;
			this.label1.Text = "Réservation";
			// 
			// FicheDeLivre
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel3);
			this.Name = "FicheDeLivre";
			this.Size = new System.Drawing.Size(586, 477);
			((System.ComponentModel.ISupportInitialize)(this.picBook)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox picBook;
		private System.Windows.Forms.Label lblTitre;
		private System.Windows.Forms.Label lblAuteurs;
		private System.Windows.Forms.Label lblPublication;
		private System.Windows.Forms.WebBrowser webDescription;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lblEmpruntStatus;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblReservationStatus;
		private System.Windows.Forms.Label lblBibliotheque;
	}
}
