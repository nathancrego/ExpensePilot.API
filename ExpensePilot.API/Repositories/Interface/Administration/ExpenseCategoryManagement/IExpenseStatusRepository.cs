using ExpensePilot.API.Models.Domain.Administration.ExpenseCategoryManagement;

namespace ExpensePilot.API.Repositories.Interface.Administration.ExpenseCategoryManagement
{
    public interface IExpenseStatusRepository
    {
        Task<ExpenseStatus> CreateAsync(ExpenseStatus expenseStatus);
        Task<IEnumerable<ExpenseStatus>> GetAllAsync();
        Task<ExpenseStatus?> GetByIdAsync(int id);
        Task<ExpenseStatus?> UpdateAsync(ExpenseStatus expenseStatus);
        Task<ExpenseStatus?> DeleteAsync(int id);
    }
}
