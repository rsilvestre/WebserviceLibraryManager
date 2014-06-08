namespace WindowsFormsApplication1.Dashboard {
	partial class FicheDeLivreReservation {
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
			this.lblPublication = new System.Windows.Forms.Label();
			this.webDescription = new System.Windows.Forms.WebBrowser();
			this.lblAuteurs = new System.Windows.Forms.Label();
			this.picBook = new System.Windows.Forms.PictureBox();
			this.lblTitre = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblBibliotheque = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.lblNewReservationStatus = new System.Windows.Forms.Label();
			this.lblOldReservationStatus = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnAnnuler = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.picBook)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblPublication
			// 
			this.lblPublication.AutoSize = true;
			this.lblPublication.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPublication.Location = new System.Drawing.Point(2, 296);
			this.lblPublication.Name = "lblPublication";
			this.lblPublication.Size = new System.Drawing.Size(69, 13);
			this.lblPublication.TabIndex = 16;
			this.lblPublication.Text = "lblPublication";
			// 
			// webDescription
			// 
			this.webDescription.Location = new System.Drawing.Point(5, 60);
			this.webDescription.MinimumSize = new System.Drawing.Size(20, 20);
			this.webDescription.Name = "webDescription";
			this.webDescription.Size = new System.Drawing.Size(276, 186);
			this.webDescription.TabIndex = 17;
			// 
			// lblAuteurs
			// 
			this.lblAuteurs.AutoSize = true;
			this.lblAuteurs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAuteurs.Location = new System.Drawing.Point(1, 263);
			this.lblAuteurs.Name = "lblAuteurs";
			this.lblAuteurs.Size = new System.Drawing.Size(80, 20);
			this.lblAuteurs.TabIndex = 15;
			this.lblAuteurs.Text = "lblAuteurs";
			// 
			// picBook
			// 
			this.picBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picBook.Location = new System.Drawing.Point(296, 4);
			this.picBook.Name = "picBook";
			this.picBook.Size = new System.Drawing.Size(232, 318);
			this.picBook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBook.TabIndex = 12;
			this.picBook.TabStop = false;
			// 
			// lblTitre
			// 
			this.lblTitre.AutoSize = true;
			this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitre.Location = new System.Drawing.Point(1, 3);
			this.lblTitre.MaximumSize = new System.Drawing.Size(276, 0);
			this.lblTitre.Name = "lblTitre";
			this.lblTitre.Size = new System.Drawing.Size(55, 20);
			this.lblTitre.TabIndex = 13;
			this.lblTitre.Text = "lblTitre";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.lblBibliotheque);
			this.panel1.Controls.Add(this.lblPublication);
			this.panel1.Controls.Add(this.webDescription);
			this.panel1.Controls.Add(this.lblAuteurs);
			this.panel1.Controls.Add(this.lblTitre);
			this.panel1.Location = new System.Drawing.Point(4, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(286, 318);
			this.panel1.TabIndex = 21;
			// 
			// lblBibliotheque
			// 
			this.lblBibliotheque.AutoSize = true;
			this.lblBibliotheque.Location = new System.Drawing.Point(142, 296);
			this.lblBibliotheque.Name = "lblBibliotheque";
			this.lblBibliotheque.Size = new System.Drawing.Size(75, 13);
			this.lblBibliotheque.TabIndex = 18;
			this.lblBibliotheque.Text = "lblBibliotheque";
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.label2);
			this.panel3.Controls.Add(this.btnAnnuler);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.lblNewReservationStatus);
			this.panel3.Controls.Add(this.lblOldReservationStatus);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Location = new System.Drawing.Point(4, 328);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(524, 144);
			this.panel3.TabIndex = 23;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(248, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(159, 20);
			this.label3.TabIndex = 22;
			this.label3.Text = "Réservation en cours";
			// 
			// lblNewReservationStatus
			// 
			this.lblNewReservationStatus.AutoSize = true;
			this.lblNewReservationStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNewReservationStatus.Location = new System.Drawing.Point(248, 44);
			this.lblNewReservationStatus.Name = "lblNewReservationStatus";
			this.lblNewReservationStatus.Size = new System.Drawing.Size(56, 20);
			this.lblNewReservationStatus.TabIndex = 21;
			this.lblNewReservationStatus.Text = "Status";
			// 
			// lblOldReservationStatus
			// 
			this.lblOldReservationStatus.AutoSize = true;
			this.lblOldReservationStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblOldReservationStatus.Location = new System.Drawing.Point(1, 44);
			this.lblOldReservationStatus.Name = "lblOldReservationStatus";
			this.lblOldReservationStatus.Size = new System.Drawing.Size(56, 20);
			this.lblOldReservationStatus.TabIndex = 20;
			this.lblOldReservationStatus.Text = "Status";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(150, 20);
			this.label1.TabIndex = 19;
			this.label1.Text = "Réservation passée";
			// 
			// btnAnnuler
			// 
			this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAnnuler.Location = new System.Drawing.Point(416, 86);
			this.btnAnnuler.Name = "btnAnnuler";
			this.btnAnnuler.Size = new System.Drawing.Size(75, 23);
			this.btnAnnuler.TabIndex = 23;
			this.btnAnnuler.Text = "Annuler";
			this.btnAnnuler.UseVisualStyleBackColor = true;
			this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click_1);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(301, 91);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(115, 13);
			this.label2.TabIndex = 24;
			this.label2.Text = "Annuler la réservation :";
			// 
			// FicheDeLivreReservation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.picBook);
			this.Name = "FicheDeLivreReservation";
			this.Size = new System.Drawing.Size(534, 477);
			((System.ComponentModel.ISupportInitialize)(this.picBook)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblPublication;
		private System.Windows.Forms.WebBrowser webDescription;
		private System.Windows.Forms.Label lblAuteurs;
		private System.Windows.Forms.PictureBox picBook;
		private System.Windows.Forms.Label lblTitre;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblBibliotheque;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lblOldReservationStatus;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblNewReservationStatus;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnAnnuler;
	}
}
