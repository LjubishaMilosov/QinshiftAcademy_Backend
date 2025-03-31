
namespace MoviesApp.Domain.Models
{
    public class Cinema
    {
        public string Name { get; set; }
        public List<int> Halls { get; set; }
        public List<Movie> Movies { get; set; }

        public Cinema(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name must have a value");
            }
            Name = name;
            Halls = new List<int>();
            Movies = new List<Movie>();
        }
        public void MoviePlaying(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException("Movie must have a value");
            }
            // check if the movie is part of the Movies list (if the movie is playing in this cinema)
            Movie foundMovie = Movies.FirstOrDefault(m => m.Title.ToLower() == movie.Title.ToLower());
            if (foundMovie == null)
            {
                throw new Exception($"The Movie {movie.Title} is not playing in this cinema");
            }
            Console.WriteLine($"We are watching {movie.Title}");
        }
    }
}
