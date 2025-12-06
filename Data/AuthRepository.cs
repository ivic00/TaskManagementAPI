using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI2.Dtos;
using TaskManagementAPI2.Models;


namespace TaskManagementAPI2.Data
{
    public class AuthRepository : IAuthRepository
    {
        public readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AuthRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetUserDto?> Register(AddUserDto newUser)
        {
            if (await UserExists(newUser.Name))
            {
                return null;
            }
            else
            {
                await _context.Users
                    .AddAsync(new User
                    {
                        Email = newUser.Email,
                        Name = newUser.Name,
                        Password = newUser.Password,
                        Role = newUser.Role,
                    });
                await _context.SaveChangesAsync();

                User res = _context.Users.FirstOrDefault(x => x.Name == newUser.Name);

                return _mapper.Map<GetUserDto>(res);
            }
        }
        public async Task<bool> UserExists(string name)
        {
            if (await _context.Users.AnyAsync(x => x.Name.ToLower() == name.ToLower()))
                return true;
            else return false;

        }
    }
}
