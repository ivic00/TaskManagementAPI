using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagementAPI2.Data;
using TaskManagementAPI2.Dtos;
using TaskManagementAPI2.Models;
using TaskManagementAPI2.Services.UserService;

namespace TaskManagementAPI2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService, IAuthRepository authRepository)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<GetUserDto>>> GetAllUsers()
            => Ok(await _userService.GetAllUsersAsync());

        [HttpGet("GetUsersById")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);

            return user is null ? NotFound("User does not exist.") : Ok(user);

        }
        [HttpGet("GetUser")]
        public async Task<ActionResult<GetUserDto>> GetUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId is null) return BadRequest(new { message = "Something went wrong" });

            return Ok(await _userService.GetUser(int.Parse(userId)));
        }
    }
}
