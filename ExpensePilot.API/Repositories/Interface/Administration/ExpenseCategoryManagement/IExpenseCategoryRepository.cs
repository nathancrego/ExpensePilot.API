using ExpensePilot.API.Models.Domain.Administration.ExpenseCategoryManagement;

namespace ExpensePilot.API.Repositories.Interface.Administration.ExpenseCategoryManagement
{
    public interface IExpenseCategoryRepository
    {
        Task<ExpenseCategory> CreateAsync(ExpenseCategory expenseCategory);
        Task<IEnumerable<ExpenseCategory>> GetAllAsync();
        Task<ExpenseCategory?> GetByIdAsync(int id);
        Task<ExpenseCategory?> UpdateAsync(ExpenseCategory expenseCategory);
        Task<ExpenseCategory?> DeleteAsync(int id);
    }
}
