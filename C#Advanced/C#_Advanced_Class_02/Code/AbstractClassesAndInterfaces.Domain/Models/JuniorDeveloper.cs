
namespace AbstractClassesAndInterfaces.Domain.Models
{
   public  class JuniorDeveloper : Developer
    {
        public bool IsGraduated { get; set; }
        public JuniorDeveloper() { }

        public JuniorDeveloper(string fullName, int age, string address, long phoneNumber,
            string projectName, int yearsOfExperience, List<string> programmingLanguages, bool isGraduated)
            : base(fullName, age, address, phoneNumber, projectName, yearsOfExperience, programmingLanguages)
        {
            IsGraduated = isGraduated;
        }
    }
}
