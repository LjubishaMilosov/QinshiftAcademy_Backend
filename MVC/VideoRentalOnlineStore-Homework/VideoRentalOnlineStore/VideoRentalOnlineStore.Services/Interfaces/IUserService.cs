using VideoRentalOnlineStore.Domain.Models;

namespace VideoRentalOnlineStore.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByCardNumber(string cardNumber);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
