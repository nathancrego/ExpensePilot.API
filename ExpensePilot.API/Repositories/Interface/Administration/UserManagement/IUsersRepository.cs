using ExpensePilot.API.Models.Domain.Administration.UserManagement;

namespace ExpensePilot.API.Repositories.Interface.Administration.UserManagement
{
    public interface IUsersRepository
    {
        Task<Users> CreateUserAsync(Users users);
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users?> GetByIdAsync(int id);
        Task<Users?> UpdateUserAsync(Users users);
        Task<Users?> DeleteUserAsync(int id);
    }
}
