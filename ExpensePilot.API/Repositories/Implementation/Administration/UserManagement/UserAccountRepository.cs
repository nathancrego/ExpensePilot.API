using ExpensePilot.API.Data;
using ExpensePilot.API.Models.Domain.Administration.UserManagement;
using ExpensePilot.API.Repositories.Interface.Administration.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace ExpensePilot.API.Repositories.Implementation.Administration.UserManagement
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly ApplicationDbContext dbContext;

        public UserAccountRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Login> GetLoginByUserIdAsync(int userId)
        {
            return await dbContext.tblEPLogin.FirstOrDefaultAsync(l => l.UserID == userId);
        }

        public async Task<Users> GetUserByEmailAsync(string email)
        {
            return await dbContext.tblEPUsers.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
