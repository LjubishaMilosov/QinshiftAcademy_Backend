//Create three classes Rectangle, Circle, and Triangle that implement the Shape interface.
//Implement the GetArea() method for each of the three classes.

using Task_02.Domain.Interfaces;

namespace Task_02.Domain.Models
{
    public class Triangle : IShape
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public Triangle(double baseLength, double height)
        {
            Base = baseLength;
            Height = height;
        }

        public double GetArea()
        {
            return 0.5 * Base * Height;
        }
    }
}
