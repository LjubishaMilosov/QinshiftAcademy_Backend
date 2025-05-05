//Create subclasses Circle and Triangle that extend the Shape class
//and implement the respective methods to calculate the area and perimeter of each shape.

namespace Task_03.Domain.Models
{
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double CalculatePerimeter()
        { 
             return 2 * Math.PI * Radius;
        }
    }
}
