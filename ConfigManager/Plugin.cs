using System;
using ConfigManager.Misc;
using IllusionPlugin;

namespace ConfigManager
{
    public class Plugin : IPlugin
    {
        public string Name => "ConfigManager";
        public string Version => "0.1.0";

        public void OnApplicationStart()
        {
            Manager.EnsureConfigFile();
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
