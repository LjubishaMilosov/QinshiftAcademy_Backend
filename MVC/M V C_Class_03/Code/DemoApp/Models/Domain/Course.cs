namespace DemoApp.Models.Domain
{
    //this is a domain class,it represents an entity from the real world
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfClasses { get; set; }
    }
}