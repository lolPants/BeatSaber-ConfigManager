using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigManager.Misc
{
    class Logger
    {
        public static void Log(string s)
        {
            Console.WriteLine("[Config Manager]: " + s);
        }
    }
}
