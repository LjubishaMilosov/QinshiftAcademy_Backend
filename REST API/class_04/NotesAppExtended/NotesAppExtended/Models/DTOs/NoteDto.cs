using NotesAppExtended.Models.Enums;

namespace NotesAppExtended.Models.DTOs
{
    public class NoteDto
    {
        public string Text { get; set; } 
        public string UserName { get; set; }
        public PriorityEnum Priority { get; set; }
        public List<string> Tags { get; set; }
    }
}
