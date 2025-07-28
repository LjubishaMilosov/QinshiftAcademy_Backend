namespace ToDoApp.Models.ViewModels
{
    public class ToDosViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Categoryname { get; set; }
        public string StatusName { get; set; }
    }
}
