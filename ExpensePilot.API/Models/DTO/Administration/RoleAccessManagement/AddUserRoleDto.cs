using System.ComponentModel.DataAnnotations;

namespace ExpensePilot.API.Models.DTO.Administration.RoleAccessManagement
{
    public class AddUserRoleDto
    {
        [Required]
        public string Role { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
