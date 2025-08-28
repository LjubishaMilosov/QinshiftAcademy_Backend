using Microsoft.EntityFrameworkCore.Migrations;
using NotesApp.DataAccess.Interfaces;
using NotesApp.Domain.Models;
using NotesApp.DTOs;
using NotesApp.Mappers;
using NotesApp.Services.Interfaces;

namespace NotesApp.Services.Implementation
{
    public class NoteService : INoteService
    {
        public readonly IRepository<Note> _noteRepository;
        public NoteService(IRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }
        public List<NoteDto> GetAllNotes()
        {
           var notes = _noteRepository.GetAll();
              //var notesDto = notes.Select(n => new NoteDto
              //{
              //  Id = n.Id,
              //  Text = n.Text,
              //  Tag = n.Tag,
              //  Priority = n.Priority,
              //  UserFullName = $"{n.User.FirstName} {n.User.LastName}"
              //    //UserFullName = n.User != null ? $"{n.User.FirstName} {n.User.LastName}" : "Unknown User"
              //}).ToList();

            //var notesDto = notes.Select(x => Mappers.NoteMapper.ToDto(x)).ToList();
            var notesDto = notes.Select(x => x.ToDto()).ToList(); // Extension method usage

            return notesDto;
        }

        public NoteDto GetNoteById(int id)
        {
           var note = _noteRepository.GetById(id);
              //var noteDto = new NoteDto
              //{
              //   Id = note.Id,
              //   Text = note.Text,
              //   Tag = note.Tag,
              //   Priority = note.Priority,
              //   UserFullName = $"{note.User.FirstName} {note.User.LastName}"
              //};

              //var noteDto = Mappers.NoteMapper.ToDto(note);
              var noteDto = note.ToDto();  // Extension method usage

            return noteDto;
        }
    }
}
