using TaskManagementAPI2.Dtos;
using TaskManagementAPI2.Models;

namespace TaskManagementAPI2.Services.UserService
{
    public interface IUserService
    {
        Task<List<GetUserDto>> GetAllUsersAsync();
        Task<GetUserDto?> GetUserById(int id);
        Task<GetUserDto?> AddUserAsync(AddUserDto newUser);
        Task<GetUserDto?> GetUserByName(string name);
        Task<ServiceResponse<bool>> DeleteUserAsync(User user);
    }
}
