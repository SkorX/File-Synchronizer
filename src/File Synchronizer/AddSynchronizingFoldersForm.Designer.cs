namespace File_Synchronizer
{
    partial class AddSynchronizingFoldersForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.destFolderPathText = new System.Windows.Forms.TextBox();
            this.sourceFolderPathText = new System.Windows.Forms.TextBox();
            this.sourceBrowseButton = new System.Windows.Forms.Button();
            this.destBrowseButton = new System.Windows.Forms.Button();
            this.sourceFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.destFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.twoWayCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source directory:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destination directory:";
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(339, 95);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 2;
            this.confirmButton.Text = "Add";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // destFolderPathText
            // 
            this.destFolderPathText.Location = new System.Drawing.Point(124, 42);
            this.destFolderPathText.Name = "destFolderPathText";
            this.destFolderPathText.Size = new System.Drawing.Size(209, 20);
            this.destFolderPathText.TabIndex = 3;
            // 
            // sourceFolderPathText
            // 
            this.sourceFolderPathText.Location = new System.Drawing.Point(105, 12);
            this.sourceFolderPathText.Name = "sourceFolderPathText";
            this.sourceFolderPathText.Size = new System.Drawing.Size(228, 20);
            this.sourceFolderPathText.TabIndex = 3;
            // 
            // sourceBrowseButton
            // 
            this.sourceBrowseButton.Location = new System.Drawing.Point(339, 11);
            this.sourceBrowseButton.Name = "sourceBrowseButton";
            this.sourceBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.sourceBrowseButton.TabIndex = 4;
            this.sourceBrowseButton.Text = "Browse";
            this.sourceBrowseButton.UseVisualStyleBackColor = true;
            this.sourceBrowseButton.Click += new System.EventHandler(this.sourceBrowseButton_Click);
            // 
            // destBrowseButton
            // 
            this.destBrowseButton.Location = new System.Drawing.Point(339, 40);
            this.destBrowseButton.Name = "destBrowseButton";
            this.destBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.destBrowseButton.TabIndex = 5;
            this.destBrowseButton.Text = "Browse";
            this.destBrowseButton.UseVisualStyleBackColor = true;
            this.destBrowseButton.Click += new System.EventHandler(this.destBrowseButton_Click);
            // 
            // sourceFolder
            // 
            this.sourceFolder.HelpRequest += new System.EventHandler(this.sourceFolder_HelpRequest);
            // 
            // destFolder
            // 
            this.destFolder.HelpRequest += new System.EventHandler(this.destFolder_HelpRequest);
            // 
            // twoWayCheckbox
            // 
            this.twoWayCheckbox.AutoSize = true;
            this.twoWayCheckbox.Location = new System.Drawing.Point(15, 73);
            this.twoWayCheckbox.Name = "twoWayCheckbox";
            this.twoWayCheckbox.Size = new System.Drawing.Size(72, 17);
            this.twoWayCheckbox.TabIndex = 6;
            this.twoWayCheckbox.Text = "Two-Way";
            this.twoWayCheckbox.UseVisualStyleBackColor = true;
            // 
            // AddSynchronizingFoldersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 128);
            this.Controls.Add(this.twoWayCheckbox);
            this.Controls.Add(this.destBrowseButton);
            this.Controls.Add(this.sourceBrowseButton);
            this.Controls.Add(this.sourceFolderPathText);
            this.Controls.Add(this.destFolderPathText);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSynchronizingFoldersForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Add folders to synchronize";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.TextBox destFolderPathText;
        private System.Windows.Forms.TextBox sourceFolderPathText;
        private System.Windows.Forms.Button sourceBrowseButton;
        private System.Windows.Forms.Button destBrowseButton;
        private System.Windows.Forms.FolderBrowserDialog sourceFolder;
        private System.Windows.Forms.FolderBrowserDialog destFolder;
        private System.Windows.Forms.CheckBox twoWayCheckbox;
    }
}