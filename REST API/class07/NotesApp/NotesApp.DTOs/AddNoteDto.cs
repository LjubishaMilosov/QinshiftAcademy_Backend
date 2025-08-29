using NotesApp.Domain.Enums;

namespace NotesApp.DTOs
{
    internal class AddNoteDto
    {
        public String Text { get; set; }
        public PriorityEnum Priority { get; set; }
        public TagEnum Tag { get; set; }
        public String UserId { get; set; }
    }
}
