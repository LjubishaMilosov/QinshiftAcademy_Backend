using Microsoft.AspNetCore.Mvc;
using Qinshift.Views.Database;
using QInshift.Views.Models.ViewModels;

namespace QInshift.Views.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            List<CourseWithStudentsViewModel> courses = InMemoryDb.Courses.Select(course => new CourseWithStudentsViewModel
            {
                CourseName = course.Name,
                NumberOfClasses = course.NumberOfClasses,
                Students = InMemoryDb.Students
                    .Where(s => s.ActiveCourse.Id == course.Id)
                    .Select(s => new StudentInfoViewModel
                    {
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Age = DateTime.Today.Year - s.DateOfBirth.Year
                    }).ToList()  
            }).ToList();  

            return View(courses);
        }
    }
}
