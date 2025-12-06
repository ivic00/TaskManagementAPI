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
        public async Task<ActionResult<Task<GetTeamDto>>> GetTeamById(int id)
        {
            var team = await _teamService.GetTeamById(id);
            if (team is not null) { return Ok(team); }
            else return BadRequest($"Team does not exist with id: {id}");
        }
    }
}
