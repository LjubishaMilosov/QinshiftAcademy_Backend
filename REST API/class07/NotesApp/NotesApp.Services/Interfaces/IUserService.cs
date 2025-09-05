using NotesApp.DTOs;

namespace NotesApp.Services.Interfaces
{
    internal interface IUserService
    {
        void RegisterUser(RegisterUserDto register);
    }
}
