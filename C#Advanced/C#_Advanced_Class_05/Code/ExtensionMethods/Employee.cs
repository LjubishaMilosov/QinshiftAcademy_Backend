
namespace ExtensionMethods
{
    public class Employee
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        private int _salary { get; set; }

        public int GetSalary()
        {
            return _salary;
        }

        public void SetSalary(int salary)
        {
            if (salary < 0)
            {
                throw new ArgumentException("Salary cannot be negative");
            }
            _salary = salary;
        }
    }
}
