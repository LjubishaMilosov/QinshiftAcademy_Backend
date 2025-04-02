
using AcademyManagement.Domain.Classes;
using AcademyManagement.Domain.Enums;

List<Subject> Subjects = new List<Subject>();
List<Admin> Admins = new List<Admin>();
List<Student> Students = new List<Student>();
List<Trainer> Trainers = new List<Trainer>();

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

void RemoveAdmin(string username)
{
    Admin admin = SearchAdmins(username);
    if (admin == null)
    {
        throw new Exception("There is no such admin");
    }
    Admins.Remove(admin);
}

void RemoveStudent(string username)
{
    Student student = SearchStudents(username);
    if (student == null)
    {
        throw new Exception("There is no such student");
    }
    Students.Remove(student);
}

void RemoveTrainer(string username)
{
    Trainer trainer = SearchTrainers(username);
    if (trainer == null)
    {
        throw new Exception("There is no such trainer");
    }
    Trainers.Remove(trainer);
}

void AddMember(Role role)
{
    Console.WriteLine("Enter username");
    string username = Console.ReadLine();
    if (string.IsNullOrEmpty(username))
    {
        throw new Exception("You must enter username");
    }

    Admin admin = SearchAdmins(username);
    Trainer trainer = SearchTrainers(username);
    Student student = SearchStudents(username);

    if (admin != null || trainer != null || student != null)
    {
        throw new Exception("User with this username already exists");
    }

    Console.WriteLine("Enter first name");
    string firstName = Console.ReadLine();
    if (string.IsNullOrEmpty(firstName))
    {
        throw new Exception("You must enter first name");
    }

    Console.WriteLine("Enter last name");
    string lastName = Console.ReadLine();
    if (string.IsNullOrEmpty(lastName))
    {
        throw new Exception("You must enter last name");
    }

    int age = int.Parse(Console.ReadLine());
    if (age < 16)
    {
        throw new Exception("Age must be greater than 16");
    }

    if (role == Role.Admin)
    {
        Admins.Add(new Admin(username, firstName, lastName, age));
    }
    else if (role == Role.Trainer)
    {
        Trainers.Add(new Trainer(username, firstName, lastName, age));
    }
    else
    {
        Student newStudent = new Student(username, firstName, lastName, age);

        Console.WriteLine("Enter subject name");
        string currentSubject = Console.ReadLine();
        Subject current = Subjects.FirstOrDefault(x => x.Name == currentSubject);
        newStudent.CurrentSubject = current;

        Students.Add(newStudent);
    }
}

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