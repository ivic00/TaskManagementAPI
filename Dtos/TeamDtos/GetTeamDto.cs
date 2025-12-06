using TaskManagementAPI2.Models;

namespace TaskManagementAPI2.Dtos.TeamDtos
{
    public class GetTeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<GetUserDto> Members { get; set; }
    }
}
