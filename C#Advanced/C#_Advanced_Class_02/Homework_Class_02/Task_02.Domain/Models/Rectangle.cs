//Create three classes Rectangle, Circle, and Triangle that implement the Shape interface.
//Implement the GetArea() method for each of the three classes.

using Task_02.Domain.Interfaces;

namespace Task_02.Domain.Models
{
    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
        public double GetArea()
        {
            return Width * Height;
        }

    }
}
