using VideoRentalOnlineStore.DataAcces.Interfaces;
using VideoRentalOnlineStore.Domain.Models;
using VideoRentalOnlineStore.Services.Interfaces;

namespace VideoRentalOnlineStore.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<Movie> GetAllMovies() => _movieRepository.GetAll();

        public Movie GetMovieById(int id) => _movieRepository.GetById(id);

        public void AddMovie(Movie movie) => _movieRepository.Add(movie);

        public void UpdateMovie(Movie movie) => _movieRepository.Update(movie);

        public void DeleteMovie(int id) => _movieRepository.Delete(id);
    }
}
