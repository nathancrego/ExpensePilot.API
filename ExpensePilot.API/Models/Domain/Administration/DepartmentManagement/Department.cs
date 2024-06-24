using ExpensePilot.API.Models.Domain.Administration.UserManagement;
using System.ComponentModel.DataAnnotations;

namespace ExpensePilot.API.Models.Domain.Administration.DepartmentManagement
{
    public class Department
    {
        [Key]
        public int DptID { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        public DateTime LastUpdated { get; set; }
        public ICollection<Users> tblEPUsers { get; set; }

    }
}
