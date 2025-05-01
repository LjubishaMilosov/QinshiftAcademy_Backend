
namespace AbstractClassesAndInterfaces.Domain.Models
{
    public class DevOpsEngineer : Person 
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
    }
}
