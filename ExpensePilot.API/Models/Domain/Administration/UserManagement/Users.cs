using System.ComponentModel.DataAnnotations;
using ExpensePilot.API.Models.Domain.Administration.DepartmentManagement;
using ExpensePilot.API.Models.Domain.Administration.RoleAccessManagement;

namespace ExpensePilot.API.Models.Domain.Administration.UserManagement
{
    public class Users
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Logon { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public int? ManagerID { get; set; }
        public int? DepartmentID { get; set; }
        
        public DateTime LastUpdated { get; set; }
        //navigation properties
        public Department Department { get; set; }

        public ICollection<UserAccess> tblEPUserAccess { get; set; }
        public Login Login { get; set; }


    }
}
