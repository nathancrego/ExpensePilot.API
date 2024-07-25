using ExpensePilot.API.Models.Domain.Expense;
using System.ComponentModel.DataAnnotations;

namespace ExpensePilot.API.Models.Domain.Administration.ExpenseCategoryManagement
{
    public class ExpenseStatus
    {
        [Key]
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public DateTime LastUpdated { get; set; }

        //Navigation property
        public ICollection<Expenses> tblEPExpenses { get; set; }

    }
}
