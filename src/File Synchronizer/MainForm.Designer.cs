namespace File_Synchronizer
{
    partial class Popup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Popup));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addSyncFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listSyncFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.showFailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.syncLabel = new System.Windows.Forms.LinkLabel();
            this.stopSyncLabel = new System.Windows.Forms.LinkLabel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.underTitleLabel = new System.Windows.Forms.Label();
            this.syncFilesProgress = new System.Windows.Forms.Label();
            this.syncFilesDir = new System.Windows.Forms.Label();
            this.divider2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.syncFilesFile = new System.Windows.Forms.Label();
            this.pinCheckBox = new System.Windows.Forms.CheckBox();
            this.trayMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "File Synchronizer";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAppToolStripMenuItem,
            this.toolStripSeparator1,
            this.addSyncFoldersToolStripMenuItem,
            this.listSyncFoldersToolStripMenuItem,
            this.syncOptionsToolStripMenuItem,
            this.toolStripSeparator3,
            this.showFailsToolStripMenuItem,
            this.toolStripSeparator2,
            this.closeAppToolStripMenuItem});
            this.trayMenu.Name = "contextMenuStrip1";
            this.trayMenu.Size = new System.Drawing.Size(175, 154);
            this.trayMenu.Opening += new System.ComponentModel.CancelEventHandler(this.trayMenu_Opening);
            // 
            // showAppToolStripMenuItem
            // 
            this.showAppToolStripMenuItem.Name = "showAppToolStripMenuItem";
            this.showAppToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.showAppToolStripMenuItem.Text = "Show App";
            this.showAppToolStripMenuItem.Click += new System.EventHandler(this.showAppToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // addSyncFoldersToolStripMenuItem
            // 
            this.addSyncFoldersToolStripMenuItem.Name = "addSyncFoldersToolStripMenuItem";
            this.addSyncFoldersToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.addSyncFoldersToolStripMenuItem.Text = "Add sync folders";
            this.addSyncFoldersToolStripMenuItem.Click += new System.EventHandler(this.addSyncFoldersToolStripMenuItem_Click);
            // 
            // listSyncFoldersToolStripMenuItem
            // 
            this.listSyncFoldersToolStripMenuItem.Name = "listSyncFoldersToolStripMenuItem";
            this.listSyncFoldersToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.listSyncFoldersToolStripMenuItem.Text = "List of sync folders";
            this.listSyncFoldersToolStripMenuItem.Click += new System.EventHandler(this.listSyncFoldersToolStripMenuItem_Click);
            // 
            // syncOptionsToolStripMenuItem
            // 
            this.syncOptionsToolStripMenuItem.Name = "syncOptionsToolStripMenuItem";
            this.syncOptionsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.syncOptionsToolStripMenuItem.Text = "Sync options";
            this.syncOptionsToolStripMenuItem.Click += new System.EventHandler(this.syncOptionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(171, 6);
            // 
            // showFailsToolStripMenuItem
            // 
            this.showFailsToolStripMenuItem.Name = "showFailsToolStripMenuItem";
            this.showFailsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.showFailsToolStripMenuItem.Text = "List of skipped files";
            this.showFailsToolStripMenuItem.Click += new System.EventHandler(this.showFailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(171, 6);
            // 
            // closeAppToolStripMenuItem
            // 
            this.closeAppToolStripMenuItem.Name = "closeAppToolStripMenuItem";
            this.closeAppToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.closeAppToolStripMenuItem.Text = "Close";
            this.closeAppToolStripMenuItem.Click += new System.EventHandler(this.closeAppToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::File_Synchronizer.Properties.Resources.appImage;
            this.pictureBox1.Location = new System.Drawing.Point(7, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // syncLabel
            // 
            this.syncLabel.AutoSize = true;
            this.syncLabel.Location = new System.Drawing.Point(13, 65);
            this.syncLabel.Name = "syncLabel";
            this.syncLabel.Size = new System.Drawing.Size(65, 13);
            this.syncLabel.TabIndex = 3;
            this.syncLabel.TabStop = true;
            this.syncLabel.Text = "Synchronize";
            this.syncLabel.VisitedLinkColor = System.Drawing.Color.Blue;
            this.syncLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.syncLabel_LinkClicked);
            // 
            // stopSyncLabel
            // 
            this.stopSyncLabel.AutoSize = true;
            this.stopSyncLabel.Enabled = false;
            this.stopSyncLabel.Location = new System.Drawing.Point(13, 87);
            this.stopSyncLabel.Name = "stopSyncLabel";
            this.stopSyncLabel.Size = new System.Drawing.Size(105, 13);
            this.stopSyncLabel.TabIndex = 4;
            this.stopSyncLabel.TabStop = true;
            this.stopSyncLabel.Text = "Stop synchronization";
            this.stopSyncLabel.VisitedLinkColor = System.Drawing.Color.Blue;
            this.stopSyncLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.stopSyncLabel_LinkClicked);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.titleLabel.Location = new System.Drawing.Point(58, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(133, 13);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "Last synchroznization:";
            // 
            // underTitleLabel
            // 
            this.underTitleLabel.AutoSize = true;
            this.underTitleLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.underTitleLabel.Location = new System.Drawing.Point(58, 30);
            this.underTitleLabel.Name = "underTitleLabel";
            this.underTitleLabel.Size = new System.Drawing.Size(10, 13);
            this.underTitleLabel.TabIndex = 5;
            this.underTitleLabel.Text = " ";
            // 
            // syncFilesProgress
            // 
            this.syncFilesProgress.AutoEllipsis = true;
            this.syncFilesProgress.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.syncFilesProgress.Location = new System.Drawing.Point(13, 115);
            this.syncFilesProgress.Name = "syncFilesProgress";
            this.syncFilesProgress.Size = new System.Drawing.Size(374, 13);
            this.syncFilesProgress.TabIndex = 6;
            this.syncFilesProgress.Text = " ";
            this.syncFilesProgress.UseMnemonic = false;
            // 
            // syncFilesDir
            // 
            this.syncFilesDir.AutoEllipsis = true;
            this.syncFilesDir.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.syncFilesDir.Location = new System.Drawing.Point(13, 131);
            this.syncFilesDir.Name = "syncFilesDir";
            this.syncFilesDir.Size = new System.Drawing.Size(374, 13);
            this.syncFilesDir.TabIndex = 6;
            this.syncFilesDir.Tag = "";
            this.syncFilesDir.Text = " ";
            this.syncFilesDir.UseMnemonic = false;
            // 
            // divider2
            // 
            this.divider2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divider2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider2.Location = new System.Drawing.Point(13, 107);
            this.divider2.Name = "divider2";
            this.divider2.Size = new System.Drawing.Size(374, 2);
            this.divider2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(13, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(374, 2);
            this.label1.TabIndex = 7;
            // 
            // syncFilesFile
            // 
            this.syncFilesFile.AutoEllipsis = true;
            this.syncFilesFile.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.syncFilesFile.Location = new System.Drawing.Point(13, 147);
            this.syncFilesFile.Name = "syncFilesFile";
            this.syncFilesFile.Size = new System.Drawing.Size(374, 13);
            this.syncFilesFile.TabIndex = 6;
            this.syncFilesFile.Tag = "";
            this.syncFilesFile.Text = " ";
            this.syncFilesFile.UseMnemonic = false;
            // 
            // pinCheckBox
            // 
            this.pinCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.pinCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.pinCheckBox.BackgroundImage = global::File_Synchronizer.Properties.Resources.pin;
            this.pinCheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pinCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pinCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pinCheckBox.Location = new System.Drawing.Point(379, 1);
            this.pinCheckBox.Name = "pinCheckBox";
            this.pinCheckBox.Size = new System.Drawing.Size(18, 18);
            this.pinCheckBox.TabIndex = 1;
            this.pinCheckBox.UseVisualStyleBackColor = false;
            this.pinCheckBox.CheckedChanged += new System.EventHandler(this.pinCheckBox_CheckedChanged);
            // 
            // Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 163);
            this.ControlBox = false;
            this.Controls.Add(this.pinCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.divider2);
            this.Controls.Add(this.syncFilesFile);
            this.Controls.Add(this.syncFilesDir);
            this.Controls.Add(this.syncFilesProgress);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.underTitleLabel);
            this.Controls.Add(this.stopSyncLabel);
            this.Controls.Add(this.syncLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(-10, -10);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 165);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 165);
            this.Name = "Popup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.Popup_Deactivate);
            this.Shown += new System.EventHandler(this.Popup_Shown);
            this.trayMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem showAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addSyncFoldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listSyncFoldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.PictureBox pictureBox1;
        //private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        //private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label titleLabel;
        internal System.Windows.Forms.NotifyIcon trayIcon;
        internal System.Windows.Forms.LinkLabel syncLabel;
        internal System.Windows.Forms.LinkLabel stopSyncLabel;
        //private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.ToolStripMenuItem syncOptionsToolStripMenuItem;
        internal System.Windows.Forms.Label syncFilesProgress;
        internal System.Windows.Forms.Label syncFilesDir;
        internal System.Windows.Forms.Label underTitleLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem showFailsToolStripMenuItem;
        private System.Windows.Forms.Label divider2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label syncFilesFile;
        private System.Windows.Forms.CheckBox pinCheckBox;
    }
}

