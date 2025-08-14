using VideoRentalOnlineStore.DataAcces.Interfaces;
using VideoRentalOnlineStore.Domain.Models;

namespace VideoRentalOnlineStore.DataAcces.Implementation
{
    public class RentalRepository : IRentalRepository
    {
        public void Add(Rental rental)
        {
            StaticDb.Rentals.Add(rental);
        }

        public void Delete(int id)
        {
            StaticDb.Rentals.Remove(GetById(id));
        }

        public List<Rental> GetAll()
        {
            return StaticDb.Rentals;
        }

        public Rental GetById(int id)
        {
            return StaticDb.Rentals.FirstOrDefault(r => r.Id == id) 
                   ?? throw new KeyNotFoundException($"Rental with ID {id} not found.");
        }

        public List<Rental> GetByUserId(int userId)
        {
            return StaticDb.Rentals
                .Where(r => r.UserId == userId)
                .ToList();
        }

        public void Update(Rental rental)
        {
            var existingRental = GetById(rental.Id);
            if (existingRental != null)
            {
                existingRental.Id = rental.Id;
                existingRental.MovieId = rental.MovieId;
                existingRental.UserId = rental.UserId;
                existingRental.RentedOn = rental.RentedOn;
                existingRental.ReturnedOn = rental.ReturnedOn;
            }
            else
            {
                throw new KeyNotFoundException($"Rental with ID {rental.Id} not found.");
            
            }
        }
    }
}
