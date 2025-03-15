using Classes;

// program.cs is always the first class that gets called when executing a project
// that's why we create the objects from Person here


Person firstPerson = new Person();  // calls the empty constructor
firstPerson.Firstname = "Petko";
Console.WriteLine(firstPerson.Firstname);

// _ssn is private and can be accesse only in the class
//firstPerson._ssn => error

Person secondPerson = new Person("Stefan", "Stefanov");
Console.WriteLine(secondPerson.Firstname);
Console.WriteLine(secondPerson.Firstname);
Console.WriteLine(secondPerson.Age);  // 0

Person thirdPerson = new Person("Ivan", "Ivanov", 25, 123456);
Console.WriteLine(thirdPerson.Firstname);
Console.WriteLine(thirdPerson.Lastname);
Console.WriteLine(thirdPerson.Age);  

firstPerson.PrintDetails();
secondPerson.PrintDetails();
thirdPerson.PrintDetails();

Console.WriteLine(thirdPerson.GetSSN());
// thirdPerson._ssn;  => Error
// thirdPerson._ssn - 123123;  => ERROR

firstPerson.SetSSN(123123);
Console.WriteLine(firstPerson.GetSSN());