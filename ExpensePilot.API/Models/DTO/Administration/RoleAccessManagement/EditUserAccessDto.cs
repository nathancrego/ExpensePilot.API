using System.ComponentModel.DataAnnotations;

namespace ExpensePilot.API.Models.DTO.Administration.RoleAccessManagement
{
    public class EditUserAccessDto
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public int UserRoleID { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
