using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI2.Data;
using TaskManagementAPI2.Dtos;
using TaskManagementAPI2.Dtos.TeamDtos;
using TaskManagementAPI2.Models;

namespace TaskManagementAPI2.Services.TeamService
{
    public class TeamService : ITeamService
    {
        public readonly IMapper _mapper;
        public readonly AppDbContext _context;

        public TeamService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<GetTeamDto?> CreateTeam(AddTeamDto newTeam)
        {
            if (await TeamRulesCheck(newTeam))
            {
                var members = await _context.Users
                .Where(u => newTeam.MemberIds.Contains(u.Id)).ToListAsync();

                var team = new Team
                {
                    Name = newTeam.Name,
                    Description = newTeam.Description,
                    Members = members
                };

                await _context.Teams.AddAsync(team);
                await _context.SaveChangesAsync();
                return _mapper.Map<GetTeamDto>(team);

            }
            else return null;

        }

        public async Task<GetTeamDto?> GetTeamById(int id)
        {
            var team = await _context.Teams
                .Where(x => x.Id == id)
                .Select(x => new GetTeamDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Members = x.Members.Select(u => _mapper.Map<GetUserDto>(u)).ToList()
                }).FirstOrDefaultAsync();

            if (team is not null) return team;
            else return null;
        }

        public async Task<bool> RemoveFromTeam(int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user is null) return false;

            user.Team = null;
            int? teamId = user.TeamId;
            user.TeamId = null;

            await _context.SaveChangesAsync();

            if (teamId is null) return false;

            return true;
        }

        public async Task<bool> TeamRulesCheck(AddTeamDto newTeam)
        {
            if (await _context.Teams
                .Where(t => t.Name.ToLower() == newTeam.Name.ToLower() || newTeam.MemberIds.Contains(t.Id)).AnyAsync())
                return false;
            else return true;
        }

        public async Task<GetTeamDto?> EditTeam(int id, UpdateTeamDto updatedTeam)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);

            if (team is null) return null;

            team.Name = updatedTeam.Name;
            team.Description = updatedTeam.Description;

            await _context.SaveChangesAsync();

            return _mapper.Map<GetTeamDto>(team);
        }
    }
}
