
namespace TaskManagementAPI2.Dtos
{
    public class ChangePasswordDto
    {
        public string email { get; set; }
        public string oldPass { get; set; }
        public string newPass { get; set; }
        public string confirmNewPass { get; set; }
    }
}