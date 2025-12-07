using TaskManagementAPI2.Enums;

namespace TaskManagementAPI2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
    }
}
