using ExpensePilot.API.Data;
using ExpensePilot.API.Models.Domain.Administration.RoleAccessManagement;
using ExpensePilot.API.Models.DTO.Administration.RoleAccessManagement;
using ExpensePilot.API.Repositories.Interface.Administration.RoleAccessManagement;
using Microsoft.EntityFrameworkCore;

namespace ExpensePilot.API.Repositories.Implementation.Administration.RoleAccessManagement
{
    public class UserAccessRepository : IUserAccessRepository
    {
        private readonly ApplicationDbContext dbContext;

        public UserAccessRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<UserAccess> CreateAsync(UserAccess userAccess)
        {
            await dbContext.tblEPUserAccess.AddAsync(userAccess);
            await dbContext.SaveChangesAsync();
            return userAccess;
        }

        public async Task<UserAccess> DeleteAsync(int id)
        {
            var existingAccess = await dbContext.tblEPUserAccess.FirstOrDefaultAsync(us => us.UserAccessID == id);
            if(existingAccess is null)
            {
                return null;
            }
            dbContext.tblEPUserAccess.Remove(existingAccess);
            await dbContext.SaveChangesAsync();
            return existingAccess;
        }

        public async Task<IEnumerable<UserAccess>> GetAllAsync()
        {
            return await dbContext.tblEPUserAccess
               .Include(ua => ua.User)
               .Include(ua => ua.UserRole).ToListAsync();
        }

        public async Task<UserAccess> UpdateAsync(UserAccess userAccess)
        {
            var existingAccess = await dbContext.tblEPUserAccess.FirstOrDefaultAsync(us => us.UserAccessID == userAccess.UserAccessID);
            if(existingAccess is null)
            {
                return null;
            }
            dbContext.Entry(existingAccess).CurrentValues.SetValues(userAccess);
            await dbContext.SaveChangesAsync();
            return existingAccess;
        }
    }
}
