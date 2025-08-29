using NotesApp.DTOs;

namespace NotesApp.Services.Interfaces
{
    public interface INoteService
    {
        List<NoteDto> GetAllNotes();

        NoteDto GetNoteById(int id);

        void AddNote(NoteDto note);
    }
}
