using TaskManagementAPI2.Dtos.TeamDtos;

namespace TaskManagementAPI2.Services.TeamService
{
    public interface ITeamService
    {
        public Task<GetTeamDto?> CreateTeam(AddTeamDto newTeam);
        public Task<GetTeamDto?> GetTeamById(int id);
        public Task<bool> RemoveFromTeam(int userId);
        public Task<GetTeamDto?> EditTeam(int teamId, UpdateTeamDto updatedTeam);
        public Task<bool> TeamRulesCheck(AddTeamDto newTeam);
    }
}
