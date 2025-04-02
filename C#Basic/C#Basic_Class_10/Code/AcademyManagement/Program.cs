
using AcademyManagement.Domain.Classes;
using AcademyManagement.Domain.Enums;

List<Subject> Subjects = new List<Subject>();
List<Admin> Admins = new List<Admin>();
List<Student> Students = new List<Student>();
List<Trainer> Trainers = new List<Trainer>();

void FillDataBase()
{
    
    Subjects.Add(new Subject { Name = "HTML" });
    Subjects.Add(new Subject { Name = "Basic JS" });
    Subjects.Add(new Subject { Name = "Advanced JS" });
    Subjects.Add(new Subject { Name = "Basic C#" });

    Admins = new List<Admin>();
    Admins.Add(new Admin("ddejan", "Dejan", "Dejanovski", 30));
    Admins.Add(new Admin("iigor", "Igor", "Igevski", 32));

    Trainers = new List<Trainer>();
    Trainers.Add(new Trainer("saleksandar", "Aleksandar", "Stojanovski", 25));
    Trainers.Add(new Trainer("iangela", "Angela", "Ilievska", 25));
    Trainers.Add(new Trainer("sstefan", "Stefan", "Stamenov", 23));



    Students = new List<Student>();
    Students.Add(new Student("pfilip", "Filip", "Petrovski", 21)
    {
        CurrentSubject = Subjects.Last()
    });
    Students.First().Grades = new Dictionary<Subject, int>(); // Students.First() -> filip
    Students.First().Grades.Add(Subjects.FirstOrDefault(x => x.Name == "Basic JS"), 5);


    Dictionary<Subject, int> grades = new Dictionary<Subject, int>();
    grades.Add(Subjects.FirstOrDefault(x => x.Name == "Advanced JS"), 5);
    grades.Add(Subjects.FirstOrDefault(x => x.Name == "Basic C#"), 4);
    Students.Add(new Student("mmarija", "Marija", "Mitrevska", 22)
    {
        CurrentSubject = Subjects.First(),
        Grades = grades
    });

}

void PrintStudents()
{
    Console.WriteLine("Here are the students:");
    foreach (Student student in Students)
    {
        Console.WriteLine(student.GetFullName());
    }
}

void PrintSubjects()
{
    Console.WriteLine("Here are the subjects:");
    foreach (Subject subject in Subjects)
    {
        Console.WriteLine(subject.Name);
        int numOfStudents = Students.Count(x => subject.Name == x.CurrentSubject.Name);
        Console.WriteLine(numOfStudents);
    }
}

