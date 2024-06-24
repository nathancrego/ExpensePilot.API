using System.ComponentModel.DataAnnotations;

namespace ExpensePilot.API.Models.Domain.Administration.RoleAccessManagement
{
    public class UserRoles
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Role { get; set; }
        public DateTime LastUpdated { get; set; }

        public ICollection<UserAccess> tblEPUserAccess { get; set; }

    }
}
