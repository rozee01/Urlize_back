namespace Urlize_back.Dtos
{
    public class RegisterDto
    {
        public string Firstname { get; set; }
        public string? Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmed { get; set; }
    }
}
