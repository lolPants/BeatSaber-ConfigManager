using System;
using BeatSaberConfigManager.Misc;
using IllusionPlugin;

namespace BeatSaberConfigManager
{
    public class Plugin : IPlugin
    {
        public string Name => "ConfigManager";
        public string Version => "0.2.0";

        public void OnApplicationStart()
        {
            ConfigManager.EnsureDirectory();
            Logger.Log("Loaded!");
        }

        public void OnApplicationQuit()
        {
        }

        public void OnLevelWasLoaded(int level)
        {
        }

        public void OnLevelWasInitialized(int level)
        {
        }

        public void OnUpdate()
        {
        }

        public void OnFixedUpdate()
        {
        }
    }
}
