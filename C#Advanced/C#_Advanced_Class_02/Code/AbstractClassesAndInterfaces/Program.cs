using AbstractClassesAndInterfaces.Domain.Models;

Developer firstDeveloper = new Developer("Petko P", 30, "Some address", 1234567890,
    "Qinshift", 5, new List<string> { "C#", "Java" });

firstDeveloper.PrintInfo(); // we call the implementation from Person class
Console.WriteLine(firstDeveloper.GetProfessionalInfo()); // we call the implementation from Developer class

//Person person = new Person(); //ERROR -> abstract class cannot be instantiated

JuniorDeveloper junior = new JuniorDeveloper("Nikola P", 30, "Some address2", 1234567890,
    "Qinshift", 5, null, false);
Console.WriteLine(junior.GetProfessionalInfo()); // we call the implementation from Developer class
junior.PrintInfo(); // we call the implementation from Person class