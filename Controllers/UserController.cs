using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI2.Data;
using TaskManagementAPI2.Dtos;
using TaskManagementAPI2.Models;
using TaskManagementAPI2.Services.UserService;

namespace TaskManagementAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthRepository _authRepository;


        public UserController(IUserService userService, IAuthRepository authRepository)
        {
            _userService = userService;
            _authRepository = authRepository;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<GetUserDto>>> GetAllUsers()
            => Ok(await _userService.GetAllUsersAsync());

        [HttpGet("GetUsersById")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);

            return user is null ? NotFound("User does not exist.") : Ok(user);

        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult<User>> RegisterUser(AddUserDto newUser)
        {
            var user = await _authRepository.Register(newUser);

            return user is null ? BadRequest("User already exists.") : Ok(user);
        }
    }
}
