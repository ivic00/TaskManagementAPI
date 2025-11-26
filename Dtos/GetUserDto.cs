using TaskManagementAPI2.Enums;

namespace TaskManagementAPI2.Dtos
{
    public class GetUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
