using NotesApp.Domain.Enums;

namespace NotesApp.Domain.Models
{
    public class Note : BaseEntity
    {
        public string Text { get; set; }
        public PriorityEnum Priority { get; set; }
        public TagEnum Tag { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
