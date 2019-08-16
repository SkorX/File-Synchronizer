namespace File_Synchronizer
{
    partial class FailedSynchronizingFilesForm
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
            this.failedFilesList = new System.Windows.Forms.DataGridView();
            this.remove = new System.Windows.Forms.DataGridViewImageColumn();
            this.destFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.failedFilesList)).BeginInit();
            this.SuspendLayout();
            // 
            // failedFilesList
            // 
            this.failedFilesList.AllowUserToAddRows = false;
            this.failedFilesList.AllowUserToDeleteRows = false;
            this.failedFilesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.failedFilesList.BackgroundColor = System.Drawing.Color.White;
            this.failedFilesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.failedFilesList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.remove,
            this.destFolder});
            this.failedFilesList.Location = new System.Drawing.Point(0, 0);
            this.failedFilesList.Name = "failedFilesList";
            this.failedFilesList.ReadOnly = true;
            this.failedFilesList.RowHeadersVisible = false;
            this.failedFilesList.Size = new System.Drawing.Size(535, 246);
            this.failedFilesList.TabIndex = 0;
            // 
            // remove
            // 
            this.remove.Frozen = true;
            this.remove.HeaderText = "";
            this.remove.Image = global::File_Synchronizer.Properties.Resources.Exclamation;
            this.remove.MinimumWidth = 24;
            this.remove.Name = "remove";
            this.remove.ReadOnly = true;
            this.remove.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.remove.Width = 24;
            // 
            // destFolder
            // 
            this.destFolder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.destFolder.HeaderText = "Unsynchronized file";
            this.destFolder.MinimumWidth = 350;
            this.destFolder.Name = "destFolder";
            this.destFolder.ReadOnly = true;
            // 
            // FailedSynchronizingFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 246);
            this.Controls.Add(this.failedFilesList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FailedSynchronizingFilesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Usynchronized files list";
            ((System.ComponentModel.ISupportInitialize)(this.failedFilesList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView failedFilesList;
        private System.Windows.Forms.DataGridViewImageColumn remove;
        private System.Windows.Forms.DataGridViewTextBoxColumn destFolder;
    }
}