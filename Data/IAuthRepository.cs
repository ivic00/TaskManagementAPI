using TaskManagementAPI2.Dtos;

namespace TaskManagementAPI2.Data
{
    public interface IAuthRepository
    {
        public Task<GetUserDto?> Register(AddUserDto newUser);
        public Task<string?> Login(string email, string password);
        //public Task<bool?> ChangePassword(string email, string password, string confirmPassword);
        public Task<bool> UserExists(string name);
    }
}
