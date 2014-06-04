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
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
			this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
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
            this.editMenu,
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
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
			this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
			this.fileMenu.Name = "fileMenu";
			this.fileMenu.Size = new System.Drawing.Size(37, 23);
			this.fileMenu.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
			this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
			this.newToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.newToolStripMenuItem.Text = "&Dashboard";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.ShowClientDashboard);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
			this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.openToolStripMenuItem.Text = "&Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenFile);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
			// 
			// editMenu
			// 
			this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator6,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator7,
            this.selectAllToolStripMenuItem});
			this.editMenu.Name = "editMenu";
			this.editMenu.Size = new System.Drawing.Size(39, 23);
			this.editMenu.Text = "&Edit";
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("undoToolStripMenuItem.Image")));
			this.undoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.undoToolStripMenuItem.Text = "&Undo";
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("redoToolStripMenuItem.Image")));
			this.redoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.redoToolStripMenuItem.Text = "&Redo";
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(161, 6);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
			this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.cutToolStripMenuItem.Text = "Cu&t";
			this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
			this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.copyToolStripMenuItem.Text = "&Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
			this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.pasteToolStripMenuItem.Text = "&Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(161, 6);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.selectAllToolStripMenuItem.Text = "Select &All";
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
			// cmbToolStripBibliotheque
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
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem1,
            this.toolStripSeparator10,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// contentsToolStripMenuItem
			// 
			this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
			this.contentsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.contentsToolStripMenuItem.Text = "&Contents";
			// 
			// indexToolStripMenuItem
			// 
			this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
			this.indexToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.indexToolStripMenuItem.Text = "&Index";
			// 
			// searchToolStripMenuItem1
			// 
			this.searchToolStripMenuItem1.Name = "searchToolStripMenuItem1";
			this.searchToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
			this.searchToolStripMenuItem1.Text = "&Search";
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(119, 6);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.aboutToolStripMenuItem.Text = "&About...";
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
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
		private System.Windows.Forms.ToolStripMenuItem fileMenu;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editMenu;
		private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.ToolStripMenuItem administrationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem amazonToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addBookToLibraryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addBookToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
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



