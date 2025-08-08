using ToDoApp.Models.Dtos;

public class AddTodoViewModel
{
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public int CategoryId { get; set; }
    public List<CategoryDto> Categories { get; set; }
}