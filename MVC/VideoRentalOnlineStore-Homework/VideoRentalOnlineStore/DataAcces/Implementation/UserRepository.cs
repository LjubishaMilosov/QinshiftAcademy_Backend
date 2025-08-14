using VideoRentalOnlineStore.DataAcces.Interfaces;
using VideoRentalOnlineStore.Domain.Models;

namespace VideoRentalOnlineStore.DataAcces.Implementation
{
    internal class UserRepository : IUserRepository
    {
        public void Add(User user)
        {
            StaticDb.Users.Add(user);
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                StaticDb.Users.Remove(user);
            }
        }

        public List<User> GetAll()
        {
            return StaticDb.Users;
        }

        public User GetByCardNumber(string cardNumber)
        {
            return StaticDb.Users.FirstOrDefault(u => u.CardNumber == cardNumber);
        }

        public User GetById(int id)
        {
            return StaticDb.Users.FirstOrDefault(u => u.Id == id)
                ?? throw new KeyNotFoundException($"User with ID {id} not found."); ;
        }

        public void Update(User user)
        {
            var existing = GetById(user.Id);
            if (existing != null)
            {
                existing.Id = user.Id;
                existing.FullName = user.FullName;
                existing.Age = user.Age;
                existing.CardNumber = user.CardNumber;
                existing.CreatedOn = user.CreatedOn;
                existing.IsSubscriptionExpired = user.IsSubscriptionExpired;
            }
            else
            {
                throw new KeyNotFoundException($"User with ID {user.Id} not found.");

            }
        }
    }
}
