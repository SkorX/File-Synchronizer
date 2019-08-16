using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Synchronizer
{
    public partial class SyncOptionsForm : Form
    {
        private static string registryRunName = "FileSynchronizer";

        private readonly Microsoft.Win32.RegistryKey runKey;

        public SyncOptionsForm()
        {
            InitializeComponent();

            runKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
            autostartCheckBox.Checked = (runKey.GetValue(registryRunName) != null);

            try
            {
                syncPauseTime.Value = Int32.Parse(Program.appSettings.GetFirstSetting("betweenSyncTime"));
            }
            catch (Exception)
            {
                syncPauseTime.Value = 60;
                Program.appSettings.RemoveSetting("betweenSyncTime");
                Program.appSettings.AddSetting("betweenSyncTime", "60");
            }

            try
            {
                syncNotifyCheckbox.Checked = Boolean.Parse(Program.appSettings.GetFirstSetting("syncNotify"));
            }
            catch (Exception)
            {
                syncNotifyCheckbox.Checked = false;
                Program.appSettings.RemoveSetting("syncNotify");
                Program.appSettings.AddSetting("syncNotify", "False");
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Program.appSettings.UpdateSetting("betweenSyncTime", syncPauseTime.Value.ToString());
            Program.appSettings.UpdateSetting("syncNotify", syncNotifyCheckbox.Checked.ToString());

            //saving autostart value
            Microsoft.Win32.RegistryKey runKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);

            if (autostartCheckBox.Checked)
            {
                string appDataPath    = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FileSynchronizer");
                string executablePath = Path.Combine(appDataPath, "FileSynchronizer.exe");

                if (!Directory.Exists(appDataPath))
                    Directory.CreateDirectory(appDataPath);

                if (!File.Exists(executablePath))
                    File.Copy(Assembly.GetEntryAssembly().Location, executablePath);
                
                if (runKey.GetValue(registryRunName) == null)
                    runKey.SetValue(registryRunName, string.Format("\"{0}\"", executablePath), Microsoft.Win32.RegistryValueKind.String);
            }
            else
            {
                if (runKey.GetValue(registryRunName) != null)
                    runKey.DeleteValue(registryRunName);
            }

            Program.popupForm.trayIcon.BalloonTipText = "Settings has been updated";
            Program.popupForm.trayIcon.ShowBalloonTip(1000);

            this.Close();
        }
    }
}
