using VideoRentalOnlineStore.DataAcces.Interfaces;
using VideoRentalOnlineStore.Domain.Models;

namespace VideoRentalOnlineStore.DataAcces.Implementation
{
    public class MovieRepository : IMovieRepository
    {
        public void Add(Movie movie)
        {
            StaticDb.Movies.Add(movie);
        }

        public void Delete(int id)
        {
            var movie = GetById(id);
            if (movie != null)
            {
                StaticDb.Movies.Remove(movie);
            }
        }

        public List<Movie> GetAll()
        {
            return StaticDb.Movies;
        }

        public Movie GetById(int id)
        {
            return StaticDb.Movies.FirstOrDefault(m => m.Id == id)
                ?? throw new KeyNotFoundException($"Movie with ID {id} not found."); ;
        }

        public void Update(Movie movie)
        {
            var existing = GetById(movie.Id);
            if (existing != null)
            {
                existing.Title = movie.Title;
                existing.Genre = movie.Genre;
                existing.Language = movie.Language;
                existing.IsAvailable = movie.IsAvailable;
                existing.ReleaseDate = movie.ReleaseDate;
                existing.Length = movie.Length;
                existing.AgeRestriction = movie.AgeRestriction;
                existing.Quantity = movie.Quantity;
            }
            else
            {
                throw new KeyNotFoundException($"Movie with ID {movie.Id} not found.");

            }
        }
    }
}
