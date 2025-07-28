using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models.Dtos;
using ToDoApp.Models.ViewModels;
using ToDoApp.Services.Implementation;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Controllers
{
    [Route("todo")] 
    public class ToDoController : Controller
    {
        private readonly IToDoService _todoService;
        private readonly IFilterService _filterService;

        public ToDoController(IToDoService todoService, IFilterService filterService)
        {
            // _todoService = new ToDoService();
            _todoService = todoService;
            _filterService = filterService;
        }
        public IActionResult Index()
        {
            int? categoryId = null;
            int? statusId = null;

            ViewBag.Filet = new FilterDto();
            ViewBag.Filetr.Categories = _filterService.GetAllCategories();
            ViewBag.Filter.Statuses = _filterService.GetAllStatuses();

            List<ToDosViewModel> todos = _todoService.GetAllTodos(categoryId, statusId);
            return View(todos);
        }
    }
}
