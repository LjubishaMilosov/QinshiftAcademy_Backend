using DemoApp.Database;
using DemoApp.Models.Domain;

namespace DemoApp.Services
{
    public class StudentService
    {
        public Student GetStudentById(int id)
        {
            
            return StaticDb.Students.FirstOrDefault(s => s.Id == id); //when accessing the db we are working with domain models
        }
    }
}
