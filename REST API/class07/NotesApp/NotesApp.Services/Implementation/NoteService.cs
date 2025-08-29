using Microsoft.EntityFrameworkCore.Migrations;
using NotesApp.DataAccess;
using NotesApp.DataAccess.Interfaces;
using NotesApp.Domain.Models;
using NotesApp.DTOs;
using NotesApp.Mappers;
using NotesApp.Services.Interfaces;

namespace NotesApp.Services.Implementation
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> _noteRepository;
        private readonly IRepository<User> _userRepository;
        public NoteService(IRepository<Note> noteRepository, IRepository<User> userRepository)
        {
            _noteRepository = noteRepository;
            _userRepository = userRepository;
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

        public void AddNote(NoteDto note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note), "Note cannot be null");
            }
            if (string.IsNullOrWhiteSpace(note.Text))
            {
                throw new ArgumentNullException("Note text cannot be empty", nameof(note.Text));
            }
            if (note.Text.Length > 100)
            {
                throw new ArgumentException("Note text cannot exceed 100 characters", nameof(note.Text));
            }
            //if(note.Tag == null)  // tag is not nullable, so this conditionwill be always false.Same for Priority
            //{
            //    throw new ArgumentNullException("Note tag cannot be null", );
            //}
            var user = _noteRepository.GetById(note.UserId);
            if (user == null)
            {
                throw new ArgumentException($"User with id {note.UserId} does not exist");
            }
            var noteDb = new Note
            {
                Text = note.Text,
                Priority = note.Priority,
                Tag = note.Tag,
                UserId = note.UserId
            };
            _noteRepository.Add(noteDb);
        }
    }
}
