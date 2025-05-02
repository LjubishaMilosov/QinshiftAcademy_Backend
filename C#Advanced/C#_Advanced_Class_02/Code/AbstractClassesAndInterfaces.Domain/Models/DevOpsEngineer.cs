
using AbstractClassesAndInterfaces.Domain.Interfaces;

namespace AbstractClassesAndInterfaces.Domain.Models
{
    public class DevOpsEngineer : Person, IDevOpsEngineer, IDeveloper
    {
        public bool IsAzureCertified { get; set; }
        public bool IsAWSCertified { get; set; }

        public DevOpsEngineer() { }

        public DevOpsEngineer(string fullName, int age, string address, long phoneNumber, 
            bool isAzureCered, bool isAWSCertified)
            : base(fullName, age, address, phoneNumber)
        {
            IsAzureCertified = isAzureCered;
            IsAWSCertified = isAWSCertified;
        }

        public override string GetProfessionalInfo()
        {
            string info = $"{FullName}";
            info += IsAzureCertified ? "is Azure certified!" : "is not Azure certifid!";
            info += IsAWSCertified ? "is AWS certified!" : "is not AWS certifid!";
            return info;
        }

        public bool CheckInfrastructure(int status)
        {
            List<int> okStatuses = new List<int> { 200, 201, 203, 204 };
            return okStatuses.Contains(status);
        }

        // each class can implement the method diffrently depending on the 
        // logic in that class
        public void Code()
        {
            if(IsAzureCertified)
            {
                Console.WriteLine("Writing code for Azure portal services");
            }
             if (IsAWSCertified)
            {
                Console.WriteLine("Writing code for AWS portal services");
            }
            
        }
    }
}
