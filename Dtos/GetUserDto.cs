using TaskManagementAPI2.Enums;

namespace TaskManagementAPI2.Dtos
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
