using TaskManagementAPI2.Models;

namespace TaskManagementAPI2.Services.UserService
{
    public class UserService : IUserService
    {

        static List<User> users = new List<User> {
        new User { Id = 1, Email ="mudosisaj@gmail.com", Name="Idiot", Password="123", Role = Enums.Role.None},
        new User { Id = 2, Email ="dobardaaan@gmail.com", Name="Kockar", Password="123", Role = Enums.Role.Admin},
        new User { Id = 3, Email ="uhhhhh@gmail.com", Name="SHako", Password="123", Role = Enums.Role.Manager},
        };

        public Task<ServiceResponse<User>> AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> DeleteUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<User>>> GetAllUsersAsync()
        {
            ServiceResponse<List<User>> serviceResponse = new ServiceResponse<List<User>>();
            serviceResponse.Data = users;
            serviceResponse.Message = "All users retrieved";

            return serviceResponse;
        }

        public async Task<User?> GetUserById(int id)
            => users.FirstOrDefault(u => u.Id == id);
    }
}
