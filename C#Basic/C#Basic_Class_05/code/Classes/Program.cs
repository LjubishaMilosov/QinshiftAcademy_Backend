// program.cs is always the first class that gets called when executing a project
// that's why we create the objects from Person here

using Classes;

Person firstPerson = new Person();  // calls the empty constructor
firstPerson.Firstname = "Petko";
Console.WriteLine(firstPerson.Firstname);


Person secondPerson = new Person("Stefan", "Stefanov");

Person thirdPerson = new Person("Ivan", "Ivanov", 25, 123456);