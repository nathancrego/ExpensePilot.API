using ExpensePilot.API.Models.Domain.Administration.UserManagement;

namespace ExpensePilot.API.Repositories.Interface.Administration.UserManagement
{
    public interface IUserAccountRepository
    {
        Task<Users> GetUserByEmailAsync(string email);
        Task<Login> GetLoginByUserIdAsync(int userId);
        Task SaveChangesAsync();
    }
}
