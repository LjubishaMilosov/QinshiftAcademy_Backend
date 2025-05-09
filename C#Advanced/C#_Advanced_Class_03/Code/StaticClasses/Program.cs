using StaticClasses.Domain;
using StaticClasses.Domain.Enums;
using StaticClasses.Domain.Models;

Order order = new Order(0, "First order", "Our first order", OrderStatusEnum.Created);
Console.WriteLine(order.Description); // we access the non-static member using the object (instance) of the class
order.PrintTitle(); // we access the non-static member using the object (instance) of the class

//order.IsValid(); // this will not work because IsValid is a static method and we are trying to access it using
                 // the object (instance) of the class
Console.WriteLine(Order.IsValid(order)); // we access the static member using the class name

Console.WriteLine("Welcome to our ordering app");
Console.WriteLine("Please choose the number of your user:");

OrdersDb.PrintUsers(); // we access the static member using the class name
string input = Console.ReadLine();