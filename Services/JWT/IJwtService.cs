using TaskManagementAPI2.Dtos;
using TaskManagementAPI2.Models;
namespace TaskManagementAPI2.Services.JWT
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
