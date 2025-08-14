using VideoRentalOnlineStore.DataAcces.Interfaces;
using VideoRentalOnlineStore.Domain.Models;
using VideoRentalOnlineStore.Services.Interfaces;

namespace VideoRentalOnlineStore.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<User> GetAllUsers() => _userRepository.GetAll();

        public User GetUserById(int id) => _userRepository.GetById(id);

        public User GetUserByCardNumber(string cardNumber) => _userRepository.GetByCardNumber(cardNumber);

        public void AddUser(User user) => _userRepository.Add(user);

        public void UpdateUser(User user) => _userRepository.Update(user);

        public void DeleteUser(int id) => _userRepository.Delete(id);
    }
}
