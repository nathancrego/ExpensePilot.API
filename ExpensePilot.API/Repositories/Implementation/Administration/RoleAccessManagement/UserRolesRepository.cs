using ExpensePilot.API.Data;
using ExpensePilot.API.Models.Domain.Administration.RoleAccessManagement;
using ExpensePilot.API.Repositories.Interface.Administration.RoleAccessManagement;
using Microsoft.EntityFrameworkCore;

namespace ExpensePilot.API.Repositories.Implementation.Administration.RoleAccessManagement
{
    public class UserRolesRepository : IUserRolesRepository
    {
        private readonly ApplicationDbContext dbContext;

        public UserRolesRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<UserRoles> CreateRoleAsync(UserRoles role)
        {
            await dbContext.tblEPUserRoles.AddAsync(role);
            await dbContext.SaveChangesAsync();
            return role;
        }

        public async Task<UserRoles?> DeleteRoleAsync(int id)
        {
            var existingRole = await dbContext.tblEPUserRoles.FirstOrDefaultAsync(ur => ur.ID == id);
            if (existingRole is null)
            {
                return null;
            }
            dbContext.tblEPUserRoles.Remove(existingRole);
            await dbContext.SaveChangesAsync();
            return existingRole;
        }

        public async Task<IEnumerable<UserRoles>> GetAllRolesAsync()
        {
            return await dbContext.tblEPUserRoles.ToListAsync();
        }

        public async Task<UserRoles?> GetRolesByIdAsync(int id)
        {
            return await dbContext.tblEPUserRoles.FirstOrDefaultAsync(ur => ur.ID == id);
        }

        public async Task<UserRoles?> UpdateRoleAsync(UserRoles role)
        {
            var existingRole = dbContext.tblEPUserRoles.FirstOrDefault(ur => ur.ID == role.ID);
            if (existingRole is null)
            {
                return null;
            }
            dbContext.Entry(existingRole).CurrentValues.SetValues(role);
            await dbContext.SaveChangesAsync();
            return existingRole;
        }
    }
}
