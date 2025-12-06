using TaskManagementAPI2.Dtos;

namespace TaskManagementAPI2.Data
{
    public interface IAuthRepository
    {
        public Task<GetUserDto?> Register(AddUserDto newUser);
        public Task<bool> UserExists(string name);
    }
}
