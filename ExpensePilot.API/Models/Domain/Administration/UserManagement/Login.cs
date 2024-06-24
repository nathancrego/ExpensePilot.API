using System.ComponentModel.DataAnnotations;

namespace ExpensePilot.API.Models.Domain.Administration.UserManagement
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        public string HashedPassword { get; set; }
        public DateTime LastUpdated { get; set; }
        public int UserID { get; set; }

        public Users User { get; set; }
    }
}
