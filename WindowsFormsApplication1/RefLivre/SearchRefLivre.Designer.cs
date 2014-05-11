namespace WindowsFormsApplication1.RefLivre {
	partial class SearchRefLivre {
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
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.lstSearchResult = new System.Windows.Forms.ListBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.radioISBN = new System.Windows.Forms.RadioButton();
			this.radioName = new System.Windows.Forms.RadioButton();
			this.btnSelection = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSearchAmazon = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(34, 27);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(215, 20);
			this.txtSearch.TabIndex = 0;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
			// 
			// lstSearchResult
			// 
			this.lstSearchResult.FormattingEnabled = true;
			this.lstSearchResult.Location = new System.Drawing.Point(34, 65);
			this.lstSearchResult.Name = "lstSearchResult";
			this.lstSearchResult.Size = new System.Drawing.Size(463, 147);
			this.lstSearchResult.TabIndex = 1;
			this.lstSearchResult.SelectedValueChanged += new System.EventHandler(this.lstSearchResult_SelectedValueChanged);
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(266, 25);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 2;
			this.btnSearch.Text = "&Rechercher";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// radioISBN
			// 
			this.radioISBN.AutoSize = true;
			this.radioISBN.Location = new System.Drawing.Point(356, 28);
			this.radioISBN.Name = "radioISBN";
			this.radioISBN.Size = new System.Drawing.Size(69, 17);
			this.radioISBN.TabIndex = 3;
			this.radioISBN.Text = "Par &ISBN";
			this.radioISBN.UseVisualStyleBackColor = true;
			this.radioISBN.CheckedChanged += new System.EventHandler(this.radioISBN_CheckedChanged);
			// 
			// radioName
			// 
			this.radioName.AutoSize = true;
			this.radioName.Checked = true;
			this.radioName.Location = new System.Drawing.Point(431, 28);
			this.radioName.Name = "radioName";
			this.radioName.Size = new System.Drawing.Size(66, 17);
			this.radioName.TabIndex = 4;
			this.radioName.TabStop = true;
			this.radioName.Text = "Par &Nom";
			this.radioName.UseVisualStyleBackColor = true;
			// 
			// btnSelection
			// 
			this.btnSelection.Enabled = false;
			this.btnSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSelection.Location = new System.Drawing.Point(329, 233);
			this.btnSelection.Name = "btnSelection";
			this.btnSelection.Size = new System.Drawing.Size(75, 23);
			this.btnSelection.TabIndex = 5;
			this.btnSelection.Text = "&Selection";
			this.btnSelection.UseVisualStyleBackColor = true;
			this.btnSelection.Click += new System.EventHandler(this.btnSelection_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(422, 233);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "&Annuller";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSearchAmazon
			// 
			this.btnSearchAmazon.Location = new System.Drawing.Point(34, 233);
			this.btnSearchAmazon.Name = "btnSearchAmazon";
			this.btnSearchAmazon.Size = new System.Drawing.Size(151, 23);
			this.btnSearchAmazon.TabIndex = 7;
			this.btnSearchAmazon.Text = "Rercherche Sur A&mazon";
			this.btnSearchAmazon.UseVisualStyleBackColor = true;
			this.btnSearchAmazon.Click += new System.EventHandler(this.btnSearchAmazon_Click);
			// 
			// SearchRefLivre
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(531, 268);
			this.Controls.Add(this.btnSearchAmazon);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSelection);
			this.Controls.Add(this.radioName);
			this.Controls.Add(this.radioISBN);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.lstSearchResult);
			this.Controls.Add(this.txtSearch);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "SearchRefLivre";
			this.Text = "Recherche référence de livre";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.ListBox lstSearchResult;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.RadioButton radioISBN;
		private System.Windows.Forms.RadioButton radioName;
		private System.Windows.Forms.Button btnSelection;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSearchAmazon;
	}
}