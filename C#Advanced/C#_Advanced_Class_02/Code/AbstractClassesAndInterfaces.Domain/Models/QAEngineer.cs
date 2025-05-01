
namespace AbstractClassesAndInterfaces.Domain.Models
{
    public class QAEngineer : Person
    {
        public int NumberOfProjects { get; set; }
        public List<string> TestingFrameworks { get; set; }

        public QAEngineer(string fullName, int age, string address, long phoneNumber,
            int numberOfProjects, List<string> frameworks)
            : base(fullName, age, address, phoneNumber)
            {
            NumberOfProjects = numberOfProjects;
            TestingFrameworks = frameworks == null ? new List<string>() : frameworks;
        }

        public override string GetProfessionalInfo()
        {
           string info = $"{FullName} works on {NumberOfProjects} projects. ";
            if( TestingFrameworks.Count > 0)
            {
                info += $"{FullName} is familiar with the following testing frameworks: ";
                foreach (var framework in TestingFrameworks)
                {
                    info += $"{framework} \n ";
                }
            }
            return info;
        }
    }
}
