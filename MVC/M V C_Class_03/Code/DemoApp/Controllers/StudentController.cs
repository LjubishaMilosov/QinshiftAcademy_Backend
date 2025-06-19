using DemoApp.Database;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    public class StudentController : Controller
    {
        //Bad practice - Avoid accessing the db and using domain models in the controller actions
        public IActionResult GetAllStudents()
        {
            return Json(StaticDb.Students);
        }

    }
}
