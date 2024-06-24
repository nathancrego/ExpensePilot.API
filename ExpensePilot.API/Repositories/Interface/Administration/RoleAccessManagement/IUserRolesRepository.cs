using ExpensePilot.API.Models.Domain.Administration.RoleAccessManagement;

namespace ExpensePilot.API.Repositories.Interface.Administration.RoleAccessManagement
{
    public interface IUserRolesRepository
    {
        Task<UserRoles> CreateRoleAsync(UserRoles role);
        Task<IEnumerable<UserRoles>> GetAllRolesAsync();
        Task<UserRoles?> GetRolesByIdAsync(int id);
        Task<UserRoles?> UpdateRoleAsync(UserRoles role);
        Task<UserRoles?> DeleteRoleAsync(int id);
    }
}
