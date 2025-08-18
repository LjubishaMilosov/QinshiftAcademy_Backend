using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Models.DTOs;

namespace MoviesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var moviesDb = StaticDb.Movies;
                if(moviesDb == null)
                {
                    return Ok(new List<MovieDto>()); //we haven't added any movies yet - not an error, just an empty collection
                }
                var moviesDto = moviesDb.Select(m => new MovieDto  
                // sakame da se izbere novo movieDto za sekoj eden item kojsto
                // go imame tuka pri sto title ke bide m.Title itn..
                // we need to map the data from the db(movie domain class) into movieDto
                {
                    Title = m.Title,
                    Description = m.Description,
                    Year = m.Year,
                    Genre = m.Genre
                }).ToList();
                return Ok(moviesDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]   // we must send the path param because it part of the basic route - it differences this route from the othr routes
        // if we don't send the path param - then this endpoint will not be hit (it will go to the route for GetAll)
        public ActionResult<MovieDto> GetByPathId(int id)
        {
            try
            {
                // validations
                if(id <= 0)
                {
                    return BadRequest("Bad request, the id cannot be a negative number.");
                }
                var movieDb = StaticDb.Movies.FirstOrDefault(m => m.Id == id);
                if(movieDb == null)
                {
                    return NotFound($"Movie with id {id} not found.");
                }
                var movieDto = new MovieDto
                {
                    Title = movieDb.Title,
                    Description = movieDb.Description,
                    Year = movieDb.Year,
                    Genre = movieDb.Genre
                };
                return Ok(movieDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        // it is totally valid not to send a query param - because a query param is notpart of the basic route, but it is added to the basic route - we can still hit this endpoint without this param
        [HttpGet("queryString")]  // localhost:[port]/api/movies/queryString - this is the route witout the query string part - this is the basic route/url for this method
                                         // localhost:[port]/api/movies/queryString?id=1 - we can add to the basic route for this method a query string where we can send the params
        public ActionResult<MovieDto> GetByQueryStringId(int? id)
        {
            try
            {
                if(id == null)
                {
                    return BadRequest("Bad request, the id cannot be null.");
                }
                if(id <= 0)
                {
                    return BadRequest("Bad request, the id cannot be a negative number.");
                }
                var movieDb = StaticDb.Movies.FirstOrDefault(m => m.Id == id);
                if(movieDb == null)
                {
                    return NotFound($"Movie with id {id} not found.");
                }
                var movieDto = new MovieDto 
                { 
                    Description = movieDb.Description, 
                    Title = movieDb.Title, 
                    Year = movieDb.Year, 
                    Genre = movieDb.Genre 
                };
                return Ok(movieDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
