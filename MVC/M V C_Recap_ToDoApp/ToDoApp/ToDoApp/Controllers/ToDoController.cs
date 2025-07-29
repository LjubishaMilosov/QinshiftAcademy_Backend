using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models.ViewModels;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Controllers
{
    [Route("todo")]
    public class ToDoController : Controller
    {
        private readonly IToDoService _todoService;

        public ToDoController(IToDoService toDoService)
        {
            //  _todoService = new ToDoService();
            _todoService = toDoService;
        }
        public IActionResult Index()
        {
            int? categoryId = null;
            int? statusId = null;

           List<ToDosViewModel> todos = _todoService.GetAllTodos(categoryId, statusId);
            return View(todos);
        }
    }
}
