using System.ComponentModel.DataAnnotations;

namespace ExpensePilot.API.Models.DTO.Administration.DepartmentManagement
{
    public class EditDepartmentDto
    {
        [Required]
        public string DepartmentName { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
