using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI2.Dtos.TeamDtos;
using TaskManagementAPI2.Services.TeamService;

namespace TaskManagementAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        public readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost("CreateTeam")]
        public async Task<ActionResult<Task<GetTeamDto>>> CreateTeam(AddTeamDto newTeam)
        {
            var team = await _teamService.CreateTeam(newTeam);

            if (team is not null)
            {
                return Ok(team);
            }
            else return BadRequest("Team exists kinda");
        }

        [HttpGet]
        public async Task<ActionResult> GetTeamById(int id)
        {
            var team = await _teamService.GetTeamById(id);
            if (team is not null) { return Ok(team); }
            else return BadRequest($"Team does not exist with id: {id}");
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult<Task<bool>>> RemoveFromTeam(int userId)
        {
            var res = await _teamService.RemoveFromTeam(userId);

            if (!res) return NotFound(new { message = "User not found or doesn't have team" });

            return Ok(new { message = "User removed from team" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Task<GetTeamDto?>>> EditTeam(int id, [FromBody] UpdateTeamDto newTeam)
        {
            var res = await _teamService.EditTeam(id, newTeam);

            if (res is null) return BadRequest(new { message = "team does not exist" });

            return Ok(res);
        }
    }
}
