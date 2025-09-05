using System.Data;
using System.Text.RegularExpressions;
using NotesApp.DTOs;
using NotesApp.Helpers;
using NotesApp.Services.Interfaces;

namespace NotesApp.Services.Implementation
{
    public class UserService : IUserService
    {
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

        }
    }
}
