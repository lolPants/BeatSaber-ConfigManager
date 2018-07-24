using System;
using System.Collections.Generic;
using System.IO;
using BeatSaberConfigManager.Misc;
using BeatSaberConfigManager.Interface;
using Nett;

namespace BeatSaberConfigManager
{
    public class KeyManager
    {
        // Config Directory
        public static string DirPath = Path.Combine(Environment.CurrentDirectory, "UserData");

        // Mod Name and Config Path
        public string KeyName { get; }

        // Data Values
        public TomlTable _parent;
        public TomlTable _settings;

        // Interfaces
        public Getter _getter;
        public Setter _setter;

        public KeyManager(string keyName)
        {
            // Set Mod Name
            KeyName = keyName.PathEscape();
        }

        public KeyManager(string keyName, TomlTable parent)
        {
            // Set Mod Name
            KeyName = keyName.PathEscape();

            // Assign TOML Structure
            _parent = parent;
            try
            {
                // Try to get table from existing structure
                _settings = _parent.Get<TomlTable>(KeyName);
            }
            catch (KeyNotFoundException)
            {
                // Create new table if it doesn't exist
                _parent[KeyName] = Toml.Create();
                _settings = _parent.Get<TomlTable>(KeyName);
            }

            // Define Interfaces
            _getter = new Getter(_settings, Flush);
            _setter = new Setter(_settings, Flush);
        }

        public KeyManager(string keyName, TomlTable parent, Action flush)
        {
            // Set Mod Name
            KeyName = keyName.PathEscape();

            // Assign TOML Structure
            _parent = parent;
            try
            {
                // Try to get table from existing structure
                _settings = _parent.Get<TomlTable>(KeyName);
            }
            catch (KeyNotFoundException)
            {
                // Create new table if it doesn't exist
                _parent[KeyName] = Toml.Create();
                _settings = _parent.Get<TomlTable>(KeyName);
            }

            // Define Interfaces
            _getter = new Getter(_settings, flush);
            _setter = new Setter(_settings, flush);
        }

        /// <summary>
        /// Write current config state to disk
        /// </summary>
        public virtual void Flush() { }

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
