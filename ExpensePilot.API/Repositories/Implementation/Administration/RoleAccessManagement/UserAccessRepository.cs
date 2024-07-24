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
            await dbContext.Entry(userAccess).Reference(u => u.User).LoadAsync();
            await dbContext.Entry(userAccess).Reference(ur => ur.UserRole).LoadAsync();
            return userAccess;
        }

        public async Task<UserAccess?> DeleteAsync(int id)
        {
            var existingAccess = await dbContext.tblEPUserAccess.Include(u => u.User).Include(ur => ur.UserRole).FirstOrDefaultAsync(us => us.UserAccessID == id);
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
               .Include(u => u.User)
               .Include(ur => ur.UserRole).ToListAsync();
        }

        public async Task<UserAccess?> GetAccessByIDAsync(int id)
        {
            return await dbContext.tblEPUserAccess.Include(u=>u.User).Include(ur=>ur.UserRole).FirstOrDefaultAsync(ua => ua.UserAccessID == id);
        }

        public async Task<UserAccess?> UpdateAsync(UserAccess userAccess)
        {
            var existingAccess = await dbContext.tblEPUserAccess.Include(u => u.User).Include(ur => ur.UserRole).FirstOrDefaultAsync(us => us.UserAccessID == userAccess.UserAccessID);
            if(existingAccess is null)
            {
                return null;
            }
            dbContext.Entry(existingAccess).CurrentValues.SetValues(userAccess);
            await dbContext.SaveChangesAsync();
            await dbContext.Entry(existingAccess).Reference(u => u.User).LoadAsync();
            await dbContext.Entry(existingAccess).Reference(ur => ur.UserRole).LoadAsync();
            return existingAccess;
        }
    }
}
