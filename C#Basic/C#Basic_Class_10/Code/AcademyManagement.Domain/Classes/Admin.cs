using AcademyManagement.Domain.Enums;

namespace AcademyManagement.Domain.Classes
{
    public class Admin : AcademyMember
    {
        
        public Admin(string username, string firstName, string lastName, int age)
            : base(username, firstName, lastName, age, Role.Admin) { }
    }
}
