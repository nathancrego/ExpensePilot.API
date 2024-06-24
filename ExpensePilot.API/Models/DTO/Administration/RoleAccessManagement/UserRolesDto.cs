using System.ComponentModel.DataAnnotations;

namespace ExpensePilot.API.Models.DTO.Administration.RoleAccessManagement
{
    public class UserRolesDto
    {
        public int ID { get; set; }
        public string Role { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
