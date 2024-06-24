using ExpensePilot.API.Data;
using ExpensePilot.API.Models.Domain.Administration.UserManagement;
using ExpensePilot.API.Repositories.Interface.Administration.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace ExpensePilot.API.Repositories.Implementation.Administration.UserManagement
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext dbContext;

        public UsersRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Users> CreateUserAsync(Users users)
        {
            await dbContext.tblEPUsers.AddAsync(users);
            await dbContext.SaveChangesAsync();
            return users;
        }

        public async Task<Users?> DeleteUserAsync(int id)
        {
            var existingUser = await dbContext.tblEPUsers.FirstOrDefaultAsync(u => u.ID == id);
            if (existingUser is null)
            {
                return null;
            }
            dbContext.tblEPUsers.Remove(existingUser);
            await dbContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await dbContext.tblEPUsers.ToListAsync();
        }

        public async Task<Users?> GetByIdAsync(int id)
        {
            return await dbContext.tblEPUsers.FirstOrDefaultAsync(u => u.ID == id);
        }

        public async Task<Users?> UpdateUserAsync(Users users)
        {
            var existingUser = await dbContext.tblEPUsers.FirstOrDefaultAsync(u => u.ID == users.ID);
            if (existingUser is null)
            {
                return null;
            }
            dbContext.Entry(existingUser).CurrentValues.SetValues(users);
            await dbContext.SaveChangesAsync();
            return users;
        }
    }
}
