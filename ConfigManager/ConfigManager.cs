using System;
using System.Collections.Generic;
using System.IO;
using BeatSaberConfigManager.Misc;
using BeatSaberConfigManager.Interface;
using Nett;

namespace BeatSaberConfigManager
{
    public class ConfigManager
    {
        // Config Directory
        static string DirPath = Path.Combine(Environment.CurrentDirectory, "UserData");

        // Mod Name and Config Path
        public string ModName { get; }
        public string FilePath { get; }

        // Data Values
        TomlTable _toml;
        TomlTable _settings;

        // Interfaces
        private Getter _getter;
        private Setter _setter;

        /// <summary>
        /// Create the UserData directory if it doesn't exist
        /// </summary>
        public static void EnsureDirectory()
        {
            // Ensure the UserData Directory Exists
            if (!Directory.Exists(DirPath))
            {
                Directory.CreateDirectory(DirPath);
            }
        }

        public ConfigManager(string _modName)
        {
            // Set Mod Name
            ModName = _modName.PathEscape();
            FilePath = Path.Combine(DirPath, ModName + ".toml");

            // Ensure the File Exists
            using (StreamWriter w = File.AppendText(FilePath))
            {
                // Do nothing and make sure the file exists first
            }

            // Read in current config and add a new table for self.
            _toml = Toml.ReadFile(FilePath);

            try
            {
                // Load from file if table exists
                _settings = _toml.Get<TomlTable>(ModName);
            }
            catch (KeyNotFoundException)
            {
                // Create new table if not
                _toml[ModName] = Toml.Create();
                _settings = _toml.Get<TomlTable>(ModName);
            }

            // Define Interfaces
            _getter = new Getter(_settings, Flush);
            _setter = new Setter(_settings, Flush);

            Flush();
        }

        /// <summary>
        /// Write current config state to disk
        /// </summary>
        public void Flush() => Toml.WriteFile(_toml, FilePath);

        public bool Get(string key, bool defaultValue, bool saveDefault = false) => _getter.GetValueInternal(key, defaultValue, saveDefault);
        public string Get(string key, string defaultValue, bool saveDefault = false) => _getter.GetValueInternal(key, defaultValue, saveDefault);
        public int Get(string key, int defaultValue, bool saveDefault = false) => _getter.GetValueInternal(key, defaultValue, saveDefault);
        public float Get(string key, float defaultValue, bool saveDefault = false) => _getter.GetValueInternal(key, defaultValue, saveDefault);
        public List<bool> Get(string key, List<bool> defaultValue, bool saveDefault = false) => _getter.GetValueInternal(key, defaultValue, saveDefault);
        public List<string> Get(string key, List<string> defaultValue, bool saveDefault = false) => _getter.GetValueInternal(key, defaultValue, saveDefault);
        public List<int> Get(string key, List<int> defaultValue, bool saveDefault = false) => _getter.GetValueInternal(key, defaultValue, saveDefault);
        public List<float> Get(string key, List<float> defaultValue, bool saveDefault = false) => _getter.GetValueInternal(key, defaultValue, saveDefault);

        public void Set(string key, bool value, string comment = "") => _setter.SetValueInternal(key, value, comment);
        public void Set(string key, string value, string comment = "") => _setter.SetValueInternal(key, value, comment);
        public void Set(string key, int value, string comment = "") => _setter.SetValueInternal(key, value, comment);
        public void Set(string key, float value, string comment = "") => _setter.SetValueInternal(key, value, comment);
        public void Set(string key, IEnumerable<bool> value, string comment = "") => _setter.SetValueInternal(key, value, comment);
        public void Set(string key, IEnumerable<string> value, string comment = "") => _setter.SetValueInternal(key, value, comment);
        public void Set(string key, IEnumerable<int> value, string comment = "") => _setter.SetValueInternal(key, value, comment);
        public void Set(string key, IEnumerable<float> value, string comment = "") => _setter.SetValueInternal(key, value, comment);
    }
}
