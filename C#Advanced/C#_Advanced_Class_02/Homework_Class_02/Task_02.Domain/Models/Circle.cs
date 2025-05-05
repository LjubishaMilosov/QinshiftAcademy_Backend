//Create three classes Rectangle, Circle, and Triangle that implement the Shape interface.
//Implement the GetArea() method for each of the three classes.

using Task_02.Domain.Interfaces;

namespace Task_02.Domain.Models
{
    public class Circle : IShape
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
