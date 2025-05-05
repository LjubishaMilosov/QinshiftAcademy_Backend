
using Task_02.Domain.Models;


 Rectangle rectangle = new Rectangle(5, 10);
Circle circle = new Circle(7);
Triangle triangle = new Triangle(6, 8);

//var rectangle = new Rectangle(5, 10); //the type is clearly defined, it avoids redundancy and makes the code cleaner
//var circle = new Circle(7);
//var triangle = new Triangle(6, 8);

Console.WriteLine($"Rectangle Area: {rectangle.GetArea()}");
Console.WriteLine($"Circle Area: {circle.GetArea()}");
Console.WriteLine($"Triangle Area: {triangle.GetArea()}");