//Task 3:
//Write a program to create an abstract class Shape
//with abstract methods CalculateArea() and CalculatePerimeter().
//Create subclasses Circle and Triangle that extend the Shape class
//and implement the respective methods to calculate the area and perimeter of each shape.

namespace Task_03.Domain.Models
{
    public abstract class Shape
    {
        public double X { get; set; }
        public double Y { get; set; }

        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }
}
