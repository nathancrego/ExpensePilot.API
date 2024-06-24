using ExpensePilot.API.Models.Domain.Administration.RoleAccessManagement;

namespace ExpensePilot.API.Repositories.Interface.Administration.RoleAccessManagement
{
    public interface IUserAccessRepository
    {
        Task<UserAccess> CreateAsync(UserAccess userAccess);
        Task<UserAccess> UpdateAsync(UserAccess userAccess);
        Task<UserAccess> DeleteAsync(int id);
        Task <IEnumerable<UserAccess>> GetAllAsync();
        
    }
}
