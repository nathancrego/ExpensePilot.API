namespace ExpensePilot.API.Models.DTO.Administration.UserManagement
{
    public class LoginDto
    {
        public string Logon { get; set; }
        public string Password { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
