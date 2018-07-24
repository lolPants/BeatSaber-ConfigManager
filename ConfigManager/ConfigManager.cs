using System;
using System.Collections.Generic;
using System.IO;
using BeatSaberConfigManager.Interface;
using Nett;

namespace BeatSaberConfigManager
{
    public class ConfigManager : KeyManager
    {
        // File Path
        public string FilePath { get; }

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

        public ConfigManager(string _modName) : base(_modName)
        {
            // Create File Path
            FilePath = Path.Combine(DirPath, KeyName + ".toml");

            // Ensure the File Exists 
            using (StreamWriter w = File.AppendText(FilePath))
            {
                // Do nothing and make sure the file exists first 
            }
            
            // Assign TOML Structure
            _parent = Toml.ReadFile(FilePath);
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

            Flush();
        }

        /// <summary>
        /// Write current config state to disk
        /// </summary>
        public override void Flush() => Toml.WriteFile(_parent, FilePath);

        /// <summary>
        /// Create a manager for a child key in the same file.
        /// </summary>
        /// <param name="childName">Name of the child key.</param>
        /// <returns>A KeyManager instance.</returns>
        public KeyManager CreateSubKey (string childName) => new KeyManager(KeyName, _settings, Flush);
    }
}
