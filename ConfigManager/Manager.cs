using System;
using System.Collections.Generic;
using System.IO;
using ConfigManager.Interface;
using Nett;

namespace ConfigManager
{
    class Manager
    {
        // Config Location
        static string DirPath = Path.Combine(Environment.CurrentDirectory, "UserData");
        static string FilePath = Path.Combine(DirPath, "ModConfig.toml");

        public string ModName { get; }

        // Data Values
        TomlTable _toml;
        TomlTable _settings;

        // Interfaces
        private Setter _setter;

        public static void EnsureConfigFile()
        {
            // Ensure the UserData Directory Exists
            if (!Directory.Exists(DirPath))
            {
                Directory.CreateDirectory(DirPath);
            }

            // Ensure the File Exists
            using (StreamWriter w = File.AppendText(FilePath))
            {
                // Do nothing and make sure the file exists first
            }
        }

        public Manager(string _modName)
        {
            // Set Mod Name
            ModName = _modName;

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
            _setter = new Setter(_settings);

            Flush();
        }

        public void Flush() { Toml.WriteFile(_toml, FilePath);  }

        // So...
        // To anyone looking at the next lines of code: I'm sorry.
        // The TOML library I'm using DOESN'T HAVE GENERICS
        // Well it does. BUT ONLY PRIVATE METHODS.
        // I'm also probably using it wrong.
        // C# is not my strongest language.

        // Handle all the fucking data types.
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
