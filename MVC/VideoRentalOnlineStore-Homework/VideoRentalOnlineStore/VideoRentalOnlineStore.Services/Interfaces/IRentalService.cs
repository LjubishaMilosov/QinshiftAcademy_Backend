using VideoRentalOnlineStore.Domain.Models;

namespace VideoRentalOnlineStore.Services.Interfaces
{
    public interface IRentalService
    {
        List<Rental> GetAllRentals();
        Rental GetRentalById(int id);
        List<Rental> GetRentalsByUserId(int userId);
        void AddRental(Rental rental);
        void UpdateRental(Rental rental);
        void DeleteRental(int id);
    }
}

