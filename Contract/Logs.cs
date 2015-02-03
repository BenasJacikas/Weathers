using System;
using System.IO;

namespace Contract
{
    class Logs
    {
        public static void Log(string logMessage, TextWriter w)
        {
            w.WriteLine(DateTime.Now.ToLongTimeString() + " " +
                DateTime.Now.ToLongDateString() + Environment.NewLine + logMessage);
        }
    }
}
