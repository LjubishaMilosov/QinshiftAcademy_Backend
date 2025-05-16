namespace AdvancedLINQ.Domain.Models
{
    public class Students : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool IsPartTime { get; set; }
        public List<Subject> Subjects { get; set; }
        public Students() 
        {
            Subjects = new List<Subject>();
        }
        public Students(string firstName, string lastName, int age, bool isPartTime)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            IsPartTime = isPartTime;
            Subjects = new List<Subject>();
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"{FirstName} {LastName} aged {Age} attends {Subjects.Count}");
        }
    }
}
