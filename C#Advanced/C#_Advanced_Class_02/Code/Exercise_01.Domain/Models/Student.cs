

namespace Exercise_01.Domain.Models
{
    public class Student : User
    {
        public List<int> Grades { get; set; }

        public Student(int id, string name, string username, string password, List<int> grades)
            :base (id, name, username, password)
        {
            Grades = grades != null ? grades : new List<int>();
        }

        public override void PrintUser()
        {
            Console.WriteLine($"Student with id {Id} name {Name} and username {Username} has the following grades: ");
            foreach(int grade in Grades)
            {
                Console.WriteLine($"{grade} \n");
            }
        }
    }
}
