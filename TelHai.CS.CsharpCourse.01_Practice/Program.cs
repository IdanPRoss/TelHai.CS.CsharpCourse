using TelHai.CS.CsharpCourse._01_Practice.Logging;

namespace TelHai.CS.CsharpCourse._01_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName = Environment.UserName;
            string machineName = Environment.MachineName;
            string osVersion = Environment.OSVersion.ToString();

            Console.WriteLine($"Current User: {userName}");
            Console.WriteLine($"Machine Name: {machineName}");
            Console.WriteLine($"Operating System: {osVersion}");
            Console.WriteLine("-----");

            Console.WriteLine("Hello World!");
            Logger logger = new Logger();
            for (int i = 0; i < 1000; i++)
            {
                if (i%5 == 0)
                {
                    logger.Log("Running Main" + i, LogLevel.Debug);
                    continue;
                }
                logger.Log("Running Main" + i);
            }
         }
    }
}
