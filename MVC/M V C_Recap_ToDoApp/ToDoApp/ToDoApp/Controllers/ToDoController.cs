using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models.Dtos;
using ToDoApp.Models.ViewModels;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Controllers
{
    [Route("todo")]
    public class ToDoController : Controller
    {
        private readonly IToDoService _todoService;
        private readonly IFilterService _filterService;

        public ToDoController(IToDoService toDoService, IFilterService filterService)
        {
            //  _todoService = new ToDoService();
            _todoService = toDoService;
        }
        public IActionResult Index()
        {
            int? categoryId = null;
            int? statusId = null;

            ViewBag.Filter = new FilterDto();
            ViewBag.Filter.Categories = _filterService.GetCategories();
            ViewBag.Filter.Statuses = _filterService.GetStatuses();

            List<ToDosViewModel> todos = _todoService.GetAllTodos(categoryId, statusId);
            return View(todos);
        }
    }
}
