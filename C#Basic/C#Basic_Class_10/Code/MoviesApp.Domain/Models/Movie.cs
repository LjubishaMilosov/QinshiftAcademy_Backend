
using System.Xml.Linq;
using MoviesApp.Domain.Enums;

//Make a class Movie. Movie must have: Title, Genre, Rating,
//TicketPrice and a constructor for setting them.
//● Rating should be a number from 1 to 5. Throw exception if its more or
//less ( you should also handle other exceptions)
//● Set the TicketPrice to be 5 * Rating when creating a new object
//● Genre should be an enum with Comedy, Horror, Action, Drama and
//SciFi


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
