using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelHai.CS.CsharpCourse._01_Practice.Logging
{
    public enum LogLevel
    {
        Debug = 0,
        Info = 1,
        Warn = 2,
        Exception = 3
    }

    public class Logger
    {
        public void Log(string text)
        {
            string formattedTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            Console.WriteLine(text + ":" + formattedTime);
        }

        public void Log(string text, LogLevel level)
        {
            string formattedTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string logTxt = $"{text} : {level} : {formattedTime}";
            Console.WriteLine(logTxt);
        }
    }
}
