using System.ComponentModel.DataAnnotations;

namespace ExpensePilot.API.Models.DTO.Administration.UserManagement
{
    public class AddUserDto
    {
        [Required]
        public string Logon { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int? ManagerID { get; set; }
        [Required]
        public int? DepartmentID { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
