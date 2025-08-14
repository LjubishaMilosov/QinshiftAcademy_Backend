using VideoRentalOnlineStore.Domain.Models;

namespace VideoRentalOnlineStore.DataAcces
{
    public static class StaticDb
    {
        public static List<User> Users = new List<User>
        {
            new User { Id = 1, FullName = "Alice Smith", Age = 30, CardNumber = "12345", CreatedOn = DateTime.Now.AddYears(-1), IsSubscriptionExpired = false, SubscriptionType = SubscriptionType.Monthly },
            new User { Id = 2, FullName = "Bob Johnson", Age = 25, CardNumber = "67890", CreatedOn = DateTime.Now.AddMonths(-6), IsSubscriptionExpired = true, SubscriptionType = SubscriptionType.Yearly }
        };

        public static List<Movie> Movies = new List<Movie>
        {
            new Movie { Id = 1, Title = "Inception", Genre = Genre.SciFi, Language = Language.English, IsAvailable = true, ReleaseDate = new DateTime(2010, 7, 16), Length = TimeSpan.FromMinutes(148), AgeRestriction = 13, Quantity = 5 },
            new Movie { Id = 2, Title = "The Godfather", Genre = Genre.Drama, Language = Language.English, IsAvailable = true, ReleaseDate = new DateTime(1972, 3, 24), Length = TimeSpan.FromMinutes(175), AgeRestriction = 18, Quantity = 2 }
        };

        public static List<Rental> Rentals = new List<Rental>();

        public static List<Cast> Casts = new List<Cast>
        {
            new Cast { Id = 1, MovieId = 1, Name = "Leonardo DiCaprio", Part = Part.Actor },
            new Cast { Id = 2, MovieId = 2, Name = "Marlon Brando", Part = Part.Actor }
        };
    }
}
