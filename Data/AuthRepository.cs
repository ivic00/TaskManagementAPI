using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI2.Dtos;
using TaskManagementAPI2.Models;
using TaskManagementAPI2.Services.JWT;


namespace TaskManagementAPI2.Data
{
    public class AuthRepository : IAuthRepository
    {
        public readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public AuthRepository(AppDbContext context, IMapper mapper, IJwtService jwtService)
        {
            _context = context;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<GetUserDto?> Register(AddUserDto newUser)
        {
            if (await UserExists(newUser.Name)) return null;

            var passwordHasher = new PasswordHasher<User>();
            await _context.Users
                .AddAsync(new User
                {
                    Email = newUser.Email,
                    Name = newUser.Name,
                    PasswordHash = passwordHasher.HashPassword(null, newUser.Password),
                    Role = newUser.Role,
                });

            await _context.SaveChangesAsync();

            User res = await _context.Users.FirstOrDefaultAsync(x => x.Name == newUser.Name);

            return _mapper.Map<GetUserDto>(res);

        }
        public async Task<bool> UserExists(string name)
        {
            if (await _context.Users.AnyAsync(x => x.Name.ToLower() == name.ToLower()))
                return true;
            else return false;

        }

        public async Task<string?> Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return null;

            var passwordHasher = new PasswordHasher<User>();

            var res = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

            if (res == PasswordVerificationResult.Success)
                return _jwtService.GenerateToken(user);

            return null;
        }

        /*public async Task<bool?> ChangePassword(string email, string password, string confirmPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return null;

            if(password == confirmPassword)
            {
                var passwordHasher = new PasswordHasher<User>();

                var hashRes = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

                if (hashRes == PasswordVerificationResult.Success) return true;

                else return false;
            }
        }*/
    }
}
