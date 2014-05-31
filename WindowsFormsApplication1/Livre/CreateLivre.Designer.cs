namespace WindowsFormsApplication1.Livre {
	partial class CreateLivre {
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
			this.RefLivreSearch = new System.Windows.Forms.Button();
			this.btnCreate = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.livreFormulaire1 = new WindowsFormsApplication1.Livre.LivreFormulaire();
			this.SuspendLayout();
			// 
			// RefLivreSearch
			// 
			this.RefLivreSearch.Location = new System.Drawing.Point(14, 372);
			this.RefLivreSearch.Name = "RefLivreSearch";
			this.RefLivreSearch.Size = new System.Drawing.Size(145, 23);
			this.RefLivreSearch.TabIndex = 0;
			this.RefLivreSearch.Text = "Rercherche Référence";
			this.RefLivreSearch.UseVisualStyleBackColor = true;
			this.RefLivreSearch.Click += new System.EventHandler(this.refLivreSearch_Click);
			// 
			// btnCreate
			// 
			this.btnCreate.Enabled = false;
			this.btnCreate.Location = new System.Drawing.Point(561, 372);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(75, 23);
			this.btnCreate.TabIndex = 1;
			this.btnCreate.Text = "Créer";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(650, 372);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Annuller";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// livreFormulaire1
			// 
			this.livreFormulaire1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.livreFormulaire1.Location = new System.Drawing.Point(14, 15);
			this.livreFormulaire1.Name = "livreFormulaire1";
			this.livreFormulaire1.Size = new System.Drawing.Size(711, 344);
			this.livreFormulaire1.TabIndex = 3;
			// 
			// CreateLivre
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(738, 408);
			this.Controls.Add(this.livreFormulaire1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnCreate);
			this.Controls.Add(this.RefLivreSearch);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "CreateLivre";
			this.Text = "Ajout d\'un livre à la bibliotheque";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button RefLivreSearch;
		private System.Windows.Forms.Button btnCreate;
		private System.Windows.Forms.Button btnCancel;
		private LivreFormulaire livreFormulaire1;
	}
}