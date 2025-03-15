using Exercise_03;

Student[] students = new Student[]
{
    new Student("Sinisha", "Qinshift", "G6"),
    new Student("Viktor", "Qinshift", "G6"),
    new Student("Ivan", "Qinshift", "G6"),
    new Student("Olgica", "Qinshift", "G6"),
    new Student("Martin", "Qinshift", "G6")
};

Console.WriteLine("Please enter a student name:");
string name = Console.ReadLine();

Student student = FindStudent(students, name);

if (student != null)
{
    student.PrintIfo();
}
else
{
    Console.WriteLine("There is no student with that name");
}

Student FindStudent(Student[] studentArray, string name)
{
    foreach (Student student in studentArray)
    {
        if (student.Name.ToLower() == name.ToLower())
        {
            return student;
        }
    }
    return null; // after we iterae the whole array, if there was no match(did not go in the if statement) we return null
}