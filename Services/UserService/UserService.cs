using Microsoft.EntityFrameworkCore;
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

        public async Task<GetUserDto?> AddUserAsync(AddUserDto newUser)
        {

            if (await UserExists(newUser.Name))
            {
                return null;
            }

            else
            {
                User user = new User
                {
                    Email = newUser.Email,
                    Name = newUser.Name,
                    Role = newUser.Role,
                    Password = newUser.Password
                };
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();

                return (await GetUserByName(user.Name));
            }

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
