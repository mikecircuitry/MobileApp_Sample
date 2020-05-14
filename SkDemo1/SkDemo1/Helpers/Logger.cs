using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SkDemo1.Helpers
{
    public class Logger
    {
        public static void Log(string header, string message, bool wantBanner = true)
        {
            if (wantBanner)
                Debug.WriteLine($"-------------------------------- {header.ToUpper()} -----------------------------------");

            Debug.WriteLine(message);

            if (wantBanner)
                Debug.WriteLine("------------------------------------------------------------------------------");
        }

        public static void LogError(string header, Exception ex)
        {

            Debug.WriteLine($"-------------------------------- {header.ToUpper()} -----------------------------------");
            Debug.WriteLine(ex.Message.ToUpper());
            Debug.WriteLine("-----------------------------------------------------------------------------------------");
            Debug.WriteLine(ex.StackTrace);
            Debug.WriteLine("-----------------------------------------------------------------------------------------");
            Debug.WriteLine("-----------------------------------------------------------------------------------------");

        }
    }
}
