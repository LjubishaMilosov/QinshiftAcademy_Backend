using Microsoft.AspNetCore.Mvc;
using NotesAppExtended.Models;
using NotesAppExtended.Models.DTOs;
using NotesAppExtended.Models.Enums;

namespace NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //http://localhost:[port]/api/notes
    public class NotesController : ControllerBase
    {
        [HttpGet] //http://localhost:[port]/api/notes
        public ActionResult<List<NoteDto>> GetAll()
        {
            try
            {
                //return Ok(StaticDb.Notes);
                var notesDb = StaticDb.Notes;
                // Select ke iziterira niz notesDb listata i za sekoj element ke treba da selektira odredeno property.
                // propertinjata sto ke gi selektira ke bidat vsusnost novo noteDto: 
                // Select ke iziterira niz notesDb listata i za sekoj note kreira nov NoteDto kade gi mapira svojstvata
                //the select linq iterates the notesDb list and for each note selects a new NoteDto where it maps the properties
                var notesDto = notesDb.Select(x => new NoteDto
                {
                    Text = x.Text,
                    Priority = x.Priority,
                    UserName = $"{x.User.FirstName} {x.User.LastName}",
                    Tags = x.Tags.Select(t => $"{t.Name} - { t.Color}").ToList()
                }).ToList();
                return Ok(notesDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //[HttpGet("{index}")] //http://localhost:[port]/api/notes/1
        //// Here we have a path param that is a part of the route
        //                     public ActionResult<Note> GetNoteByIndex(int index)
        //{
        //    try
        //    {
        //        if (index < 0)
        //        {
        //            return BadRequest("The index cannot be negative");
        //        }
        //        if (index >= StaticDb.Notes.Count)
        //        {
        //            return NotFound($"There is no resource on index {index}");
        //        }
        //        return Ok(StaticDb.Notes[index]);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}

        [HttpGet("{id}")] //http://localhost:[port]/api/notes/1
                          //Here we have a path param that is a part of the route
        public ActionResult<NoteDto> GetNoteById(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("The index cannot be negative");
                }
                Note noteDb = StaticDb.Notes.FirstOrDefault(n => n.Id == id);
                if (noteDb == null)
                {
                    return NotFound($"The note with id {id} does not exist");
                }
                NoteDto noteDto = new NoteDto
                {
                    Text = noteDb.Text,
                    Priority = noteDb.Priority,
                    UserName = $"{noteDb.User.FirstName} {noteDb.User.LastName}",
                    Tags = noteDb.Tags.Select(t => $"{t.Name} - {t.Color}").ToList()
                };
                return Ok(noteDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



        [HttpGet("multipleQuery")] //http://localhost:[port]/api/notes/multipleQuery
                                   //http://localhost:[port]/api/notes/multipleQuery?text=gym
                                   //http://localhost:[port]/api/notes/multipleQuery?priority=1
                                   //http://localhost:[port]/api/notes/multipleQuery?text=gym&priority=2
                                   //http://localhost:[port]/api/notes/multipleQuery?priority=2&text=gym
        public ActionResult<List<Note>> FilterNotesWithQueryParams(string? text, int? priority)
        {
            try
            {
                //validations
                if (string.IsNullOrEmpty(text) && priority == null)
                {
                    return BadRequest("You need to send at least one filter param");
                }
                if (string.IsNullOrEmpty(text)) //&& priority != null - at least one of the filters had to be sent
                {
                    if (priority <= 0 || priority > 3)
                    {
                        return BadRequest("Invalid value for priority");
                    }
                    List<Note> filteredNotesByPriority = StaticDb.Notes
                        .Where(x => (int)x.Priority == priority) //we need to cast, so that we can compare the values (cannot compare different types)
                        .ToList();
                    return Ok(filteredNotesByPriority);
                }
                if (priority == null) // !string.IsNullOrEmpty(text) - at least one of the filters had to be sent
                {
                    List<Note> filteredNotesByText = StaticDb.Notes
                        .Where(x => x.Text.ToLower().Contains(text.ToLower()))
                        .ToList();

                    return filteredNotesByText;
                }

                List<Note> filteredNotes = StaticDb.Notes
                    .Where(x => x.Text.ToLower().Contains(text.ToLower())
                    && x.Priority == (PriorityEnum)priority)
                    .ToList();

                return Ok(filteredNotes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost]
        public ActionResult CreatePostNote([FromBody]Note note)
        {
            try
            {
                //validation
                if (note == null)
                {
                    return BadRequest("The note cannot be null");
                }
                if (string.IsNullOrEmpty(note.Text))
                {
                    return BadRequest("Each note must contain text");
                }
                if ((int)note.Priority < 1 || (int)note.Priority > 3)
                {
                    return BadRequest("Invalid value for priority");
                }
                if (note.Tags == null || note.Tags.Count == 0)
                {
                    return BadRequest("Each note must contain at least one tag");
                }
                if (StaticDb.Notes.Any(x => x.Text == note.Text))
                {
                    return BadRequest("Note already exists");
                }
                StaticDb.Notes.Add(note);
                return StatusCode(StatusCodes.Status201Created, "Note created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet("language")]
        public IActionResult GetAppLanguageFromHeader([FromHeader] string language)
        {
            return Ok(language);
        }

        [HttpGet("userAgent")]
        // the key would be the Name we specified for our param(User-Agent)
        public IActionResult GetUserAgentFromHeader([FromHeader(Name = "User-Agent")] string userAgent)
        {
            return Ok(userAgent);
        }

        [HttpPut("updateNote/{index}")]
        public IActionResult AddTagToNote(int index, [FromBody] Tag tag)
        {
            try
            {
                if(index < 0)
                {
                    return BadRequest("The index cannot be negative");
                }
                if(index >= StaticDb.Notes.Count)
                {
                    return NotFound($"There is no note on index {index}");
                }
                var noteDb = StaticDb.Notes[index];
                if(noteDb.Tags == null)
                {
                    noteDb.Tags = new List<Tag>();
                }
                noteDb.Tags.Add(tag);
                return StatusCode(StatusCodes.Status204NoContent, "Note updated");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("addNote")]
        public IActionResult AddNote([FromBody]AddNoteDto  addNoteDto)
        {
            try
            {
                // validation
                if (addNoteDto == null)
                {
                    return BadRequest("The note cannot be null");
                }
                if(string.IsNullOrEmpty(addNoteDto.Text))
                {
                    return BadRequest("Each note must contain text");
                }
                User userDb = StaticDb.Users.FirstOrDefault(u => u.Id == addNoteDto.UserId);
                if (userDb == null)
                {
                    return NotFound($"The user with id {addNoteDto.UserId} does not exist");
                }
                List<Tag> tags = new List<Tag>();  // 1, 2, 3
                foreach (var tagId in addNoteDto.TagIds)
                {
                    Tag tagDb = StaticDb.Tags.FirstOrDefault(t => t.Id == tagId);
                    if (tagDb == null)
                    {
                        return NotFound($"The tag with id {tagId} does not exist");
                    }
                    tags.Add(tagDb);
                }
                //create
                Note newNote = new Note
                {
                    // if StaticDb.Notes.LastOrDefault() is null, it means there are no notes in the database, so we start from 1
                    Id = StaticDb.Notes.LastOrDefault()?.Id + 1 ?? 1, // if there are no notes, start from 1
                    Text = addNoteDto.Text,
                    Priority = addNoteDto.Priority,
                    User = userDb,
                    UserId = userDb.Id,
                    Tags = tags
                };

                //write to db
                StaticDb.Notes.Add(newNote);
                return StatusCode(StatusCodes.Status201Created, "Note created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("getNotesByUser/{userId}")]
        public ActionResult<List<NoteDto>> GetNoteByUser(int userId)
        {
            try
            {
                if(userId == null)
                {                     
                    return BadRequest("The userId cannot be null");
                }
                var userNote = StaticDb.Notes.Where(n => n.UserId == userId).ToList();
                var userNotesDtos = userNote.Select(x => new NoteDto
                {
                    Text = x.Text,
                    Priority = x.Priority,
                    UserName = $"{x.User.FirstName} {x.User.LastName}",
                    Tags = x.Tags.Select(t => $"{t.Name} - {t.Color}").ToList()
                }).ToList();
                return Ok(userNotesDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            }
    }
}