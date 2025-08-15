using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Enums;
using NotesApp.Models;

namespace NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //http://localhost:[port]/api/notes
    public class NotesController : ControllerBase
    {
        [HttpGet] //http://localhost:[port]/api/notes
        public ActionResult<List<Note>> GetAll()
        {
            try
            {
                return Ok(StaticDb.Notes);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{index}")] //http://localhost:[port]/api/notes/1
                             //Here we have a path param that is a part of the route
        public ActionResult<Note> GetNoteByIndex(int index)
        {
            try
            {
                if (index < 0)
                {
                    return BadRequest("The index cannot be negative");
                }
                if (index >= StaticDb.Notes.Count)
                {
                    return NotFound($"There is no resource on index {index}");
                }
                return Ok(StaticDb.Notes[index]);
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
    }
}