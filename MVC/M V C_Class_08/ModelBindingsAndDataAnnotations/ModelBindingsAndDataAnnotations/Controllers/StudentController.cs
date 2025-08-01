using Microsoft.AspNetCore.Mvc;
using ModelBindingsAndDataAnnotations.Models.ViewModels;
using ModelBinidingsAndDataAnnotations.Database;
using ModelBinidingsAndDataAnnotations.Helpers;
using ModelBinidingsAndDataAnnotations.Models.ViewModels;

namespace ModelBindingsAndDataAnnotations.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            //we take all the students from db (domain model) and we need to map them in a view model that we will then send to the view
            List<StudentViewModel> mappedStudents = StaticDb.Students.Select(x => x.MapToStudentViewModel()).ToList();
            return View(mappedStudents);
        }

        [HttpGet("{id}")]  // /students/2  => here we use [FroumRoute] to tell the action that the id will be sent in the route
        public IActionResult GetStudentById([FromRoute] int id)
        {
            var student = StaticDb.Students.FirstOrDefault(x => x.Id == id);

            //our mapper method is an extension method
            StudentDetailsViewModel studentDetailsViewModel = student.MapToStudentDetailsVM();
            return View("StudentDetails", studentDetailsViewModel); //return the view named StudentDetails
        }

        //First way - using multiple query params
        //[HttpGet("filterBy")] // /students/filterBy?fullname=Petko Petkovski&age=31

        //public IActionResult GetStudentsByQueryFilter([FromQuery] string fullname, [FromQuery] int age)
        //{
        //    var student = StaticDb.Students.FirstOrDefault(x => x.GetFullName() == fullname && (DateTime.Now.Year - x.DateOfBirth.Year) == age);
        //    return View("StudentDetails", student.MapToStudentDetailsVM());
        //}

        //Second way - usina filter model
        [HttpGet("filterBy")] // /students/filterBy?fullname=Petko Petkovski&age=31

        public IActionResult GetStudentsByQueryFilter([FromQuery] StudentFilterViewModel filter)
        {
            var student = StaticDb.Students.FirstOrDefault(x => x.GetFullName() == filter.Fullname && (DateTime.Now.Year - x.DateOfBirth.Year) == filter.Age);
            return View("StudentDetails", student.MapToStudentDetailsVM());
        }

   
    }
}

