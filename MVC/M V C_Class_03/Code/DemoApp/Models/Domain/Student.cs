namespace DemoApp.Models.Domain
{
    //this is a domain class,it represents an entity from the real world
    // this class will act as a static db, and will be used to connect to db
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Course ActiveCourse { get; set; }
    }
}