// 01 using for other Namespace
using TelHai.CS.CsharpCourse.Database;

namespace TelHai.CS.CsharpCourse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // 02 Use Only class name
            Db d = new Db();
            Console.ReadKey();
        }
    }
}
