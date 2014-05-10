namespace WindowsFormsApplication1.Livre {
	partial class SearchLivre {
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSelection = new System.Windows.Forms.Button();
			this.radioName = new System.Windows.Forms.RadioButton();
			this.radioISBN = new System.Windows.Forms.RadioButton();
			this.btnSearch = new System.Windows.Forms.Button();
			this.lstSearchResult = new System.Windows.Forms.ListBox();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(414, 224);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 14;
			this.btnCancel.Text = "&Annuller";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSelection
			// 
			this.btnSelection.Enabled = false;
			this.btnSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSelection.Location = new System.Drawing.Point(321, 224);
			this.btnSelection.Name = "btnSelection";
			this.btnSelection.Size = new System.Drawing.Size(75, 23);
			this.btnSelection.TabIndex = 13;
			this.btnSelection.Text = "&Selection";
			this.btnSelection.UseVisualStyleBackColor = true;
			// 
			// radioName
			// 
			this.radioName.AutoSize = true;
			this.radioName.Checked = true;
			this.radioName.Location = new System.Drawing.Point(423, 19);
			this.radioName.Name = "radioName";
			this.radioName.Size = new System.Drawing.Size(66, 17);
			this.radioName.TabIndex = 12;
			this.radioName.TabStop = true;
			this.radioName.Text = "Par &Nom";
			this.radioName.UseVisualStyleBackColor = true;
			// 
			// radioISBN
			// 
			this.radioISBN.AutoSize = true;
			this.radioISBN.Location = new System.Drawing.Point(348, 19);
			this.radioISBN.Name = "radioISBN";
			this.radioISBN.Size = new System.Drawing.Size(69, 17);
			this.radioISBN.TabIndex = 11;
			this.radioISBN.Text = "Par &ISBN";
			this.radioISBN.UseVisualStyleBackColor = true;
			this.radioISBN.CheckedChanged += new System.EventHandler(this.radioISBN_CheckedChanged);
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(258, 16);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 10;
			this.btnSearch.Text = "&Rechercher";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// lstSearchResult
			// 
			this.lstSearchResult.FormattingEnabled = true;
			this.lstSearchResult.Location = new System.Drawing.Point(26, 56);
			this.lstSearchResult.Name = "lstSearchResult";
			this.lstSearchResult.Size = new System.Drawing.Size(463, 147);
			this.lstSearchResult.TabIndex = 9;
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(26, 18);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(215, 20);
			this.txtSearch.TabIndex = 8;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
			// 
			// SearchLivre
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(517, 262);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSelection);
			this.Controls.Add(this.radioName);
			this.Controls.Add(this.radioISBN);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.lstSearchResult);
			this.Controls.Add(this.txtSearch);
			this.Name = "SearchLivre";
			this.Text = "SearchLivre";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSelection;
		private System.Windows.Forms.RadioButton radioName;
		private System.Windows.Forms.RadioButton radioISBN;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.ListBox lstSearchResult;
		private System.Windows.Forms.TextBox txtSearch;
	}
}