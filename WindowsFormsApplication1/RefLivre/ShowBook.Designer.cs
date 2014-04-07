namespace WindowsFormsApplication1.RefLivre {
	partial class ShowBook {
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
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblAuthor = new System.Windows.Forms.Label();
			this.lblTimestamp = new System.Windows.Forms.Label();
			this.webDescription = new System.Windows.Forms.WebBrowser();
			((System.ComponentModel.ISupportInitialize)(this.picBook)).BeginInit();
			this.SuspendLayout();
			// 
			// picBook
			// 
			this.picBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picBook.Location = new System.Drawing.Point(354, 9);
			this.picBook.Name = "picBook";
			this.picBook.Size = new System.Drawing.Size(163, 215);
			this.picBook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBook.TabIndex = 0;
			this.picBook.TabStop = false;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(6, 12);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(38, 20);
			this.lblTitle.TabIndex = 1;
			this.lblTitle.Text = "Title";
			// 
			// lblAuthor
			// 
			this.lblAuthor.AutoSize = true;
			this.lblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAuthor.Location = new System.Drawing.Point(7, 41);
			this.lblAuthor.Name = "lblAuthor";
			this.lblAuthor.Size = new System.Drawing.Size(38, 13);
			this.lblAuthor.TabIndex = 2;
			this.lblAuthor.Text = "Author";
			// 
			// lblTimestamp
			// 
			this.lblTimestamp.AutoSize = true;
			this.lblTimestamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTimestamp.Location = new System.Drawing.Point(180, 41);
			this.lblTimestamp.Name = "lblTimestamp";
			this.lblTimestamp.Size = new System.Drawing.Size(85, 13);
			this.lblTimestamp.TabIndex = 3;
			this.lblTimestamp.Text = "Publication Date";
			// 
			// webDescription
			// 
			this.webDescription.Location = new System.Drawing.Point(10, 71);
			this.webDescription.MinimumSize = new System.Drawing.Size(20, 20);
			this.webDescription.Name = "webDescription";
			this.webDescription.Size = new System.Drawing.Size(322, 153);
			this.webDescription.TabIndex = 6;
			// 
			// ShowBook
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.webDescription);
			this.Controls.Add(this.lblTimestamp);
			this.Controls.Add(this.lblAuthor);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.picBook);
			this.Name = "ShowBook";
			this.Size = new System.Drawing.Size(527, 233);
			((System.ComponentModel.ISupportInitialize)(this.picBook)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox picBook;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblAuthor;
		private System.Windows.Forms.Label lblTimestamp;
		private System.Windows.Forms.WebBrowser webDescription;
	}
}
