using VideoRentalOnlineStore.Domain.Models;

namespace VideoRentalOnlineStore.DataAcces.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        User GetByCardNumber(string cardNumber);
        void Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}
