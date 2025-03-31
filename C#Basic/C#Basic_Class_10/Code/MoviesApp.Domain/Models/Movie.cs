
using MoviesApp.Domain.Enums;

namespace MoviesApp.Domain.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public int Rating { get; set; }
        public int TicketPrice { get; set; }
        public Movie(string title, Genre genre, int rating)
        {
            if(string .IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("Title must have a value");
            }
            Title = title;
            Genre = genre;

            if(rating < 1 || rating > 5)
            {
                throw new InvalidDataException("Rating must be a value between 0 and 5");
            }
            Rating = rating;
            TicketPrice = 5 * rating;
        }
    }
}
