using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelHai.CS.CsharpCourse._05_Wpflinq.Models
{
    public class Song
    {
        public Guid Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public double Duration { get; set; }

        // Empty Ctor
        public Song()
        {
            this.Id = Guid.NewGuid();
        }
        public override string ToString()
        {
            return $"Title: {Title} | Artist: {Artist} | Duration: {Duration} mins | [ID: {Id}]";
        }
    }
}
