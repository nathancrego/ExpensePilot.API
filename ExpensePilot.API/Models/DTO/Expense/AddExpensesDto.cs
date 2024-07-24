namespace ExpensePilot.API.Models.DTO.Expense
{
    public class AddExpensesDto
    {
        public string ExpenseName { get; set; }
        public string ExpenseDescription { get; set; }
        public int ExpenseCategoryID { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceVendorName { get; set; }
        public double TotalAmount { get; set; }
        public int UserID { get; set; }
    }
}
