namespace WindowsFormsApplication1 {
	partial class FrmMdi {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMdi));
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.libraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.findBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.administrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.amazonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addBookToLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._cmbToolStripBibliotheque = new System.Windows.Forms.ToolStripComboBox();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lblToolStripManagement = new System.Windows.Forms.ToolStripTextBox();
			this.txtToolStripClientBibliotheque = new System.Windows.Forms.ToolStripTextBox();
			this.lblToolStripClient = new System.Windows.Forms.ToolStripTextBox();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.menuStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.libraryToolStripMenuItem,
            this.administrationToolStripMenuItem,
            this._cmbToolStripBibliotheque,
            this.helpToolStripMenuItem,
            this.lblToolStripManagement,
            this.txtToolStripClientBibliotheque,
            this.lblToolStripClient});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(702, 27);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "MenuStrip";
			// 
			// fileMenu
			// 
			this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
			this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
			this.fileMenu.Name = "fileMenu";
			this.fileMenu.Size = new System.Drawing.Size(37, 23);
			this.fileMenu.Text = "&File";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
			// 
			// libraryToolStripMenuItem
			// 
			this.libraryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.findBookToolStripMenuItem});
			this.libraryToolStripMenuItem.Name = "libraryToolStripMenuItem";
			this.libraryToolStripMenuItem.Size = new System.Drawing.Size(50, 23);
			this.libraryToolStripMenuItem.Text = "Cl&ient";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
			this.toolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Black;
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
			this.toolStripMenuItem1.Size = new System.Drawing.Size(174, 22);
			this.toolStripMenuItem1.Text = "Das&hboard";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.ShowClientDashboard);
			// 
			// findBookToolStripMenuItem
			// 
			this.findBookToolStripMenuItem.Name = "findBookToolStripMenuItem";
			this.findBookToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.findBookToolStripMenuItem.Text = "&Find Book";
			this.findBookToolStripMenuItem.Click += new System.EventHandler(this.findBookToolStripMenuItem_Click);
			// 
			// administrationToolStripMenuItem
			// 
			this.administrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.amazonToolStripMenuItem,
            this.addBookToLibraryToolStripMenuItem});
			this.administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
			this.administrationToolStripMenuItem.Size = new System.Drawing.Size(98, 23);
			this.administrationToolStripMenuItem.Text = "&Administration";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
			this.toolStripMenuItem2.ImageTransparentColor = System.Drawing.Color.Black;
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
			this.toolStripMenuItem2.Size = new System.Drawing.Size(173, 22);
			this.toolStripMenuItem2.Text = "&Dashboard";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.ShowAdminDashboard);
			// 
			// amazonToolStripMenuItem
			// 
			this.amazonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem});
			this.amazonToolStripMenuItem.Name = "amazonToolStripMenuItem";
			this.amazonToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.amazonToolStripMenuItem.Text = "A&mazon";
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
			this.searchToolStripMenuItem.Text = "Sea&rch";
			this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
			// 
			// addBookToLibraryToolStripMenuItem
			// 
			this.addBookToLibraryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBookToolStripMenuItem});
			this.addBookToLibraryToolStripMenuItem.Name = "addBookToLibraryToolStripMenuItem";
			this.addBookToLibraryToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.addBookToLibraryToolStripMenuItem.Text = "Li&brary";
			// 
			// addBookToolStripMenuItem
			// 
			this.addBookToolStripMenuItem.Enabled = false;
			this.addBookToolStripMenuItem.Name = "addBookToolStripMenuItem";
			this.addBookToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.addBookToolStripMenuItem.Text = "A&dd Book";
			this.addBookToolStripMenuItem.Click += new System.EventHandler(this.addBookToolStripMenuItem_Click);
			// 
			// _cmbToolStripBibliotheque
			// 
			this._cmbToolStripBibliotheque.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this._cmbToolStripBibliotheque.DropDownHeight = 110;
			this._cmbToolStripBibliotheque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cmbToolStripBibliotheque.DropDownWidth = 122;
			this._cmbToolStripBibliotheque.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this._cmbToolStripBibliotheque.IntegralHeight = false;
			this._cmbToolStripBibliotheque.MaxDropDownItems = 9;
			this._cmbToolStripBibliotheque.MergeAction = System.Windows.Forms.MergeAction.Insert;
			this._cmbToolStripBibliotheque.Name = "_cmbToolStripBibliotheque";
			this._cmbToolStripBibliotheque.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmbToolStripBibliotheque.Size = new System.Drawing.Size(121, 23);
			this._cmbToolStripBibliotheque.Sorted = true;
			this._cmbToolStripBibliotheque.Tag = "Bibliotheque";
			this._cmbToolStripBibliotheque.ToolTipText = "Bibliotheque";
			this._cmbToolStripBibliotheque.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.aboutToolStripMenuItem.Text = "&About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// lblToolStripManagement
			// 
			this.lblToolStripManagement.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.lblToolStripManagement.BackColor = System.Drawing.SystemColors.Window;
			this.lblToolStripManagement.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblToolStripManagement.Name = "lblToolStripManagement";
			this.lblToolStripManagement.ReadOnly = true;
			this.lblToolStripManagement.Size = new System.Drawing.Size(60, 23);
			this.lblToolStripManagement.Text = "Gestion : ";
			this.lblToolStripManagement.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtToolStripClientBibliotheque
			// 
			this.txtToolStripClientBibliotheque.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.txtToolStripClientBibliotheque.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtToolStripClientBibliotheque.Name = "txtToolStripClientBibliotheque";
			this.txtToolStripClientBibliotheque.ReadOnly = true;
			this.txtToolStripClientBibliotheque.Size = new System.Drawing.Size(100, 23);
			// 
			// lblToolStripClient
			// 
			this.lblToolStripClient.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.lblToolStripClient.BackColor = System.Drawing.SystemColors.Window;
			this.lblToolStripClient.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblToolStripClient.Name = "lblToolStripClient";
			this.lblToolStripClient.ReadOnly = true;
			this.lblToolStripClient.Size = new System.Drawing.Size(120, 23);
			this.lblToolStripClient.Text = "Bibliotheque Client : ";
			this.lblToolStripClient.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 431);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(702, 22);
			this.statusStrip.TabIndex = 2;
			this.statusStrip.Text = "StatusStrip";
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
			this.toolStripStatusLabel.Text = "Status";
			// 
			// FrmMdi
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(702, 453);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip;
			this.Name = "FrmMdi";
			this.Text = "FrmMdi";
			this.Load += new System.EventHandler(this.FrmMdi_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion


		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
		private System.Windows.Forms.ToolStripMenuItem fileMenu;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.ToolStripMenuItem administrationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem amazonToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addBookToLibraryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addBookToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem libraryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem findBookToolStripMenuItem;
		private System.Windows.Forms.ToolStripTextBox lblToolStripClient;
		private System.Windows.Forms.ToolStripTextBox txtToolStripClientBibliotheque;
		private System.Windows.Forms.ToolStripTextBox lblToolStripManagement;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
	}
}



