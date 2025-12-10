using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelHai.CS.CsharpCourse._04_Polymorphism
{
    public class Square : Drawing
    {
        public double Length { get; set; }

        public Square() : base() 
        {
            Length = 6;
        }

        public override double Area()
        {
            return Math.Pow(Length, 2);
        }

        public override string ToString()
        {
            return $"The shape is Square with Area: {Area()}";

        }
    }
}
