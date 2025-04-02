
using AcademyManagement.Domain.Classes;
using AcademyManagement.Domain.Enums;

List<Subject> Subjects = new List<Subject>();
List<Admin> Admins = new List<Admin>();
List<Student> Students = new List<Student>();
List<Trainer> Trainers = new List<Trainer>();

Admin SearchAdmins(string username)
{
    return Admins.FirstOrDefault(x => x.Username == username);
}

Trainer SearchTrainers(string username)
{
    return Trainers.FirstOrDefault(x => x.Username == username);
}

Student SearchStudents(string username)
{
    return Students.FirstOrDefault(x => x.Username == username);
}
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