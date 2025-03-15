using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Exercise_01;

//EXERCISE 1
//● Create a class Human
//● Add properties: FirstName, LastName, Age
//● Create a method called GetPersonStats that returns the
//full name of the human as well as their age
//● Create an object human by asking the user to fill the
//required information
//● Call the GetPersonStats method and print the result in
//the console after the object is created

Console.WriteLine("Please enter your first name:");
string firstName = Console.ReadLine();

Console.WriteLine("Please enter your last name:");
string lastName = Console.ReadLine();

Console.WriteLine("Please enter your age:");
int age = int.Parse(Console.ReadLine());

Human human = new Human(firstName, lastName, age);
Console.WriteLine(human.GetPersonStats());