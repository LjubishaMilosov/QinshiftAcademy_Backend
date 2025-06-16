using Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers
{
    //Atribute routing examples
    [Route("students")]
    public class StudentController : Controller
    {
        private List<Student> students = new List<Student>()
        {
            new Student() { 
                Id = 1, 
                FirstName = "John", 
                LastName = "Doe", 
                DateOfBirth =  DateTime.Now.AddYears(-27) 
            },
            new Student() { 
                Id = 2, 
                FirstName = "Jane", 
                LastName = "Smith", 
                DateOfBirth =  DateTime.Now.AddYears(-37) 
            },
            new Student() { 
                Id = 3, 
                FirstName = "Alice", 
                LastName = "Johnson", 
                DateOfBirth =  DateTime.Now.AddYears(-24) 
            },
        };

        public string GetStudentFirstName()
        {
            return students.First().FirstName;
        }

        // AmbiguousMatchException: The request matched multiple endpoints
        //public string GetStudentLastName()
        //{
        //    return students.First().LastName;
        //}

        [Route("lastname")]
        public string GetStudentLastName()
        {
            return students.First().LastName;
        }

        //without route parameters
        //[Route("all")]  // standard way by using the Route attribute
        [HttpGet("all")] // another way we can specify the route is by combining it with the http attribute
        public List<Student> GetAll()
        {
            return students;
        }

        // with route params
        [HttpGet("{id}")] 
        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        [Route("byId/{id}")] // another way to specify the route
        public Student GetStudentBtIdWithRouteText(int id)
        {
            return students.FirstOrDefault(x => x.Id ==id);
        }

        [Route("byId/constraint/{id:int}")] // route constraint: id must be an integer
        public Student GetStudentByIdWithConstraint(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        [Route("{id}/{name}")] // multiple route parameters
        public Student GetStudentByIdAndNameMultipleParams(int id, string name)
        {
            return students.FirstOrDefault(x => x.Id == id && x.FirstName == name);
        }

    }
}
