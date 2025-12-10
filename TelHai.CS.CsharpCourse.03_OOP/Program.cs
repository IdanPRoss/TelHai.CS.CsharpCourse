namespace TelHai.CS.CsharpCourse._03_OOP
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


            PlayList l1 = new PlayList();
            Type type = l1.GetType();
            type.ToString();

            l1.Name = "CHOL_OUT"; // set
            var name_playlist = l1.Name; // get
            l1.Name += " Playlist";

            int count = l1.Count;

            PlayList l2 = new PlayList();
            l2.Name = "TECHNO";
            l2.Id = 1000;

            PlayList l3 = new PlayList("AMBIENT");

            //--Initializer
            PlayList l4 = new PlayList { Id=1001,Name="LOAZI" };

        }
    }
}
