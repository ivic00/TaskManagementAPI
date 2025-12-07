using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI2.Data;
using TaskManagementAPI2.Dtos;
using TaskManagementAPI2.Models;

namespace TaskManagementAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }


        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser([FromBody] AddUserDto newUser)
        {
            var user = await _authRepository.Register(newUser);

            return user is null ? BadRequest("User already exists.") : Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<GetUserDto?>> LoginUser([FromBody] LoginUserDto request)
        {
            var res = await _authRepository.Login(request.Email, request.Password);

            if (res is null) return BadRequest(new { message = "Wrong email or password" });

            return Ok(res);
        }

    }
}
