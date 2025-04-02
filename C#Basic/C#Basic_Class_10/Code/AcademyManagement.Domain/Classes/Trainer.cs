using AcademyManagement.Domain.Enums;
namespace AcademyManagement.Domain.Classes
{
    public class Trainer : AcademyMember
    {
        public Trainer(string username, string firstName, string lastName, int age)
            : base(username, firstName, lastName, age, Role.Trainer) { }
    }
}
