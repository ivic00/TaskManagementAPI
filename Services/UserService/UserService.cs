using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using TaskManagementAPI2.Data;
using TaskManagementAPI2.Dtos;
using TaskManagementAPI2.Models;

namespace TaskManagementAPI2.Services.UserService
{
    public class UserService : IUserService
    {
        public readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public Task<ServiceResponse<bool>> DeleteUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetUserDto>> GetAllUsersAsync()
             => await _context.Users.Select(u => new GetUserDto
             {
                 Name = u.Name,
                 Email = u.Email,
                 Role = u.Role
             }).ToListAsync();

        public async Task<GetUserDto?> GetUserById(int id)
            => await _context.Users
            .Where(u => u.Id == id)
            .Select(u => new GetUserDto
            {
                Name = u.Name,
                Email = u.Email,
                Role = u.Role
            }).FirstOrDefaultAsync();

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string name)
        {
            var res = await _context.Users.AnyAsync(x => x.Name.ToLower() == name.ToLower());
            if (res)
            {
                return true;
            }
            else return false;
        }

        public async Task<GetUserDto?> GetUserByName(string name)
            => await _context.Users
            .Where(u => u.Name == name)
            .Select(u => new GetUserDto
            {
                Name = u.Name,
                Email = u.Email,
                Role = u.Role
            }).FirstOrDefaultAsync();
    }
}
