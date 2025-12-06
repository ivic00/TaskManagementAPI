using TaskManagementAPI2.Models;

namespace TaskManagementAPI2.Dtos.TeamDtos
{
    public class AddTeamDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> MemberIds { get; set; } = new List<int>();
    }
}
