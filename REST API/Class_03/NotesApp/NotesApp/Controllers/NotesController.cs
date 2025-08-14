using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Enums;
using NotesApp.Models;

namespace NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    //http://localhost:[port]/api/notes
    public class NotesController : ControllerBase
    {
        [HttpGet]
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
        [HttpGet("{index}")]    //http://localhost:[port]/api/notes/1
        // here we have a path param that is part of the route
        public ActionResult<Note> GetNotebyIndex(int index)

        {
            try
            {
                if (index < 0)
                {
                    return BadRequest("Index cannot be negative.");
                }
                if (index >= StaticDb.Notes.Count)
                {
                    return NotFound($"There is no resource on index {index}.");
                }
                return Ok(StaticDb.Notes[index]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("multipleQuery")]    //http://localhost:[port]/api/notes/multipleQuery
                                              //http://localhost:[port]/api/notes/multipleQuery?text=gym
                                              //http://localhost:[port]/api/notes/multipleQuery?priority=1
                                              //http://localhost:[port]/api/notes/multipleQuery?text=gym&priority=1
                                              //http://localhost:[port]/api/notes/multipleQuery?priority=1&text=gym
        public ActionResult<List<Note>> FilterNotesWithQueryParams(string? text, int? priority)
        {
            try
            {
                //if (string.IsNullOrEmpty(text) && priority == null)
                if (string.IsNullOrEmpty(text) && !priority.HasValue)
                {
                    return BadRequest("At least one query parameter must be provided.");
                }
                if (string.IsNullOrEmpty(text)) // && priority != null - at least one of the filters had to be sent
                {
                    if (priority <= 0 || priority > 3)
                    {
                        return BadRequest("Invalid value for priority");
                    }
                    List<Note> FilteredNotesByPriority = StaticDb.Notes
                        .Where(x => (int)x.Priority == priority)
                        .ToList();
                    return Ok(FilteredNotesByPriority);
                }
                if(priority == null)  //!string.IsNullOrEmpty(text)
                {
                    List<Note> filteredNotesByText = StaticDb.Notes
                        .Where(x => x.Text.ToLower().Contains(text.ToLower()))
                        .ToList();
                    return Ok(filteredNotesByText);
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
    }
}
