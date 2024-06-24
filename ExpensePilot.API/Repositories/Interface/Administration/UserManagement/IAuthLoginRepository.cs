using ExpensePilot.API.Models.Domain.Administration.UserManagement;

namespace ExpensePilot.API.Repositories.Interface.Administration.UserManagement
{
    public interface IAuthLoginRepository
    {
        Task Register(Users user,  string password);
        Task<Users> Login(string logon, string password);
    }
}
