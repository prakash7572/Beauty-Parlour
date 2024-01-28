namespace Beauty.Admin.Models
{
    public class Profile
    {
        public int? UserId { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? Phone { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }

    }
    public class ChangePassword
    {
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }
    }
    public class Login
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
