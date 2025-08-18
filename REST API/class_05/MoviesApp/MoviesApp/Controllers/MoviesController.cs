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

        [HttpGet("{id}")]
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
    }
}
