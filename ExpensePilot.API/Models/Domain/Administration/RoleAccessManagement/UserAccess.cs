using System.ComponentModel.DataAnnotations;
using ExpensePilot.API.Models.Domain.Administration.UserManagement;

namespace ExpensePilot.API.Models.Domain.Administration.RoleAccessManagement
{
    public class UserAccess
    {
        [Key]
        public int UserAccessID { get; set; }
        public int UserID { get; set; }
        public int UserRoleID { get; set; }
        public DateTime LastUpdated { get; set; }
        //navigation properties
        public Users User { get; set; }
        public UserRoles UserRole { get; set; }

    }
}
