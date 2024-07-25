using ExpensePilot.API.Models.Domain.Administration.UserManagement;

namespace ExpensePilot.API.Repositories.Interface.Administration.UserManagement
{
    public interface IPasswordResetRepository
    {
        Task GenerateAndSendResetTokenAsync(Users user);
        Task<bool> ValidateResetTokenAsync(string email, string token);
        Task ResetPasswordAsync(Users user, string newPassword);

    }
}
