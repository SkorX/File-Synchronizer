using File_Synchronizer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Synchronizer
{
    public partial class Popup : Form
    {
        //[DllImport("user32.dll")]
        //static extern bool SetForegroundWindow(IntPtr hWnd);

        public AddSynchronizingFoldersForm      addForm     { get; internal set; }
        public RemoveSychronizingFoldersForm    listForm    { get; internal set; }
        public SyncOptionsForm                  optsForm    { get; internal set; }
        public FailedSynchronizingFilesForm     failForm    { get; internal set; }

        public Popup(bool isAnotherInstance)
        {
            InitializeComponent();

            trayIcon.Icon = File_Synchronizer.Properties.Resources.tray;
            trayIcon.BalloonTipTitle = "File Synchronizer";

            if (isAnotherInstance)
            {
                trayIcon.BalloonTipText = "Another File Synchronizer is already running. This instance will shutdown.";
                trayIcon.ShowBalloonTip(3500);
                Thread.Sleep(3500);
                trayIcon.Visible = false;
                //this.Close();
                //this.Dispose();
                
                Thread shutdownThread = new Thread(delegate() { Application.Exit(); });
                shutdownThread.Start();
                return;
            }

            Point windowLocation = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width - 25, Screen.PrimaryScreen.Bounds.Height - this.Height - 50);
            this.Location = windowLocation;

            //DateTime x = new DateTime(); ;
            //x.ToString("yyyy,MM,dd,HH,mm,ss");

            //stopSyncLabel.Enabled = false;
        }

        internal bool IsWindows8OrHigher()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                if (Environment.OSVersion.Version.Major > 6)
                    return true;

                if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Major >= 2)
                    return true;
            }

            return false;
        }

        private void Popup_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Popup_Deactivate(object sender, EventArgs e)
        {
            if (pinCheckBox.Checked)
                return;

            this.Hide();

            if (IsWindows8OrHigher())
                return;

            trayIcon.BalloonTipText = "Application is alerady hidden";
            trayIcon.ShowBalloonTip(1000);
        }

        private void trayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new Point(
                    Screen.PrimaryScreen.WorkingArea.Width - this.Width - 15,
                    Screen.PrimaryScreen.WorkingArea.Height - this.Height - 15);

                this.Show();
                //SetForegroundWindow(this.Handle);
                this.BringToFront();
                this.Activate();
                this.TopMost = true;
            }
        }

        private void trayMenu_Opening(object sender, CancelEventArgs e)
        {
            int index = trayMenu.Items.IndexOfKey("showFailsToolStripMenuItem");

            if (Program.syncWorker.skippedFilesList.Count == 0)
                trayMenu.Items[index].Enabled = false;
            else
                trayMenu.Items[index].Enabled = true;
        }

        private void showAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Point windowLocation = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width - 25, Screen.PrimaryScreen.Bounds.Height - this.Height - 50);
            this.Location = windowLocation;

            this.Show();
            //SetForegroundWindow(this.Handle);
            this.BringToFront();
            this.Activate();
            this.TopMost = true;
        }

        private void closeAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Program.syncWorker.ForceStop();
            this.Close();
            this.Dispose();
            Application.Exit();
        }

        private void addSyncFoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addForm != null)
                return;

            if (listForm != null)
                return;

            addForm = new AddSynchronizingFoldersForm();

            addForm.FoldersChosen += delegate(object senderEv, FoldersChosenEventArgs arg)
            {
                string path = arg.SourceFolder;
                if (!Directory.Exists(path) || path[1] != ':')
                {
                    trayIcon.BalloonTipText = "Sync folders has not been added (wrong pathes)";
                    trayIcon.ShowBalloonTip(1000);
                    return;
                }

                path = arg.DestinationFolder;
                if (!Directory.Exists(path) || path[1] != ':')
                {
                    trayIcon.BalloonTipText = "Sync folders has not been added (wrong pathes)";
                    trayIcon.ShowBalloonTip(1000);
                    return;
                }

                Program.appSettings.AddSetting("syncFolders", arg.SourceFolder + "|" + arg.DestinationFolder + "|" + arg.IsTwoWay);
                trayIcon.BalloonTipText = "Sync folders has been added successfully";
                trayIcon.ShowBalloonTip(1000);

                addForm.Dispose();
                addForm = null;
            };

            addForm.FormClosed += delegate(object senderEv, FormClosedEventArgs arg)
            {
                addForm.Dispose();
                addForm = null;
            };

            addForm.Show();
        }

        private void listSyncFoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listForm != null)
                return; 
            
            if (addForm != null)
                return;

            listForm = new RemoveSychronizingFoldersForm(this);

            listForm.FormClosed += delegate(object senderEv, FormClosedEventArgs arg)
            {
                listForm.Dispose();
                listForm = null;
            };

            listForm.Show();
        }


        private void syncOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (optsForm != null)
                return;

            optsForm = new SyncOptionsForm();

            optsForm.FormClosed += delegate(object senderEv, FormClosedEventArgs arg)
            {
                optsForm.Dispose();
                optsForm = null;
            };

            optsForm.Show();
        }

        private void showFailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (failForm != null)
                return;

            failForm = new FailedSynchronizingFilesForm();

            failForm.FormClosed += delegate(object senderEv, FormClosedEventArgs arg)
            {
                failForm.Dispose();
                failForm = null;
            };

            failForm.Show();
        }

        private void syncLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.syncWorker.ForceSync();
        }

        private void stopSyncLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.syncWorker.PauseSync();
        }

        private void pinCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (pinCheckBox.Checked)
                pinCheckBox.BackColor = SystemColors.ActiveCaption;
            else
                pinCheckBox.BackColor = SystemColors.Control;
        }
    }
}
