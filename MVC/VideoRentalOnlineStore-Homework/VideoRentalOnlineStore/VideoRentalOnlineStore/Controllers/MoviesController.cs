using Microsoft.AspNetCore.Mvc;
using VideoRentalOnlineStore.Services.Interfaces;

namespace VideoRentalOnlineStore.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            var movies = _movieService.GetAllMovies();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null) return NotFound();
            return View(movie);
        }
    }
}
