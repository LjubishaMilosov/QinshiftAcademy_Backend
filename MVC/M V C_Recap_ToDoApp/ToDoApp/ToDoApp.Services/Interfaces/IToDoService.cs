using ToDoApp.Models.ViewModels;

namespace ToDoApp.Services.Interfaces
{
    public interface IToDoService
    {
        // categoryId and statusIdare optional parameters
        List<ToDosViewModel>GetAllTodos(int? categoryId, int? statusId);
    }
}
