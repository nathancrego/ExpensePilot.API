using System.ComponentModel.DataAnnotations;

namespace ExpensePilot.API.Models.DTO.Administration.ExpenseCategoryManagement
{
    public class AddExpenseCategoryDto
    {
        [Required]
        public string CategoryName { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
