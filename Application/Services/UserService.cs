using DigitalNotesManager.Application.DTOs;
using DigitalNotesManager.Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalNotesManager.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            return await _context.Users
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    Password = u.Password,
                })
                .ToListAsync();
        }

        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
            };
        }

        public async Task AddUserAsync(UserDTO userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                Password = userDto.Password,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserDTO userDto)
        {
            var user = await _context.Users.FindAsync(userDto.Id);
            if (user == null) return;

            user.Username = userDto.Username;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
