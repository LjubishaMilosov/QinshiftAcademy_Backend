using ExtensionMethods;

//EmployeeHelper.PrintEmployee(new Employee
//{
//    Firstname = "John",
//    Lastname = "Doe",
//    Address = "123 Main St"
//});

Employee employee = new Employee();
employee.Firstname = "John";
employee.Lastname = "Doe";
employee.Address = "123 Main St";
employee.SetSalary(50000);

Employee employee2 = new Employee();
employee2.Firstname = "Nikola";
employee2.Lastname = "Nikolovski";
employee2.Address = "567 Main St";
employee2.SetSalary(10000);

// we need to call this method using the EmployeeHelper class and pass the employee as a param
EmployeeHelper.PrintEmployee(employee);
Console.WriteLine("================================================================");

// the parameter in Print(this Employee employee) will be replaced by the employee that we call the method on
// we don't need to send the employee as parameter
employee.Print();
employee2.Print();

Console.WriteLine("================================================================");

// the first param in PrintEmployeeInfoWithAge(this Employee employee, int age) will be replaced by the employe on which we cal the method
// we only need to send the rest of the params
employee.PrintEmployeeInfoWithAge(30);
employee2.PrintEmployeeInfoWithAge(25);

string text = " Some text about G6 and Qinshift Academy";
string text2 = " Some text about G6 and Qinshift Academy";

Console.WriteLine(text.Shorten(5));
Console.WriteLine(text.Shorten(2));

List<Employee> list = new List<Employee>() { employee, employee2};
List<int> ints = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

string infoAboutList = list.GetInfo();
Console.WriteLine(infoAboutList);

string infoAboutInts = ints.GetInfo();
Console.WriteLine(infoAboutInts);