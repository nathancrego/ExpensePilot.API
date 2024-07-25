using ExpensePilot.API.Models.Domain.Administration.ExpenseCategoryManagement;
using ExpensePilot.API.Models.Domain.Administration.UserManagement;
using System.ComponentModel.DataAnnotations;

namespace ExpensePilot.API.Models.Domain.Expense
{
    public class Expenses
    {
        [Key]
        public int ExpenseID { get; set; }
        [Required]
        public string ExpenseName { get; set;}
        public string ExpenseDescription { get; set;}
        public int ExpenseCategoryID { get; set; }
        [Required]
        public string InvoiceNumber { get; set;}
        public string InvoiceVendorName { get; set;}
        public double TotalAmount { get; set; }
        public int InvoiceReceiptID { get; set; }
        public int UserID { get; set; }
        public int ExpenseStatusID { get; set; }

        //Navigation property
        public ExpenseCategory ExpenseCategory { get; set; }
        public ExpenseStatus ExpenseStatus { get; set; }
        public InvoiceReceipt InvoiceReceipt { get; set; }
        public Users User { get; set; }
    }
}
