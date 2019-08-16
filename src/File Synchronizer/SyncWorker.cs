using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Synchronizer
{
    class SyncWorker
    {
        private bool _shouldStop = false;
        private bool _forceSync = false;
        private bool _stopSync = false;
        private DateTime _lastSync;

        private Int64 filesSynced;
        private Int64 filesTotal;
        private Int64 filesSkipped;

        //private SettingsManager _fileList;
        internal List<string> skippedFilesList { get; private set; }

        //some constants
        private static string DeletedFilesDirectory = ".deleted";


        public void Work()
        {
            //_fileList = new SettingsManager("FileSynchronizer", "File_List", false);
            skippedFilesList = new List<string>();

            //Geting last synchronization time
            string lastSyncString = Program.appSettings.GetFirstSetting("lastSync");
            if (lastSyncString == null)
            {
                _lastSync = new DateTime(1990, 08, 24);
            }
            else
            {
                string[] lastSyncElems = lastSyncString.Split(new char[] { ',' });
                if (lastSyncElems.Length != 6)
                {
                    _lastSync = new DateTime(1970, 00, 00);
                }
                else
                {
                    try
                    {
                        _lastSync = new DateTime(Int32.Parse(lastSyncElems[0]), Int32.Parse(lastSyncElems[1]), Int32.Parse(lastSyncElems[2]), Int32.Parse(lastSyncElems[3]), Int32.Parse(lastSyncElems[4]), Int32.Parse(lastSyncElems[5]));
                    }
                    catch (Exception)
                    {
                        _lastSync = new DateTime(2001, 09, 11);
                    }
                }
            }

            //Here goes part with synchronizations
            while (!_shouldStop)
            {
                _forceSync = false;
                while (true)
                {
                    if (_shouldStop || _forceSync)
                    {
                        _forceSync = false;
                        break;
                    }

                    TimeSpan timeSinceLastSync = DateTime.Now - _lastSync;
                    try
                    {
                        if (timeSinceLastSync.TotalMinutes >= Int32.Parse(Program.appSettings.GetFirstSetting("betweenSyncTime")))
                            break;
                    }
                    catch (Exception)
                    {
                        break;
                    }

                    try
                    {
                        Program.popupForm.Invoke(new Action(() => Program.popupForm.underTitleLabel.Text = timeSinceLastSync.ToString("d\\d\\ hh\\:mm\\:ss") + " ago"));
                    }
                    catch (Exception) { }

                    Thread.Sleep(100);
                }

                if (_shouldStop)
                    break;

                try
                {
                    Program.popupForm.Invoke(new Action(() => Program.popupForm.underTitleLabel.Text = "synchronization in progress"));
                }
                catch (Exception) { }
                filesSynced = 0;
                filesTotal = 0;
                filesSkipped = 0;

                skippedFilesList.Clear();
                SkippedListUpdated();

                var foldersSetting = Program.appSettings.GetSetting("syncFolders");
                List<string> syncFolders = (foldersSetting != null) ? foldersSetting.ToList() : null;
                if (syncFolders != null && syncFolders.Any())
                {
                    try
                    {
                        Program.popupForm.Invoke(new Action(() => Program.popupForm.trayIcon.Icon = Properties.Resources.trayWorking));
                        if (Boolean.Parse(Program.appSettings.GetFirstSetting("syncNotify")))
                        {
                            Program.popupForm.Invoke(new Action(() => Program.popupForm.trayIcon.BalloonTipText = "Synchronization has started"));
                            Program.popupForm.Invoke(new Action(() => Program.popupForm.trayIcon.ShowBalloonTip(1000)));
                        }
                    }
                    catch (Exception) { }

                    foreach (string folderPair in syncFolders)
                    {
                        try
                        {
                            Program.popupForm.Invoke(new Action(() => Program.popupForm.syncLabel.Enabled = false));
                            Program.popupForm.Invoke(new Action(() => Program.popupForm.stopSyncLabel.Enabled = true));
                        }
                        catch (Exception) { }

                        string[] foldersData = folderPair.Split(new char[] { '|' }, 3);
                        if (foldersData.Length != 3)
                        {
                            Program.appSettings.RemoveSettingValue("syncFolders", folderPair);
                            continue;
                        }

                        if (!Directory.Exists(foldersData[0]))
                        {
                            Program.popupForm.Invoke(new Action(() => Program.popupForm.trayIcon.BalloonTipText = "Source folder not found:\n" + foldersData[0]));
                            Program.popupForm.Invoke(new Action(() => Program.popupForm.trayIcon.ShowBalloonTip(1000)));
                            
                            //Program.appSettings.RemoveSettingValue("syncFolders", folderPair);
                            continue;
                        }

                        if (!Directory.Exists(foldersData[1]))
                        {
                            try
                            {
                                Directory.CreateDirectory(foldersData[1]);
                            }
                            catch (Exception)
                            {
                                Program.popupForm.Invoke(new Action(() => Program.popupForm.trayIcon.BalloonTipText = "Destination folder is missing and unable to create:\n" + foldersData[1]));
                                Program.popupForm.Invoke(new Action(() => Program.popupForm.trayIcon.ShowBalloonTip(1000)));
                                continue;
                            }
                        }

                        //defining two-way sync
                        bool isTwoWay;
                        Boolean.TryParse(foldersData[2], out isTwoWay);

                        //SYNCHRONIZATION
                        SyncFolders(foldersData[0], foldersData[1], isTwoWay, Path.GetDirectoryName(foldersData[0]));

                        try
                        {
                            Program.popupForm.Invoke(new Action(() => Program.popupForm.syncLabel.Enabled = true));
                            Program.popupForm.Invoke(new Action(() => Program.popupForm.stopSyncLabel.Enabled = false));
                        }
                        catch (Exception) { }

                        if (_stopSync)
                            break;
                    }

                    if (_stopSync)
                    {
                        _stopSync = false;
                        try
                        {
                            Program.popupForm.Invoke(new Action(() => Program.popupForm.trayIcon.BalloonTipText = "Synchronization has been stopped"));
                            Program.popupForm.Invoke(new Action(() => Program.popupForm.trayIcon.ShowBalloonTip(1000)));
                        }
                        catch (Exception) { }
                    }
                    else
                    {
                        try
                        {
                            if (Boolean.Parse(Program.appSettings.GetFirstSetting("syncNotify")))
                            {
                                Program.popupForm.Invoke(new Action(() => Program.popupForm.trayIcon.BalloonTipText = "Synchronization has ended"));
                                Program.popupForm.Invoke(new Action(() => Program.popupForm.trayIcon.ShowBalloonTip(1000)));
                            }
                        }
                        catch (Exception) { }
                    }

                    try
                    {
                        Program.popupForm.Invoke(new Action(() => Program.popupForm.trayIcon.Icon = Properties.Resources.tray));
                    }
                    catch (Exception) { }
                }

                //_fileList.Save();
                _lastSync = DateTime.Now;
                lastSyncString = _lastSync.ToString("yyyy,MM,dd,HH,mm,ss");
                if (Program.appSettings.GetSetting("lastSync") == null)
                    Program.appSettings.AddSetting("lastSync", lastSyncString);
                else
                    Program.appSettings.UpdateSetting("lastSync", lastSyncString);
            }

            try
            {
                Program.popupForm.Invoke(new Action(() => Program.popupForm.trayIcon.BalloonTipText = "Synchronization task has been stopped (to synchronize restart required)"));
                Program.popupForm.Invoke(new Action(() => Program.popupForm.trayIcon.ShowBalloonTip(1000)));
            }
            catch (Exception) { }
        }

        #region Synchronization

        private void SyncFolders(string src, string dest, bool twoWay, string topLevelSrc)
        {
            string relativeDir = src.Replace(topLevelSrc, "").TrimStart('\\');
            try
            {
                Program.popupForm.Invoke(new Action(() => Program.popupForm.syncFilesDir.Text = "Dir:  " + relativeDir));
            }
            catch (Exception) { }

            List<string> syncFileList = new List<string>();

            syncFileList.AddRange(Directory.EnumerateFiles(src).Select(i => i.Replace(src, "").TrimStart('\\')));
            if (twoWay)
                syncFileList.AddRange(Directory.EnumerateFiles(dest).Select(i => i.Replace(dest, "").TrimStart('\\')));

            foreach (string relativePath in syncFileList.Distinct())
            {
                filesTotal++;
                
                SynchronizeFiles(src, dest, relativePath, twoWay, topLevelSrc);
                
                if (_shouldStop || _stopSync)
                    return;

                try
                {
                    string skipString = "";
                    if (filesSkipped != 0)
                        skipString = " (" + filesSkipped.ToString() + ")";

                    Program.popupForm.Invoke(new Action(() => Program.popupForm.syncFilesProgress.Text = "Progress: " + filesSynced.ToString() + skipString + " / " + filesTotal.ToString()));
                    //Program.popupForm.Invoke(new Action(() => Program.popupForm.syncFilesFile.Text = "File: " + relative.Replace("\\", "")));
                }
                catch (Exception) { }
            }
            
            if (!twoWay)
                ProceedMissingFiles(
                    src,
                    dest,
                    Directory.EnumerateFiles(dest).Select(i => i.Replace(dest, "").TrimStart('\\')).ToList(),
                    topLevelSrc);

            foreach (string sourceDirPath in Directory.EnumerateDirectories(src))
            {
                //do not synchronize deleted files folder
                if (Path.GetFileName(sourceDirPath).Equals(DeletedFilesDirectory, StringComparison.CurrentCultureIgnoreCase))
                    continue;

                string relative           = sourceDirPath.Replace(src, "").TrimStart('\\');
                string destinationDirPath = Path.Combine(dest, relative);

                if (Directory.Exists(destinationDirPath))
                {
                    SyncFolders(sourceDirPath, destinationDirPath, twoWay, topLevelSrc);
                }
                else
                {
                    try
                    {
                        Directory.CreateDirectory(destinationDirPath);
                    }
                    catch (Exception)
                    {
                        filesSkipped++;
                        skippedFilesList.Add("Directory: " + sourceDirPath.Replace(topLevelSrc, ""));
                        SkippedListUpdated();
                        continue;
                    }

                    SyncFolders(sourceDirPath, destinationDirPath, twoWay, topLevelSrc);
                }

                if (_shouldStop || _stopSync)
                    return;
            }
        }

        private void SynchronizeFiles(string srcDir, string destDir, string filePath, bool twoWay, string topLevelSrc)
        {
            MD5 md5 = MD5.Create();
            string sourceFilePath      = Path.Combine(srcDir,  filePath);
            string destinationFilePath = Path.Combine(destDir, filePath);

            try
            {
                Program.popupForm.Invoke(new Action(() => Program.popupForm.syncFilesFile.Text = "File: " + Path.GetFileName(filePath)));
            }
            catch (Exception) { }


            #region Two-Way sync code

            if (twoWay)
            {
                try
                {
                    if (File.Exists(sourceFilePath) && File.Exists(destinationFilePath))
                    {
                        byte[] sourceMD5, destinationMD5;

                        using (BufferedStream srcFile = new BufferedStream(File.OpenRead(sourceFilePath), 1048576 /*1MB*/))
                        {
                            sourceMD5 = md5.ComputeHash(srcFile);
                        }
                        using (BufferedStream dstFile = new BufferedStream(File.OpenRead(destinationFilePath), 1048576))
                        {
                            destinationMD5 = md5.ComputeHash(dstFile);
                        }

                        if (!sourceMD5.SequenceEqual(destinationMD5))
                        {
                            if (GetFileModIndicator(new FileInfo(sourceFilePath)) > GetFileModIndicator(new FileInfo(destinationFilePath)))
                                File.Copy(sourceFilePath, destinationFilePath, true);
                            else
                                File.Copy(destinationFilePath, sourceFilePath, true);

                            filesSynced++;
                        }
                    }
                    else if (File.Exists(sourceFilePath))
                    {
                        File.Copy(sourceFilePath, destinationFilePath);
                        filesSynced++;
                    }
                    else
                    {
                        File.Copy(destinationFilePath, sourceFilePath);
                        filesSynced++;
                    }
                }
                catch
                {
                    filesSkipped++;
                    skippedFilesList.Add(sourceFilePath.Replace(topLevelSrc, ""));
                    SkippedListUpdated();
                }

                return;
            }

            #endregion

            #region Owo-Way sync code

            if (File.Exists(destinationFilePath))
            {
                try
                {
                    byte[] sourceMD5, destinationMD5;

                    using (BufferedStream srcFile = new BufferedStream(File.OpenRead(sourceFilePath), 1048576 /*1MB*/))
                    {
                        sourceMD5 = md5.ComputeHash(srcFile);
                    }
                    using (BufferedStream dstFile = new BufferedStream(File.OpenRead(destinationFilePath), 1048576))
                    {
                        destinationMD5 = md5.ComputeHash(dstFile);
                    }

                    if (!sourceMD5.SequenceEqual(destinationMD5))
                    {
                        File.Copy(sourceFilePath, destinationFilePath, true);
                        filesSynced++;
                    }
                }
                catch (Exception)
                {
                    filesSkipped++;
                    skippedFilesList.Add(sourceFilePath.Replace(topLevelSrc, ""));
                    SkippedListUpdated();
                }
            }
            else
            {
                try
                {
                    File.Copy(sourceFilePath, destinationFilePath);
                    filesSynced++;
                }
                catch (Exception)
                {
                    filesSkipped++;
                    skippedFilesList.Add(sourceFilePath.Replace(topLevelSrc, ""));
                    SkippedListUpdated();
                }
            }

            #endregion
        }

        private void ProceedMissingFiles(string srcDir, string destDir, List<string> destFiles, string topLevelSrc)
        {
            foreach (string file in destFiles)
            {
                string srcFilePath = Path.Combine(srcDir, file);

                if (!File.Exists(srcFilePath))
                {
                    string destLocationFile = Path.Combine(destDir, file);
                    string deletedLocation = Path.Combine(Path.GetDirectoryName(destLocationFile), DeletedFilesDirectory, Path.GetFileName(destLocationFile));

                    if (!Directory.Exists(Path.GetDirectoryName(deletedLocation)))
                        Directory.CreateDirectory(Path.GetDirectoryName(deletedLocation));

                    if (File.Exists(deletedLocation))
                        File.Delete(deletedLocation);

                    File.Move(destLocationFile, deletedLocation);
                }
            }
        }

        private static DateTime GetFileModIndicator(FileInfo fInfo)
        {
            if (!fInfo.Exists)
                throw new ArgumentException("File info have to point to existing item");

            return (fInfo.CreationTimeUtc > fInfo.LastWriteTimeUtc) ?
                fInfo.CreationTimeUtc :
                fInfo.LastWriteTimeUtc;
        }

        #endregion 

        public void ForceStop()
        {
            _shouldStop = true;
        }

        public void ForceSync()
        {
            _forceSync = true;
        }

        public void PauseSync()
        {
            _stopSync = true;
        }

        public void SkippedListUpdated()
        {
            if (Program.popupForm == null)
                return;

            if (Program.popupForm.failForm == null)
                return;

            Program.popupForm.failForm.UpdateList();
        }
    }
}
