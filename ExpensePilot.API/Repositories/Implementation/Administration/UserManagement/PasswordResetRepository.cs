using Azure.Core;
using ExpensePilot.API.Models.Domain.Administration.UserManagement;
using ExpensePilot.API.Repositories.Interface.Administration.UserManagement;
using Microsoft.AspNetCore.Identity;
using System;

namespace ExpensePilot.API.Repositories.Implementation.Administration.UserManagement
{
    public class PasswordResetRepository : IPasswordResetRepository
    {
        private readonly IUserAccountRepository userAccount;

        public PasswordResetRepository(IUserAccountRepository userAccount)
        {
            this.userAccount = userAccount;
        }
        public async Task GenerateAndSendResetTokenAsync(Users user)
        {
            var login = await userAccount.GetLoginByUserIdAsync(user.ID);
            var token = Guid.NewGuid().ToString();
            login.ResetPasswordToken = token;
            login.ResetPasswordTokenExpiry = DateTime.UtcNow.AddHours(1);//Token valid for an hour
            await userAccount.SaveChangesAsync();

            //var resetLink = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);

            //// Send the email with the reset link
            //await _emailService.SendResetPasswordEmail(user.Email, resetLink);

        }

        public async Task ResetPasswordAsync(Users user, string newPassword)
        {
            var login = await userAccount.GetLoginByUserIdAsync(user.ID);
            var passwordHasher = new PasswordHasher<IdentityUser>();
            login.HashedPassword = passwordHasher.HashPassword(null, newPassword);// Hash the new password
            login.ResetPasswordToken = null;
            login.ResetPasswordTokenExpiry = null;
            login.LastUpdated = DateTime.UtcNow;
            await userAccount.SaveChangesAsync();

        }

        public async Task<bool> ValidateResetTokenAsync(string email, string token)
        {
            var user = await userAccount.GetUserByEmailAsync(email);
            var login = await userAccount.GetLoginByUserIdAsync(user.ID);
            return login != null && login.ResetPasswordToken == token && login.ResetPasswordTokenExpiry >= DateTime.UtcNow;
        }
    }
}
