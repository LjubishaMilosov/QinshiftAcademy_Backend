//Create subclasses Manager and Programmer that extend the Employee class
//and implement the respective methods to calculate salary and display information for each role.

namespace Task_04.Domain.Models
{
    public class Programmer : Employee
    {

        public double OvertimePay { get; set; }
        public Programmer(int id, string name, double baseSalary, double overtimePay)
            : base(id, name, baseSalary)
        {
            OvertimePay = overtimePay;
        }
        public override double CalculateSalary()
        {
            return BaseSalary + OvertimePay;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Programmer  Id: {Id}, Name: {Name},Salary: {CalculateSalary()}");
        }
    }
   
}
