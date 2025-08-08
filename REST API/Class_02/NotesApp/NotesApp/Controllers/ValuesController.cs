using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NotesApp.Controllers
{
    [Route("api/[controller]")] // http://localhost:[port]/ap/values
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]   // NO ADDITIONAL INFO NEEDED, DEFAULT GET METHOD
                    // http://localhost:[port]/api/values
        public List<string> Get()
        {
            return new List<string>() { "Value1", "Value2" };
        }

        //[HttpGet]    // ERROR - has same http method and same address
        //             // http://localhost:[port]/api/values
        //public int GetNumber()
        //{
        //    return 1;
        //}

        [HttpGet("number")]

        public int GetNumber()
        {
            return 1;
        }


        [HttpPost("number")]

        public string GetString()
        {
            return "Hello";
        }

        [HttpGet("details/{id}")]
        public int GetId(int id) // http://localhost:[port]/api/values/details/1
        {
            return id;
        }

        [HttpGet("{id}")]
        public int GetIdFirstNumber(int id) // http://localhost:[port]/api/values/details/1
        {
            return id;
        }

        [HttpGet("userId/{userId}/bookId/{bookId}")]  // http://localhost:[port]/api/values/userId/1/bookId/2
        public string GetUserAndBook(int userId, int bookId)
        {
            return $"User: {userId}, Book: {bookId}";
        }
        [HttpGet("{number}/movies")] // http://localhost:[port]/api/values/1/movies
        public List<string> GetMovies()
        {
                       return new List<string>() { "Deadpool", "Joker" };
        }
    }
}
