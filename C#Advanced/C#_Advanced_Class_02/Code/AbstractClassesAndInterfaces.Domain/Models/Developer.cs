
namespace AbstractClassesAndInterfaces.Domain.Models
{
    public class Developer : Person
    {
        public string ProjectName { get; set; }
        public int YearsOfExperience { get; set; }
        public List<string> ProgrammingLanguages { get; set; }

        public Developer() { }

        public Developer(string fullName, int age, string address, long phoneNumber,
            string projectName, int yearsOfExperience, List<string> programmingLanguages)// when we create a Developer, this constructo is called
            : base(fullName, age, address, phoneNumber)
        {
            ProjectName = projectName;
            YearsOfExperience = yearsOfExperience;
            ProgrammingLanguages = programmingLanguages == null ? new List<string>() : programmingLanguages;
        }

        // this method must be present because it an abstract method in the parent class(Person)
        public override string GetProfessionalInfo()
        {
            return $"{FullName} works as a deloper for {YearsOfExperience}. {FullName} works on {ProjectName}";
        }
    }
}
