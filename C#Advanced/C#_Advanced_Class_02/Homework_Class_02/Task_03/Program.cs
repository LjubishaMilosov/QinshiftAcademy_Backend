using Task_03.Domain.Models;

Shape circle = new Circle(5);
Console.WriteLine($"Circle Area: {circle.CalculateArea()}");
Console.WriteLine($"Circle Perimeter: {circle.CalculatePerimeter()}");

Shape triangle = new Triangle(3, 4, 3, 4, 5);
Console.WriteLine($"Triangle Area: {triangle.CalculateArea()}");
Console.WriteLine($"Triangle Perimeter: {triangle.CalculatePerimeter()}");
    