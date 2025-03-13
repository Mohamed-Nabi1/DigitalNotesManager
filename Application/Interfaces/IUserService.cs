using DigitalNotesManager.Application.DTOs;
using DigitalNotesManager.Application.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DigitalNotesManager.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO?> GetUserByIdAsync(int id);
        Task AddUserAsync(UserDTO userDto);
        Task UpdateUserAsync(UserDTO userDto);
        Task DeleteUserAsync(int id);
        Task<bool> RegisterUserAsync(UserDTO userDto);


        Task<bool> AuthenticateUserAsync(string email, string password);
        
    }
}
