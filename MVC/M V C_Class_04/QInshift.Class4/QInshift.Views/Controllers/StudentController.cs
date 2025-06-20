using Microsoft.AspNetCore.Mvc;
using Qinshift.Views.Database;
using Qinshift.Views.Models.Domain;
using QInshift.Views.Models.ViewModels;

namespace QInshift.Views.Controllers
{
    public class StudentController : Controller
    {
        //   /nameOfController/nameOfAction
        //   /student/index
        public IActionResult Index()
        {
            // 1)  Get all students from Db
            List<Student> studentsDb = InMemoryDb.Students;

            // 20 Map to corresponding ViewModel
            List<StudentViewModel> mappedStudents = studentsDb.Select(s => new StudentViewModel
            {
                FullName = s.GetFullName(),
                Age = (int)((DateTime.Now - s.DateOfBirth).TotalDays / 365.25),
                ActiveCourseName = s.ActiveCourse?.Name ?? "No active course"
            }).ToList();

            // send the mapped object to the view
            return View(mappedStudents);
        }

        public IActionResult GetStudentById(int id)
        {
            Student student = InMemoryDb.Students.FirstOrDefault(s => s.Id == id);
            if(student == null)
            {
                return View();
            }
            StudentCourseViewModel mappedStudent = new StudentCourseViewModel
            {
                Firstname = student.FirstName,
                Lastname = student.LastName,
                Age = DateTime.UtcNow.Year - student.DateOfBirth.Year,
                CourseName = student.ActiveCourse?.Name ?? "No active course",
                NumberOfClasses = student.ActiveCourse?.NumberOfClasses ?? 0
            };
            return View(mappedStudent);
        }
    }
}
