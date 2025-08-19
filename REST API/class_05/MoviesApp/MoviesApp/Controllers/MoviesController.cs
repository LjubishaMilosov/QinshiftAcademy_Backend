using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Models;
using MoviesApp.Models.DTOs;
using MoviesApp.Models.Enum;

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
        [HttpGet("filter")]  //localhost[port]/api/movies/filter
                                     //localhost[port]/api/movies/filter?genre=1
                                     //localhost[port]/api/movies/filter?year=2022
                                     //localhost[port]/api/movies/filter?genre=1&year=2022
                                     //localhost[port]/api/movies/filter?year=2022&genre=1
        public ActionResult<List<MovieDto>> FilterMovies(int? genre, int? year)
        {
            try
            {
                if(genre == null  && year == null) //the user  is allowed to skip the query string params and the route would still be valid,
                                                   //however from business logic aspect we need at least one param so that we can filter
                {
                    return BadRequest("You have to send at least one filter param");
                }
                // check if the genre is in the correct range for the genre enum - only when genre has value(a value for genre was sent)
                if(genre.HasValue)  //HavValue checks if genre is ot null(has value)
                {
                    var enumValues = Enum.GetValues(typeof(GenreEnum))  //returns array of the values as type Enum
                                          .Cast<GenreEnum>()  // we need our specific ype of enum - GenreEnum, not the base Enumtype, so we need to cast the Enum array into GenreEnum - Coedy=1, Action=2 etc.
                                          .Select(genre => (int)genre)
                                          .ToList();
                    // genre is nullable, we need .Value to access its aue if it was sen
                    if(!enumValues.Contains(genre.Value))  // fo eamp, we snt 15 as genre
                    {
                        return NotFound($"The genre with id {genre.Value} was not found");
                    }
                }

                if(year == null) // here we can be sure that the genre has value, because we already checked the scenario where both of them dont have values.
                                 // So, if year does not have value - then genre must have a value
                {
                    List<Movie> moviesDbByGenre = StaticDb.Movies.Where(x => (int)x.Genre == genre.Value).ToList();

                    var moviesGenreDto = moviesDbByGenre.Select(x => new MovieDto
                    {
                        Description =x.Description,
                        Genre =x.Genre,
                        Year =x.Year,
                        Title = x.Title
                    });
                    return Ok(moviesGenreDto);
                }
                if(genre == null) // here we can be sure that the year has value, because we already checked the scenario where both of them dont have values.
                                  // So, if genre does not have value - then year must have a value
                {
                    var moviesDbByYear = StaticDb.Movies.Where(x => x.Year == year).ToList();
                    var moviesYearDto = moviesDbByYear.Select(x => new MovieDto
                    {
                        Description = x.Description,
                        Genre = x.Genre,
                        Year = x.Year,
                        Title = x.Title
                    });
                    return Ok(moviesYearDto);
                }
                List<Movie> moviesDb = StaticDb.Movies.Where(x => (int)x.Genre == genre.Value && x.Year == year).ToList();
                var moviesDto = moviesDb.Select(x => new MovieDto
                    {
                        Description = x.Description,
                        Genre = x.Genre,
                        Year = x.Year,
                        Title = x.Title
                    });
                return Ok(moviesDto);

            }  
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
