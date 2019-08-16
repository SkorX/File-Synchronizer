namespace File_Synchronizer
{
    partial class SyncOptionsForm
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
            this.syncPauseTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.saveButton = new System.Windows.Forms.Button();
            this.syncNotifyCheckbox = new System.Windows.Forms.CheckBox();
            this.autostartCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.syncPauseTime)).BeginInit();
            this.SuspendLayout();
            // 
            // syncPauseTime
            // 
            this.syncPauseTime.Location = new System.Drawing.Point(75, 25);
            this.syncPauseTime.Maximum = new decimal(new int[] {
            10080,
            0,
            0,
            0});
            this.syncPauseTime.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.syncPauseTime.Name = "syncPauseTime";
            this.syncPauseTime.Size = new System.Drawing.Size(142, 20);
            this.syncPauseTime.TabIndex = 0;
            this.tooltip.SetToolTip(this.syncPauseTime, "Minimum value 15 minutes. Maximum value 10080 (7 days).");
            this.syncPauseTime.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "minutes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Time between synchronizations:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(191, 104);
            this.saveButton.MaximumSize = new System.Drawing.Size(75, 23);
            this.saveButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.tooltip.SetToolTip(this.saveButton, "Saves settings.");
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // syncNotifyCheckbox
            // 
            this.syncNotifyCheckbox.AutoSize = true;
            this.syncNotifyCheckbox.Location = new System.Drawing.Point(12, 56);
            this.syncNotifyCheckbox.Name = "syncNotifyCheckbox";
            this.syncNotifyCheckbox.Size = new System.Drawing.Size(147, 17);
            this.syncNotifyCheckbox.TabIndex = 6;
            this.syncNotifyCheckbox.Text = "notify when synchronizing";
            this.tooltip.SetToolTip(this.syncNotifyCheckbox, "If checked a message will be shown when application start and stops file synchron" +
        "ization automatically.");
            this.syncNotifyCheckbox.UseVisualStyleBackColor = true;
            // 
            // autostartCheckBox
            // 
            this.autostartCheckBox.AutoSize = true;
            this.autostartCheckBox.Location = new System.Drawing.Point(12, 79);
            this.autostartCheckBox.Name = "autostartCheckBox";
            this.autostartCheckBox.Size = new System.Drawing.Size(180, 17);
            this.autostartCheckBox.TabIndex = 7;
            this.autostartCheckBox.Text = "start with Windows (current user)";
            this.tooltip.SetToolTip(this.autostartCheckBox, "If checked a message will be shown when application start and stops file synchron" +
        "ization automatically.");
            this.autostartCheckBox.UseVisualStyleBackColor = true;
            // 
            // SyncOptionsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 138);
            this.Controls.Add(this.autostartCheckBox);
            this.Controls.Add(this.syncNotifyCheckbox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.syncPauseTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SyncOptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Synchronization options";
            ((System.ComponentModel.ISupportInitialize)(this.syncPauseTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown syncPauseTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox syncNotifyCheckbox;
        private System.Windows.Forms.CheckBox autostartCheckBox;
    }
}