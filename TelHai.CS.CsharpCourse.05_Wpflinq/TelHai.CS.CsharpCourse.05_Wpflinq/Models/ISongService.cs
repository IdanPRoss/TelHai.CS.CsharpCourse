using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelHai.CS.CsharpCourse._05_Wpflinq.Models
{
    internal interface ISongService
    {
        List<Song> GenerateSongs(int count);
    }
}
