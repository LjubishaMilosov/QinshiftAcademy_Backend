using VideoRentalOnlineStore.DataAcces.Interfaces;
using VideoRentalOnlineStore.Domain.Models;
using VideoRentalOnlineStore.Services.Interfaces;

namespace VideoRentalOnlineStore.Services.Implementation
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public List<Rental> GetAllRentals() => _rentalRepository.GetAll();

        public Rental GetRentalById(int id) => _rentalRepository.GetById(id);

        public List<Rental> GetRentalsByUserId(int userId) => _rentalRepository.GetByUserId(userId);

        public void AddRental(Rental rental) => _rentalRepository.Add(rental);

        public void UpdateRental(Rental rental) => _rentalRepository.Update(rental);

        public void DeleteRental(int id) => _rentalRepository.Delete(id);
    }
}
