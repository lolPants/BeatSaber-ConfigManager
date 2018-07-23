using System;
using System.Collections.Generic;
using System.IO;
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
            ModName = _modName;
            FilePath = Path.Combine(DirPath, ModName + ".toml");

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
            _getter = new Getter(_settings);
            _setter = new Setter(_settings);

            Flush();
        }

        public void Flush() { Toml.WriteFile(_toml, FilePath); }

        public bool Get(string key, bool defaultValue, bool saveDefault = false)
        {
            bool value = _getter.GetValueInternal(key, defaultValue, saveDefault);
            Flush();
            return value;
        }
        public string Get(string key, string defaultValue, bool saveDefault = false)
        {
            string value = _getter.GetValueInternal(key, defaultValue, saveDefault);
            Flush();
            return value;
        }
        public int Get(string key, int defaultValue, bool saveDefault = false)
        {
            int value = _getter.GetValueInternal(key, defaultValue, saveDefault);
            Flush();
            return value;
        }
        public float Get(string key, float defaultValue, bool saveDefault = false)
        {
            float value = _getter.GetValueInternal(key, defaultValue, saveDefault);
            Flush();
            return value;
        }
        public double Get(string key, double defaultValue, bool saveDefault = false)
        {
            double value = _getter.GetValueInternal(key, defaultValue, saveDefault);
            Flush();
            return value;
        }
        public long Get(string key, long defaultValue, bool saveDefault = false)
        {
            long value = _getter.GetValueInternal(key, defaultValue, saveDefault);
            Flush();
            return value;
        }
        public IEnumerable<bool> Get(string key, IEnumerable<bool> defaultValue, bool saveDefault = false)
        {
            IEnumerable<bool> value = _getter.GetValueInternal(key, defaultValue, saveDefault);
            Flush();
            return value;
        }
        public IEnumerable<string> Get(string key, IEnumerable<string> defaultValue, bool saveDefault = false)
        {
            IEnumerable<string> value = _getter.GetValueInternal(key, defaultValue, saveDefault);
            Flush();
            return value;
        }
        public IEnumerable<int> Get(string key, IEnumerable<int> defaultValue, bool saveDefault = false)
        {
            IEnumerable<int> value = _getter.GetValueInternal(key, defaultValue, saveDefault);
            Flush();
            return value;
        }
        public IEnumerable<float> Get(string key, IEnumerable<float> defaultValue, bool saveDefault = false)
        {
            IEnumerable<float> value = _getter.GetValueInternal(key, defaultValue, saveDefault);
            Flush();
            return value;
        }
        public IEnumerable<double> Get(string key, IEnumerable<double> defaultValue, bool saveDefault = false)
        {
            IEnumerable<double> value = _getter.GetValueInternal(key, defaultValue, saveDefault);
            Flush();
            return value;
        }
        public IEnumerable<long> Get(string key, IEnumerable<long> defaultValue, bool saveDefault = false)
        {
            IEnumerable<long> value = _getter.GetValueInternal(key, defaultValue, saveDefault);
            Flush();
            return value;
        }

        public void Set(string key, bool value, string comment = "") { _setter.SetValueInternal(key, value, comment); Flush(); }
        public void Set(string key, string value, string comment = "") { _setter.SetValueInternal(key, value, comment); Flush(); }
        public void Set(string key, int value, string comment = "") { _setter.SetValueInternal(key, value, comment); Flush(); }
        public void Set(string key, float value, string comment = "") { _setter.SetValueInternal(key, value, comment); Flush(); }
        public void Set(string key, double value, string comment = "") { _setter.SetValueInternal(key, value, comment); Flush(); }
        public void Set(string key, long value, string comment = "") { _setter.SetValueInternal(key, value, comment); Flush(); }
        public void Set(string key, IEnumerable<bool> value, string comment = "") { _setter.SetValueInternal(key, value, comment); Flush(); }
        public void Set(string key, IEnumerable<string> value, string comment = "") { _setter.SetValueInternal(key, value, comment); Flush(); }
        public void Set(string key, IEnumerable<int> value, string comment = "") { _setter.SetValueInternal(key, value, comment); Flush(); }
        public void Set(string key, IEnumerable<float> value, string comment = "") { _setter.SetValueInternal(key, value, comment); Flush(); }
        public void Set(string key, IEnumerable<double> value, string comment = "") { _setter.SetValueInternal(key, value, comment); Flush(); }
        public void Set(string key, IEnumerable<long> value, string comment = "") { _setter.SetValueInternal(key, value, comment); Flush(); }
    }
}
