namespace TelHai.CS.CsharpCourse._04_Polymorphism
{
    public class Drawing
    {
        public static int idCounter = 0;
        public int Id { get; }

        public Drawing() { Id = ++idCounter; }

        public virtual double Area()
        {
            return 0;
        }
    }
}