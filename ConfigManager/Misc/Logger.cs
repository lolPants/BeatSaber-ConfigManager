using System;

namespace BeatSaberConfigManager.Misc
{
    class Logger
    {
        public static void Log<T>(T s) => Console.WriteLine("[Config Manager] " + s.ToString());
    }
}
