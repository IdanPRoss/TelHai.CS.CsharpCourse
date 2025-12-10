using System;

namespace TelHai.CS.CsharpCourse._04_Polymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Drawing MyRectangle = new Rectangle();
            Drawing MySquare = new Square();


            // Creating Dinamic List
            List<Drawing> shapesList = new List<Drawing>
            {
                MyRectangle,
                MySquare
            };

            Console.WriteLine("\n--- Dynamic List Area Calculation ---");
            foreach (Drawing shape in shapesList)
                Console.WriteLine($"[{shape.Id}]  {shape.ToString()}");

            /// Creating Dictionary
            Dictionary<string, Drawing> shapesDict = new Dictionary<string, Drawing>
            {
                { "MyRectangle", MyRectangle },
                { "MySquare", MySquare }
            };

            Console.WriteLine("\n--- Dictionary Area Calculation ---");
            foreach (var shape in shapesDict)
                Console.WriteLine($"[{shape.Value.Id}] {shape.Key} - {shape.Value.ToString()}");
 

        }
    }
}
