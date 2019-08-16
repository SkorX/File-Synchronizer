namespace File_Synchronizer
{
    partial class RemoveSychronizingFoldersForm
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
            this.foldersList = new System.Windows.Forms.DataGridView();
            this.srcFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.twoWaySync = new System.Windows.Forms.DataGridViewImageColumn();
            this.remove = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.foldersList)).BeginInit();
            this.SuspendLayout();
            // 
            // foldersList
            // 
            this.foldersList.AllowUserToAddRows = false;
            this.foldersList.AllowUserToDeleteRows = false;
            this.foldersList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foldersList.BackgroundColor = System.Drawing.Color.White;
            this.foldersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.foldersList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.srcFolder,
            this.destFolder,
            this.twoWaySync,
            this.remove});
            this.foldersList.Location = new System.Drawing.Point(0, 0);
            this.foldersList.Name = "foldersList";
            this.foldersList.ReadOnly = true;
            this.foldersList.RowHeadersVisible = false;
            this.foldersList.Size = new System.Drawing.Size(496, 217);
            this.foldersList.TabIndex = 0;
            this.foldersList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // srcFolder
            // 
            this.srcFolder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.srcFolder.FillWeight = 50F;
            this.srcFolder.HeaderText = "Source folder";
            this.srcFolder.Name = "srcFolder";
            this.srcFolder.ReadOnly = true;
            // 
            // destFolder
            // 
            this.destFolder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.destFolder.FillWeight = 50F;
            this.destFolder.HeaderText = "Destination folder";
            this.destFolder.Name = "destFolder";
            this.destFolder.ReadOnly = true;
            // 
            // twoWaySync
            // 
            this.twoWaySync.HeaderText = "";
            this.twoWaySync.MinimumWidth = 24;
            this.twoWaySync.Name = "twoWaySync";
            this.twoWaySync.ReadOnly = true;
            this.twoWaySync.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.twoWaySync.Width = 24;
            // 
            // remove
            // 
            this.remove.HeaderText = "";
            this.remove.Image = global::File_Synchronizer.Properties.Resources.trash;
            this.remove.MinimumWidth = 24;
            this.remove.Name = "remove";
            this.remove.ReadOnly = true;
            this.remove.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.remove.Width = 24;
            // 
            // RemoveSychronizingFoldersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 217);
            this.Controls.Add(this.foldersList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemoveSychronizingFoldersForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Remove folders to synchronize";
            ((System.ComponentModel.ISupportInitialize)(this.foldersList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView foldersList;
        private System.Windows.Forms.DataGridViewTextBoxColumn srcFolder;
        private System.Windows.Forms.DataGridViewTextBoxColumn destFolder;
        private System.Windows.Forms.DataGridViewImageColumn twoWaySync;
        private System.Windows.Forms.DataGridViewImageColumn remove;
    }
}