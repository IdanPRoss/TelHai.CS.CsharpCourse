using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelHai.CS.CsharpCourse._04_Polymorphism
{
    public class Rectangle : Drawing
    {
        public double Hieght { get; set; }
        public double Width { get; set; }
        public Rectangle() : base()
        {
            Hieght = 5.3;
            Width = 3.4;
        }

        public override double Area()
        {
            return Hieght * Width;
        }

        public override string ToString()
        {
            return $"The shape is Rectangle with Area: {Area()}";
        }
    }
}
