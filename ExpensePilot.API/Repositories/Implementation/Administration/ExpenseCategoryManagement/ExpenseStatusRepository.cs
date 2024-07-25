using ExpensePilot.API.Data;
using ExpensePilot.API.Models.Domain.Administration.ExpenseCategoryManagement;
using ExpensePilot.API.Repositories.Interface.Administration.ExpenseCategoryManagement;
using Microsoft.EntityFrameworkCore;

namespace ExpensePilot.API.Repositories.Implementation.Administration.ExpenseCategoryManagement
{
    public class ExpenseStatusRepository : IExpenseStatusRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ExpenseStatusRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ExpenseStatus> CreateAsync(ExpenseStatus expenseStatus)
        {
            await dbContext.tblEPExpenseStatus.AddAsync(expenseStatus);
            await dbContext.SaveChangesAsync();
            return expenseStatus;
        }

        public async Task<ExpenseStatus?> DeleteAsync(int id)
        {
            var existingStatus = await dbContext.tblEPExpenseStatus.FirstOrDefaultAsync(es => es.StatusID == id);
            if (existingStatus is null)
            {
                return null;
            }
            dbContext.tblEPExpenseStatus.Remove(existingStatus);
            await dbContext.SaveChangesAsync();
            return existingStatus;
        }

        public async Task<IEnumerable<ExpenseStatus>> GetAllAsync()
        {
            return await dbContext.tblEPExpenseStatus.ToListAsync();
        }

        public async Task<ExpenseStatus?> GetByIdAsync(int id)
        {
            return await dbContext.tblEPExpenseStatus.FirstOrDefaultAsync(es => es.StatusID == id);
        }

        public async Task<ExpenseStatus?> UpdateAsync(ExpenseStatus expenseStatus)
        {
            var existingStatus = await dbContext.tblEPExpenseStatus.FirstOrDefaultAsync(es => es.StatusID == expenseStatus.StatusID);
            if (existingStatus is null)
            {
                return null;
            }
            dbContext.Entry(existingStatus).CurrentValues.SetValues(expenseStatus);
            await dbContext.SaveChangesAsync();
            return existingStatus;
        }
    }
}
