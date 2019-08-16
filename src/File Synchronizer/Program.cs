using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Synchronizer
{
    static class Program
    {
        internal static volatile SettingsManager appSettings = new SettingsManager("FileSynchronizer", "FileSynchronizer", true);
        internal static Popup       popupForm;
        internal static Thread      syncThread;
        internal static SyncWorker  syncWorker;
        private  static FileStream  lockFile;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool anotherInstanceRunning = false;
            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1)
            //if (Process.GetProcessesByName("File Synchronizer").Length > 1)
                anotherInstanceRunning = true;

            //secondary check: lock file (if file can't be opened application will shutdown)
            if (anotherInstanceRunning == false)
            {
                string appDataLockFilename = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + appSettings.AppName + "\\lock";
                if (File.Exists(appDataLockFilename))
                {
                    try
                    {
                        lockFile = File.Open(appDataLockFilename, FileMode.Open, FileAccess.ReadWrite);
                        lockFile.Lock(0, lockFile.Length);
                    }
                    catch (IOException)
                    {
                        anotherInstanceRunning = true;
                    }
                    
                }
                else
                {
                    lockFile = File.Open(appDataLockFilename, FileMode.CreateNew, FileAccess.ReadWrite);
                    lockFile.Lock(0, lockFile.Length);
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            popupForm = new Popup(anotherInstanceRunning);
            if (!anotherInstanceRunning)
            {
                syncWorker = new SyncWorker();
                syncThread = new Thread(syncWorker.Work);
                syncThread.Priority = ThreadPriority.Lowest;
                syncThread.IsBackground = true;
                syncThread.Start();
            }
            Application.Run(popupForm);
        }
    }
}
