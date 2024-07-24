using ExpensePilot.API.Data;
using ExpensePilot.API.Models.Domain.Administration.ExpenseCategoryManagement;
using ExpensePilot.API.Repositories.Interface.Administration.ExpenseCategoryManagement;
using Microsoft.EntityFrameworkCore;

namespace ExpensePilot.API.Repositories.Implementation.Administration.ExpenseCategoryManagement
{
    public class ExpenseCategoryRepository : IExpenseCategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ExpenseCategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ExpenseCategory> CreateAsync(ExpenseCategory expenseCategory)
        {
            await dbContext.tblEPExpenseCategory.AddAsync(expenseCategory);
            await dbContext.SaveChangesAsync();
            return expenseCategory;
        }

        public async Task<ExpenseCategory?> DeleteAsync(int id)
        {
            var existingCategory = await dbContext.tblEPExpenseCategory.FirstOrDefaultAsync(ec => ec.CategoryID == id);
            if (existingCategory is null)
            {
                return null;
            }
            dbContext.tblEPExpenseCategory.Remove(existingCategory);
            await dbContext.SaveChangesAsync();
            return existingCategory;
        }

        public async Task<IEnumerable<ExpenseCategory>> GetAllAsync()
        {
            return await dbContext.tblEPExpenseCategory.ToListAsync();
        }

        public async Task<ExpenseCategory?> GetByIdAsync(int id)
        {
            return await dbContext.tblEPExpenseCategory.FirstOrDefaultAsync(ec => ec.CategoryID == id);
        }

        public async Task<ExpenseCategory?> UpdateAsync(ExpenseCategory expenseCategory)
        {
            var existingCategory = await dbContext.tblEPExpenseCategory.FirstOrDefaultAsync(ec => ec.CategoryID == expenseCategory.CategoryID);
            if (existingCategory is null)
            {
                return null;
            }
            dbContext.Entry(existingCategory).CurrentValues.SetValues(expenseCategory);
            await dbContext.SaveChangesAsync();
            return existingCategory;
        }
    }
}
