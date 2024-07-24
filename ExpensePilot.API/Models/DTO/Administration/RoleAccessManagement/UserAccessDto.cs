using ExpensePilot.API.Models.Domain.Administration.RoleAccessManagement;
using ExpensePilot.API.Models.Domain.Administration.UserManagement;
using ExpensePilot.API.Models.DTO.Administration.UserManagement;

namespace ExpensePilot.API.Models.DTO.Administration.RoleAccessManagement
{
    public class UserAccessDto
    {
        public int UserAccessID { get; set; }
        public int UserID { get; set; }
        public int? UserRoleID { get; set; }
        public string Logon {  get; set; }
        public string? Role {  get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
