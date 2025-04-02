
using AcademyManagement.Domain.Enums;

namespace AcademyManagement.Domain.Classes
{
    public class AcademyMember
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Role Role { get; set; }

        public AcademyMember(string username, string firstName, string lastName, int age, Role role) 
        {
            UserName = username;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Role = role;
        }
    }
}
