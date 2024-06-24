using ExpensePilot.API.Models.DTO.Administration.UserManagement;

namespace ExpensePilot.API.Models.DTO.Administration.RoleAccessManagement
{
    public class AddUserAccessDto
    {
        public int UserID { get; set; }
        public int UserRoleID { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
