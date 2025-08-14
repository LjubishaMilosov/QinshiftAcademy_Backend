using VideoRentalOnlineStore.Domain.Models;

namespace VideoRentalOnlineStore.DataAcces.Interfaces
{
    public interface IRentalRepository
    {
        List<Rental> GetAll();
        Rental GetById(int id);
        List<Rental> GetByUserId(int userId);
        void Add(Rental rental);
        void Update(Rental rental);
        void Delete(int id);
    }
}
