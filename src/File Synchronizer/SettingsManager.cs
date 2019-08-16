using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Synchronizer
{
    class SettingsManager
    {
        private string _appName;
        /// <summary>
        /// Application name chosen when object was created.
        /// </summary>
        public string AppName 
        {
            get { 
                return _appName;
            }
        }

        private string _fileName;
        /// <summary>
        /// Setting filename chosen when object was created.
        /// </summary>
        public string SettingFile
        {
            get
            {
                return _fileName;
            }
        }

        private bool _autosave;
        /// <summary>
        /// Autosave state set when object was created
        /// </summary>
        public bool Autosave 
        {
            get {
                return _autosave;
            }
        }

        private Dictionary<string, List<string>> _settings = new Dictionary<string, List<string>>();
        

        /// <summary>
        /// Creates new SettigsManager (do not saves data automatically).
        /// </summary>
        /// <param name="appName">Identifier for your application.</param>
        /// <param name="settingFile">Name of the file that will contain settings.</param>
        public SettingsManager(string appName, string settingFile)
            : this(appName, settingFile, false)
        { }
        
        /// <summary>
        /// Creates new SettigsManager.
        /// </summary>
        /// <param name="appName">Identifier for your application.</param>
        /// <param name="settingFile">Name of the file that will contain settings.</param>
        /// <param name="autosave">Specifies if file should be updated on any changes. If true Save() method will stop work.</param>
        public SettingsManager(string appName, string settingFile, bool autosave)
        {
            if (appName == String.Empty)
                throw new ArgumentException("Application name cannot be an empty string");
            if (settingFile == String.Empty)
                throw new ArgumentException("Setting file name cannot be an empty string");

            _appName = appName;
            _fileName = settingFile;
            _autosave = autosave;

            string appPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + appName;

            bool isPresent = Directory.Exists(appPath);
            if (!isPresent)
                Directory.CreateDirectory(appPath);

            if (File.Exists(appPath + "\\" + settingFile + ".settings"))
            {
                foreach (string line in File.ReadAllLines(appPath + "\\" + settingFile + ".settings"))
                {
                    string[] data = line.Split(new string[] { "=" }, 2, StringSplitOptions.None);
                    if (data.Length == 2 && data[0].Length > 0)
                        if (!_settings.ContainsKey(data[0]))
                            _settings.Add(data[0], new List<string> { data[1] });
                        else
                        {
                            Predicate<string> search = delegate (string param) { return param == data[1]; };
                            if (_settings[data[0]].FindIndex(search) == -1)
                                _settings[data[0]].Add(data[1]);
                        }
                }
            }
            else if (File.Exists(appPath + "\\" + settingFile + ".settings~"))
            {
                foreach (string line in File.ReadAllLines(appPath + "\\" + settingFile + ".settings~"))
                {
                    string[] data = line.Split(new string[] { "=" }, 2, StringSplitOptions.None);
                    if (data.Length == 2 && data[0].Length > 0)
                        if (!_settings.ContainsKey(data[0]))
                            _settings.Add(data[0], new List<string> { data[1] });
                        else
                        {
                            Predicate<string> search = delegate (string param) { return param == data[1]; };
                            if (_settings[data[0]].FindIndex(search) == -1)
                                _settings[data[0]].Add(data[1]);
                        }
                }
            }
            else
            {
                (File.Create(appPath + "\\" + settingFile + ".settings")).Close();
                _settings = new Dictionary<string, List<string>>();
            }
        }

        /// <summary>
        /// Saves settings to a file (not required if autosave is active).
        /// </summary>
        public void Save()
        {
            if (_autosave)
                return;

            InsideSave();
        }

        private void InsideSave()
        {
            string appPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + _appName;
            List<string> fileData = new List<string>();

            foreach (KeyValuePair<string, List<string>> settElem in _settings)
            {
                foreach (string value in settElem.Value)
                {
                    fileData.Add(settElem.Key + "=" + value);
                }
            }

            File.WriteAllLines(appPath + "\\" + _fileName + ".settings~", fileData, Encoding.UTF8);                 //zapisujemy do pliku tymczasowego
            File.Copy(appPath + "\\" + _fileName + ".settings~", appPath + "\\" + _fileName + ".settings", true);   //kopiujemy plik tymczasowy jako normalny (zawsze jeden z plików będzie istniał - zabezpieczenie)
            File.Delete(appPath + "\\" + _fileName + ".settings~");                                                 //usuwamy plik tymczasowy
        }

        /// <summary>
        /// Returns list of values for specified setting (otherwise null is returned).
        /// </summary>
        /// <param name="name">Name of setting to return.</param>
        /// <returns>Returns list of values for specified setting. If setting does not exists null will returned.</returns>
        public List<string> GetSetting(string name)
        {
            if (!_settings.ContainsKey(name))
                return null;

            return _settings[name];
        }

        /// <summary>
        /// Returns first value for specified setting (otherwise null is returned)(for multiple values use getSetting(name);).
        /// </summary>
        /// <param name="name">Name of setting to return.</param>
        /// <returns>Returns first value for specified setting. If setting does not exists null will returned.</returns>
        public string GetFirstSetting(string name)
        {
            if (!_settings.ContainsKey(name))
                return null;

            return _settings[name][0];
        }

        /// <summary>
        /// Returns number of values under chosen setting (otherwise null is returned).
        /// </summary>
        /// <param name="name">Name of setting which values chould be counted.</param>
        /// <returns>Returnd number of values under chosen setting. If setting doesn't exists null is returned.</returns>
        public int? GetSettingCount(string name)
        {
            if (!_settings.ContainsKey(name))
                return null;

            return _settings[name].Count;
        }

        /// <summary>
        /// Adds new setting with specified name and value. If setting exists extends them by new value.
        /// </summary>
        /// <param name="name">Name of new setting to create or setting to extend</param>
        /// <param name="value">Value of setting.</param>
        public void AddSetting(string name, string value)
        {
            if (_settings.ContainsKey(name))
            {
                Predicate<string> search = delegate(string param) { return param == value; };
                int index = _settings[name].FindIndex(search);
                
                if (index == -1)
                    _settings[name].Add(value);
            }
            else
                _settings.Add(name, new List<string> { value });

            if (_autosave)
                InsideSave();
        }

        /// <summary>
        /// Removes whole setting with specified name (returns true if setting existed).
        /// </summary>
        /// <param name="name">Name of the setting to delete.</param>
        /// <returns>True if setting existed, otherwise false will be returned.</returns>
        public bool RemoveSetting(string name)
        {
            bool result = _settings.Remove(name);

            if (_autosave)
                InsideSave();

            return result;
        }

        /// <summary>
        /// Removes specified setting value from list.
        /// </summary>
        /// <param name="name">Name of setting to remove value from.</param>
        /// <param name="value">Value to remove form setting.</param>
        /// <returns>If specified value has been removed returns true. Otherwise false.</returns>
        public bool RemoveSettingValue(string name, string value)
        {
            if (!_settings.ContainsKey(name))
                return false;

            bool status = _settings[name].Remove(value);

            if (_settings[name].Count == 0)
                _settings.Remove(name);

            if (_autosave)
                InsideSave();
            
            return status;
        }

        /// <summary>
        /// Updates value under existing setting (returns false if setting or value doesn't exists).
        /// </summary>
        /// <param name="name">Name of the setting to update.</param>
        /// <param name="oldValue">Value to update on list.</param>
        /// <param name="newValue">New value to set in place of old one.</param>
        /// <returns>Returns true if setting and oldValue has been found and replaced. Otherwise false.</returns>
        public bool UpdateSetting(string name, string oldValue, string newValue)
        {
            if (!_settings.ContainsKey(name))
                return false;

            Predicate<string> search = delegate(string test) { return test == oldValue; };
            int index = _settings[name].FindIndex(search);
            if (index == -1)
                return false;

            _settings[name][index] = newValue;

            if (_autosave)
                InsideSave();

            return true;
        }

        /// <summary>
        /// Updates specified setting like totaly new one. Setting will contain only newValue on list.
        /// </summary>
        /// <param name="name">Name of setting to update.</param>
        /// <param name="newValue">Value that will be assigned to setting.</param>
        /// <returns>Returns true if setting was updated. Otherwise false.</returns>
        public bool UpdateSetting(string name, string newValue)
        {
            if (!_settings.ContainsKey(name))
                return false;

            _settings[name] = new List<string> { newValue };

            if (_autosave)
                InsideSave();

            return true;
        }
    }
}
