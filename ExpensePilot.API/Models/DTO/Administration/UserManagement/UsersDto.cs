using ExpensePilot.API.Models.Domain;
using ExpensePilot.API.Models.DTO.Administration.DepartmentManagement;
using System.ComponentModel.DataAnnotations;

namespace ExpensePilot.API.Models.DTO.Administration.UserManagement
{
    public class UsersDto
    {

        public int ID { get; set; }
        public string Logon { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public int? ManagerID { get; set; }
        public string ManagerName { get; set; }
        public int? DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
