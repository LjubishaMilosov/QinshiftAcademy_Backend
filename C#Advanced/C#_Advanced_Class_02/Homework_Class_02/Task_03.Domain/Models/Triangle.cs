//Create subclasses Circle and Triangle that extend the Shape class
//and implement the respective methods to calculate the area and perimeter of each shape.

namespace Task_03.Domain.Models
{
    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        //In C#, base is a reserved keyword used to refer to the base class of the current class.
        //Since it is a keyword, we cannot use it directly as an identifier (e.g., a variable or parameter name)
        //unless we escape it using the @ symbol.
        public Triangle(double @base, double height, double sideA, double sideB, double sideC)
        {
            Base = @base;
            Height = height;
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }
        public override double CalculateArea()
        {
            return 0.5 * Base * Height;
        }

        public override double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }
    }
}
