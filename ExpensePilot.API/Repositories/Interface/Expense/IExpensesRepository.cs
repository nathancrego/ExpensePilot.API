using ExpensePilot.API.Models.Domain.Expense;
using ExpensePilot.API.Models.DTO.Expense;

namespace ExpensePilot.API.Repositories.Interface.Expense
{
    public interface IExpensesRepository
    {
        Task<Expenses> CreateAsync(Expenses expenses, InvoiceReceiptUploadDto invoiceReceiptUpload);
        Task<IEnumerable<Expenses>> GetAllAsync ();
        Task<Expenses?> UpdateAsync (Expenses updatedExpenses, InvoiceReceiptUploadDto invoiceReceiptUpload);
        Task<Expenses?> DeleteAsync (int id);
    }
}
