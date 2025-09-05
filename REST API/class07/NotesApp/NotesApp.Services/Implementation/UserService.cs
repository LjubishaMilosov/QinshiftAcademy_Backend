using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using NotesApp.DataAccess.Interfaces;
using NotesApp.Domain.Models;
using NotesApp.DTOs;
using NotesApp.Helpers;
using NotesApp.Services.Interfaces;

namespace NotesApp.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public void RegisterUser(RegisterUserDto registerUserDto)
        {
            if(registerUserDto == null)
            {
                throw new DataException(nameof(registerUserDto));
            }
            ValidationHelper.ValidateRequiredStringColumnLength(registerUserDto.FirstName, "First Name", 50);
            ValidationHelper.ValidateColumnLength(registerUserDto.LastName, "Last Name", 50);
            ValidationHelper.ValidateRequiredStringColumnLength(registerUserDto.Username, "Username", 20);

            if(string.IsNullOrEmpty(registerUserDto.Password) || string.IsNullOrEmpty(registerUserDto.ConfirmPassword))
            {
                throw new DataException("Password and Confirm Password are required.");
            }
            if(registerUserDto.Password != registerUserDto.ConfirmPassword)
            {
                throw new DataException("Password and Confirm Password do not match.");
            }

            string strongPasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

            if(Regex.IsMatch(registerUserDto.Password, strongPasswordRegex))
            {
                throw new DataException("Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number and one special character.");
            }

            //if(_userRepository.GetAll().Any(u => u.Username == registerUserDto.Username))  // not case sensitive
            if (_userRepository.GetAll().Any(x => string.Equals(x.Username, registerUserDto.Username, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new DataException($"Username {registerUserDto.Username} is already taken.");
            }

            var user = new User
            {
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                Username = registerUserDto.Username,
                Password = GenerateHash(registerUserDto.Password) // in a real app, the password should be hashed and salted
            };

            _userRepository.Add(user);
        }

        private string GenerateHash(string password)
        {
            // implement a hashing algorithm here
            using (var md5Hash = MD5.Create())
            {
                {
                    var passwordBytes = Encoding.ASCII.GetBytes(password);
                    var hashedBytes = md5Hash.ComputeHash(passwordBytes);
                    var hashed = Encoding.ASCII.GetString(hashedBytes);

                    return hashed;
                }
            }
        }
    }
}
