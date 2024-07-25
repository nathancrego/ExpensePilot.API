using System.ComponentModel.DataAnnotations;

namespace ExpensePilot.API.Models.Domain.Expense
{
    public class InvoiceReceipt
    {
        [Key]
        public int ReceiptID { get; set; }
        public string? ReceiptName { get; set; }
        public string? FileExtension { get; set; }
        public string? FilePath { get; set; }
        public string? UrlPath { get; set; }
        public DateTime LastUpdated { get; set; }

        //Navigationproperty
        public Expenses Expense { get; set; }
    }
}
