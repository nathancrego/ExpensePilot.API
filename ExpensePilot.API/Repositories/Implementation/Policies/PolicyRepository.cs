using ExpensePilot.API.Data;
using ExpensePilot.API.Models.Domain.Policies;
using ExpensePilot.API.Repositories.Interface.Policies;
using Microsoft.EntityFrameworkCore;

namespace ExpensePilot.API.Repositories.Implementation.Policies
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PolicyRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Policy> CreateAsync(Policy policy)
        {
            await dbContext.tblEPPolicy.AddAsync(policy);
            await dbContext.SaveChangesAsync();
            return policy;
        }

        public async Task<Policy?> DeleteAsync(int id)
        {
            var existingPolicy = await dbContext.tblEPPolicy.FirstOrDefaultAsync(p => p.PolicyID == id);
            if(existingPolicy == null)
            {
                return null;
            }
            dbContext.tblEPPolicy.Remove(existingPolicy);
            await dbContext.SaveChangesAsync();
            return existingPolicy;
        }

        public async Task<IEnumerable<Policy>> GetAllAsync()
        {
            return await dbContext.tblEPPolicy.ToListAsync();
        }

        public async Task<Policy?> GetIDAsync(int id)
        {
            return await dbContext.tblEPPolicy.FirstOrDefaultAsync(p=>p.PolicyID == id);
        }

        public async Task<Policy?> UpdateAsync(Policy policy)
        {
            var existingPolicy = await dbContext.tblEPPolicy.FirstOrDefaultAsync(p=>p.PolicyID == policy.PolicyID);
            if( existingPolicy == null)
            {
                return null;
            }
            dbContext.Entry(existingPolicy).CurrentValues.SetValues(policy);
            await dbContext.SaveChangesAsync();
            return existingPolicy;
        }
    }
}
