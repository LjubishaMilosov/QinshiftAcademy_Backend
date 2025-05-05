//Write a program to create an abstract class Employee with abstract methods CalculateSalary() and DisplayInfo().
//Create subclasses Manager and Programmer that extend the Employee class
//and implement the respective methods to calculate salary and display information for each role.

namespace Task_04.Domain.Models
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double BaseSalary { get; set; }

        public Employee(int id, string name, double baseSalary)
        {
            Id = id;
            Name = name;
            BaseSalary = baseSalary;
        }
        public abstract double CalculateSalary();
        public abstract void DisplayInfo();
    }
}
