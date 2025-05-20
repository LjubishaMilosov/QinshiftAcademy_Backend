using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using AdvancedLINQ;
using AdvancedLINQ.Domain;
using AdvancedLINQ.Domain.Models;


List<Student> sttudentsOlderThan25 = QinshiftAcademy.Students.Where(x => x.Age > 25).ToList();
sttudentsOlderThan25.PrintEntities();

List<string> NamesOfStudentOlderThan25 = QinshiftAcademy.Students.Where(X500DistinguishedName => X500DistinguishedName.Age > 25)
    .Select(x => x.FirstName).ToList();
NamesOfStudentOlderThan25.PrintSimple();

List<Student> studentsNamedBob = QinshiftAcademy.Students.Where(x => x.FirstName == "Bob").ToList();
studentsNamedBob.PrintEntities();


Console.WriteLine("LINQ to SQL");
var studentsNamedBobSQl = (from student in QinshiftAcademy.Students // from all students in the list QinshiftAcademy.Students
                           where student.FirstName == "Bob" // filter out the ones names Bob
                           select student).ToList(); // take the whole object (record) student

var agesOfStudentsNamedBobSQl = (from student in QinshiftAcademy.Students // from all students in the list QinshiftAcademy.Students
                           where student.FirstName == "Bob" // filter out the ones names Bob
                           select student.Age).ToList(); // take the age of the student

//First/Last/Single /OrDefault
//First => gets the first element, if no elements it will throw an error
//FirstOrDefault => gets the first element, if no elements it will return the default and will not throw an error
//Last => gets the last element, if no elements it will throw an error
//LastOrDefault => gets the last element, if no elements it will return the default and will not throw an error
//Single => gets the only element from the list, if no elements or more than one element - it will throw an error
//SingleOrDefault=> gets the only element from the list, if no elements - default value, if more than one element - throws an error

//Student studentStartingWithT = QinshiftAcademy.Students.Single(x => x.FirstName.StartsWith("T")); //ERROR
//Student studentStartingWithB = QinshiftAcademy.Students.SingleOrDefault(x => x.FirstName.StartsWith("B")); //ERROR

//Student studentStartingWithT = QinshiftAcademy.Students.Single(x => x.FirstName.StartsWith("T")); //ERROR
//Student studentStartingWithB = QinshiftAcademy.Students.SingleOrDefault(x => x.FirstName.StartsWith("B")); //ERROR
Student studentStartingWithT = QinshiftAcademy.Students.SingleOrDefault(x => x.FirstName.StartsWith("T")); //default


//here we get a list of lists which is complicated to work with
//here we will have a list of subjects for all the students that are part time
//the result is a list od lists
var subjectsOfPartTime = QinshiftAcademy.Students
    .Where(x => x.IsPartTime)
    .SelectMany(x => x.Subjects)
    .ToList();

// selectmany flattens the list of lists into a single list.The members of each list in the list of lists become members of the main list
List<Subject> subjectsOfPartTimeStudents = QinshiftAcademy.Students
    .Where(x => x.IsPartTime)
    .SelectMany(x => x.Subjects)
    .ToList();

// Except => gets all except the ones that we tell it to exclude
List<Student> exceptBob = QinshiftAcademy.Students.Except(studentsNamedBob).ToList();

//Any/All
bool checkIfAnyPartTime = QinshiftAcademy.Students.Any(x => x.IsPartTime); //true - check if at least one  item is part time
bool checksIfAllArePartTime = QinshiftAcademy.Students.All(x => x.IsPartTime); //false - check if all items are part time

//Distinct/DistinctBy - removes duplicates
List<int> numbers = new List<int>() { 4, 6, 4, 6 };
List<int> distinctNumbers = numbers.Distinct().ToList(); //4,6
distinctNumbers.PrintSimple();

List<Student> distinctByAge = QinshiftAcademy.Students.DistinctBy(x => x.Age).ToList(); //4,6 
//when we work with objects, we cannot compere them just with distinct, we need to tell the program
//based on which properties to compare the elements


//OrderBy/OrderByDescendig
List<Student> studentsOrderedByAge = QinshiftAcademy.Students.OrderBy(x => x.Age).ToList(); //order by is ascending by default
List<Student> studentsOrderedByAgeDesc = QinshiftAcademy.Students.OrderByDescending(x => x.Age).ToList();

List<Student> studentsOrderedByName = QinshiftAcademy.Students.OrderBy(x => x.FirstName).ToList();
studentsOrderedByName.PrintEntities();