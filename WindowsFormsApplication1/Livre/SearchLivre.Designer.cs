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
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.dataGridSearchResult = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.lblBibliotheque = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridSearchResult)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(553, 401);
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
			this.btnSelection.Location = new System.Drawing.Point(460, 401);
			this.btnSelection.Name = "btnSelection";
			this.btnSelection.Size = new System.Drawing.Size(75, 23);
			this.btnSelection.TabIndex = 13;
			this.btnSelection.Text = "&Selection";
			this.btnSelection.UseVisualStyleBackColor = true;
			this.btnSelection.Click += new System.EventHandler(this.btnSelection_Click);
			// 
			// radioName
			// 
			this.radioName.AutoSize = true;
			this.radioName.Checked = true;
			this.radioName.Location = new System.Drawing.Point(500, 19);
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
			this.radioISBN.Location = new System.Drawing.Point(425, 19);
			this.radioISBN.Name = "radioISBN";
			this.radioISBN.Size = new System.Drawing.Size(69, 17);
			this.radioISBN.TabIndex = 11;
			this.radioISBN.Text = "Par &ISBN";
			this.radioISBN.UseVisualStyleBackColor = true;
			this.radioISBN.CheckedChanged += new System.EventHandler(this.radioISBN_CheckedChanged);
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(333, 16);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 10;
			this.btnSearch.Text = "&Rechercher";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(144, 18);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(183, 20);
			this.txtSearch.TabIndex = 8;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
			// 
			// dataGridSearchResult
			// 
			this.dataGridSearchResult.AllowUserToAddRows = false;
			this.dataGridSearchResult.AllowUserToDeleteRows = false;
			this.dataGridSearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridSearchResult.Location = new System.Drawing.Point(26, 56);
			this.dataGridSearchResult.Name = "dataGridSearchResult";
			this.dataGridSearchResult.ReadOnly = true;
			this.dataGridSearchResult.Size = new System.Drawing.Size(602, 329);
			this.dataGridSearchResult.TabIndex = 15;
			this.dataGridSearchResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridSearchResult_CellClick);
			this.dataGridSearchResult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridSearchResult_CellDoubleClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 406);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 13);
			this.label1.TabIndex = 16;
			this.label1.Text = "Bibliotheque : ";
			// 
			// lblBibliotheque
			// 
			this.lblBibliotheque.AutoSize = true;
			this.lblBibliotheque.Location = new System.Drawing.Point(93, 406);
			this.lblBibliotheque.Name = "lblBibliotheque";
			this.lblBibliotheque.Size = new System.Drawing.Size(35, 13);
			this.lblBibliotheque.TabIndex = 17;
			this.lblBibliotheque.Text = "label2";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(23, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(115, 13);
			this.label3.TabIndex = 18;
			this.label3.Text = "Champ de recherche : ";
			// 
			// SearchLivre
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(656, 436);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblBibliotheque);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridSearchResult);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSelection);
			this.Controls.Add(this.radioName);
			this.Controls.Add(this.radioISBN);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.txtSearch);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "SearchLivre";
			this.Text = "SearchLivre";
			this.Load += new System.EventHandler(this.SearchLivre_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridSearchResult)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSelection;
		private System.Windows.Forms.RadioButton radioName;
		private System.Windows.Forms.RadioButton radioISBN;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.DataGridView dataGridSearchResult;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblBibliotheque;
		private System.Windows.Forms.Label label3;
	}
}