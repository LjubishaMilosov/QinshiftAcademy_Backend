using VideoRentalOnlineStore.Domain.Models;

namespace VideoRentalOnlineStore.DataAcces.Interfaces
{
    public  interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie GetById(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
    }
}
