using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelHai.CS.CsharpCourse.Services.Logging;

namespace TelHai.CS.CsharpCourse._03_OOP
{
    public class PlayList
    {
        private List<string> songs;
        private string name;

        // Empty Ctor
        public PlayList():this("NO NAME")
        {
            Logger.Log("In Empty Ctor", LogLevel.Debug);
            songs = new List<string>();
        }

        public PlayList(string name)
        {
            Name = name; // set
            songs = new List<string>();
        }

        public string Name
        {
            get => name.ToUpper(); 
            set {
                if (string.IsNullOrEmpty(value))
                {
                    name = "<NO PLAYLIST NAME>";
                }
                name = value;
            }
        }

        /// <summary>
        /// Auto protorty 
        /// </summary>
        public int Id { get; set; }

        public int Count
        {
            get => songs.Count;
        }

        
    }
}
