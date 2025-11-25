using TaskManagementAPI2.Models;

namespace TaskManagementAPI2.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<User>>> GetAllUsersAsync();
        Task<User?> GetUserById(int id);
        Task<ServiceResponse<User>> AddUserAsync(User user);
        Task<ServiceResponse<bool>> DeleteUserAsync(User user);
    }
}
