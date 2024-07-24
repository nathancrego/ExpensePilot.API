using System.ComponentModel.DataAnnotations;

namespace ExpensePilot.API.Models.DTO.Administration.ExpenseCategoryManagement
{
    public class EditExpenseCategoryDto
    {
        [Required]
        public string CategoryName { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
