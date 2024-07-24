using System.ComponentModel.DataAnnotations;
using ExpensePilot.API.Models.Domain.Expense;

namespace ExpensePilot.API.Models.Domain.Administration.ExpenseCategoryManagement
{
    public class ExpenseCategory
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public DateTime LastUpdated { get; set; }

        //Navigation property
        public ICollection<Expenses> tblEPExpenses { get; set; }
    }
}
