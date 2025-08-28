using NotesApp.Domain.Enums;

namespace NotesApp.DTOs
{
    public class NoteDto
    {
        public int Id { get; set; }
        public String Text { get; set; }
        public PriorityEnum Priority { get; set; }
        public TagEnum Tag { get; set; }
        public String UserFullName { get; set; }
    }
}
