namespace ExpensePilot.API.Models.DTO.Administration.UserManagement
{
    public class RegisterDto
    {
        public string Logon { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
