using AcademyManagement.Domain.Enums;
namespace AcademyManagement.Domain.Classes
{
    public class Student : AcademyMember
    {
        public Subject CurrentSubject { get; set; }
        public Dictionary<Subject, int> Grades { get; set; }

        public Student(string username, string firstName, string lastName, int age)
            : base(username, firstName, lastName, age, Role.Student) { }
    }
}
