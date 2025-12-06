using TaskManagementAPI2.Dtos;
using TaskManagementAPI2.Dtos.TeamDtos;

namespace TaskManagementAPI2.Services.TeamService
{
    public interface ITeamService
    {
        public Task<GetTeamDto?> CreateTeam(AddTeamDto newTeam);
        public Task<GetTeamDto?> GetTeamById(int id);
        public Task<GetTeamDto> RemoveFromTeam(int teamId, int userId);
        public Task<GetTeamDto> EditTeam(int id);
        public Task<List<GetUserDto>> RemoveUser(int userId);
        public Task<bool> TeamRulesCheck(AddTeamDto newTeam);
    }
}
