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
        }[HttpPost("addMovie")] //localhost[port]/api/movies/addMovie
        // // here we dont have to add anything to the route, because we dont have another httppost method with the same route
        public IActionResult AddMovie([FromBody] AddMovieDto addMovieDto)  // we use a specific dto because  the future some of the data might change for adding/showing the movies
        {
            try
            {
                //validaions
                if (addMovieDto == null)
                {
                    return BadRequest("Bad request, the movie cannot be null.");
                }
                if (string.IsNullOrEmpty(addMovieDto.Title))
                {
                    return BadRequest("Title is required.");
                }//If description is entered
                //description was entered                            and it is longer than 250 characters
                if (!string.IsNullOrEmpty(addMovieDto.Description) && addMovieDto.Description.Length > 250)
                {
                    return BadRequest("Description cannot be longer than 250 characters.");
                    // there is no need to check if year has a null value, because a nu vlue cannot be stored into an int(it can only be stored in int?)
                }
                if (addMovieDto.Year <= 0 || addMovieDto.Year > DateTime.Now.Year)
                {
                    return BadRequest("Invalid value for year.");
                }
                var enumValues = Enum.GetValues(typeof(GenreEnum))  //returns array of the values as type Enum
                                          .Cast<GenreEnum>()  // we need our specific ype of enum - GenreEnum, not the base Enumtype, so we need to cast the Enum array into GenreEnum - Coedy=1, Action=2 etc.
                                          .Select(genre => (int)genre)
                                          .ToList();
                // genre is nullable, we need .Value to access its aue if it was sen
                if (!enumValues.Contains((int)addMovieDto.Genre))  // fo eamp, we snt 15 as genre
                {
                    return NotFound($"The genre with id {addMovieDto.Genre} was not found");
                }
                // if we reach this point, then the dto is valid and we can add it to the db
                // mapping - we need an instance of Movie class
                var newMovie = new Movie
                {
                    Id = StaticDb.Movies.LastOrDefault().Id + 1, // we can use the count to generate a new id
                    Title = addMovieDto.Title,
                    Description = addMovieDto.Description,
                    Year = addMovieDto.Year,
                    Genre = addMovieDto.Genre
                };
                StaticDb.Movies.Add(newMovie); // we add the new movie to the db
                return StatusCode(StatusCodes.Status201Created, $"Movie with id {newMovie.Id} was successfully added.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("updateMovie")] //localhost[port]/api/movies/updateMovie
        public IActionResult UpdateMovie([FromBody] UpdateMovieDto updateMovieDto)
        {
            try 
            {
                //validations
                if (updateMovieDto == null)
                {
                    return BadRequest("Bad request, the movie cannot be null.");
                }// if the updaeMovieDto.Id is null or is a negative value or is a value that does not exist in StaticDb.Movies - the vavlue
                 // of movieDb will be null, so we can use only this check

                var movieDb = StaticDb.Movies.FirstOrDefault(m => m.Id == updateMovieDto.Id);
                if (movieDb == null)
                {
                    return NotFound($"Movie with id {updateMovieDto.Id} not found.");
                }
                // the same rules (requirements) that we had to check when creating a new movie, we also have to check when updating a movie
                if (string.IsNullOrEmpty(updateMovieDto.Title))
                {
                    return BadRequest("Title is required.");
                }
                //description was entered                            and it is longer than 250 characters
                if (!string.IsNullOrEmpty(updateMovieDto.Description) && updateMovieDto.Description.Length > 250)
                {  
                    return BadRequest("Description cannot be longer than 250 characters.");
                }
                // there is no need to check if year has a null value, because a null value cannot be stored into an int(it can only be stored in int?)


                if (updateMovieDto.Year <= 0 || updateMovieDto.Year > DateTime.Now.Year)
                {
                    return BadRequest("Invalid value for year.");
                }
                var enumValues = Enum.GetValues(typeof(GenreEnum))  //returns array of the values as type Enum
                                          .Cast<GenreEnum>()  // we need our specific ype of enum - GenreEnum, not the base Enumtype, so we need to cast the Enum array into GenreEnum - Coedy=1, Action=2 etc.
                                          .Select(genre => (int)genre)
                                          .ToList();
                // genre is nullable, we need .Value to access its aue if it was sen
                if (!enumValues.Contains((int)updateMovieDto.Genre))  // fo eamp, we snt 15 as genre
                {
                    return NotFound($"The genre with id {updateMovieDto.Genre} was not found");
                }

                // mapping
                movieDb.Title = updateMovieDto.Title;
                movieDb.Description = updateMovieDto.Description;
                movieDb.Year = updateMovieDto.Year;
                movieDb.Genre = updateMovieDto.Genre;
                
                return StatusCode(StatusCodes.Status204NoContent, $"Movie with id {movieDb.Id} was successfully updated."); // 204 No Content - we don't have to return anything, just the status code
               
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("delete")] //localhost[port]/api/movies/delete
        public IActionResult DeleteMovie([FromBody]int id)
        {
            //validations
            if (id <= 0)
            {
                return BadRequest("Bad request, the id cannot be a negative number.");
            }
            var movieDb = StaticDb.Movies.FirstOrDefault(m => m.Id == id);
            if (movieDb == null)
            {
                return NotFound($"Movie with id {id} not found.");
            }
            StaticDb.Movies.Remove(movieDb); // we remove the movie from the db
            return StatusCode(StatusCodes.Status204NoContent, $"Movie with id {id} was successfully deleted.");

        }
       
    }
}
