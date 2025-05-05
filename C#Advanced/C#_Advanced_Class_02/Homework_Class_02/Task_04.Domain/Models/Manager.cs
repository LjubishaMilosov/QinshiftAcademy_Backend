//Create subclasses Manager and Programmer that extend the Employee class
//and implement the respective methods to calculate salary and display information for each role.

namespace Task_04.Domain.Models
{
    public class Manager : Employee
    {
        public double Bonus { get; set; }
        public Manager(int id, string name, double baseSalary, double bonus)
            : base(id, name, baseSalary)
        {
            Bonus = bonus;
        }
        public override double CalculateSalary()
        {
            return BaseSalary + Bonus;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Manager Id: {Id}, Name: {Name}, Salary: {CalculateSalary()}");
        }
    }
   
}
