
//Create a class Student that has properties: Name,
//Academy and Group
//● Create an array with 5 new Students(objects)
//● The user should enter a name and the user information
//should be displayed in the console if a user by that
//name exists
//● If there is no such user it should show an error
//message


namespace Exercise_03
{
    public class Student
    {
        public string Name { get; set; }
        public string Academy { get; set; }
        public string Group { get; set; }

        public Student(string name, string academy, string group)
        {
            Name = name;
            Academy = academy;
            Group = group;
        }
        public void PrintIfo()
        {
            Console.WriteLine($"Name: {Name}, Academy: {Academy}, Group: {Group}");
        }


    }
}
