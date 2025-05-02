using AbstractClassesAndInterfaces.Domain.Interfaces;
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

//inherited from Person
firstDeveloper.Greet(); // we call the implementation from Person class
firstDeveloper.SengGift("Some gift"); // we call the implementation from Person class

firstDeveloper.Code(); // we call the implementation from Developer class because Developer implements IDeveloper

junior.Code();
// junior.TestingFeatures(); // ERROR -> Developer does not implement IQAEngineer interface

QAEngineer qaEngineer = new QAEngineer("Petko P", 30, "Some address", 1234567890,
    5, new List<string> { "C#", "Java" });

qaEngineer.Greet(); // we call the implementation from Person class
qaEngineer.SengGift("Some gift"); // we call the implementation from Person class

qaEngineer.TestingFeature("Some feature", DateTime.Now.AddDays(5)); // we call the implementation from QAEngineer class

qaEngineer.Code(); // we call the implementation from QAEngineer class because Developer implements IDeveloper


DevOpsEngineer devOpsEngineer = new DevOpsEngineer("Zlatko P", 30, "Some address4", 1234567890,
    true, false);

devOpsEngineer.Greet(); // we call the implementation from Person class

devOpsEngineer.Code();
// from IDevOpsEngineer interface
Console.WriteLine(devOpsEngineer.CheckInfrastructure(500));


Console.WriteLine("=====================BOXING AND UNBOXING=====================");

Person person = (Person)firstDeveloper; // BOXING

// Boxing all children to parent Person class so that they can fit in one List of the same class
List<Person> employees = new List<Person>() { devOpsEngineer, qaEngineer, firstDeveloper, junior };
foreach (var employee in employees)
{
    Console.WriteLine(employee.FullName + " " + employee.Age);
    //employee.PrintInfo();
    // Console.WriteLine(employee.GetProfessionalInfo());
}

// UNBOXING

