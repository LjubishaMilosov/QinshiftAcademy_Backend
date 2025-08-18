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
    }
}
