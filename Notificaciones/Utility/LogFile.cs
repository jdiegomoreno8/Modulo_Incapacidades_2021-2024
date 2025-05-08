using System;
using System.IO;

namespace Notificaciones.Utility
{

    public static class LogFile
    {
        public static void Write(string txt)
        {
            using (StreamWriter w = File.AppendText("logNotificationsServices.txt"))
            {
                Log(txt, w);
                Console.WriteLine(w);
            }
        }
        

        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
        }

    }
    // The example creates a file named "log.txt" and writes the following lines to it,
    // or appends them to the existing "log.txt" file:

    // Log Entry : <current long time string> <current long date string>
    //  :
    //  :Test1
    // -------------------------------

    // Log Entry : <current long time string> <current long date string>
    //  :
    //  :Test2
    // -------------------------------

    // It then writes the contents of "log.txt" to the console.

}
