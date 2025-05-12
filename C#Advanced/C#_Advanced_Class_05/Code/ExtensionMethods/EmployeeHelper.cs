namespace ExtensionMethods
{
    public static class EmployeeHelper
    {
        public static void PrintEmployee(Employee employee)
        {
            Console.WriteLine($"{employee.Firstname} {employee.Lastname} lives on {employee.Address}and has {employee.GetSalary()}");
        }

        public static void Print(this Employee employee)
        {
            Console.WriteLine($"{employee.Firstname} {employee.Lastname} lives on {employee.Address}and has salary of {employee.GetSalary()} usd.");
        }

        public static void PrintEmployeeInfoWithAge(this Employee employee, int age)
        {
            Console.WriteLine($"{employee.Firstname} {employee.Lastname} lives on {employee.Address}and has salary of {employee.GetSalary()} usd and is {age} years old");
        }
    }
}
