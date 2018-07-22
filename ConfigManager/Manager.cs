using System;
using System.Collections.Generic;
using System.IO;
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

            Flush();
        }

        public void Flush()
        {
            Toml.WriteFile(_toml, FilePath);
        }
    }
}
