using System;

namespace BeatSaberConfigManager.Misc
{
    class Logger
    {
        public static void Log(string s)
        {
            Console.WriteLine("[Config Manager] " + s);
        }
    }
}
