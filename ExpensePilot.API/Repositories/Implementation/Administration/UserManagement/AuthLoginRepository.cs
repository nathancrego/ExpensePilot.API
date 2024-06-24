using ExpensePilot.API.Data;
using ExpensePilot.API.Models.Domain.Administration.UserManagement;
using ExpensePilot.API.Repositories.Interface.Administration.UserManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExpensePilot.API.Repositories.Implementation.Administration.UserManagement
{
    public class AuthLoginRepository : IAuthLoginRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IPasswordHasher<Users> passwordHasher;

        public AuthLoginRepository(ApplicationDbContext dbContext, IPasswordHasher<Users> passwordHasher)
        {
            this.dbContext = dbContext;
            this.passwordHasher = passwordHasher;
        }

        public async Task Register(Users user, string password)
        {
            var hashedPassword = passwordHasher.HashPassword(user, password);
            user.Login = new Login
            {
                HashedPassword = hashedPassword,
                LastUpdated = DateTime.Now,
            };
            dbContext.tblEPUsers.Add(user);
            await dbContext.SaveChangesAsync();
        }
        public async Task<Users> Login(string logon, string password)
        {
            var user = await dbContext.tblEPUsers.Include(u => u.Login).FirstOrDefaultAsync(u => u.Logon == logon);
            if (user == null)
            {
                return null;
            }
            var result = passwordHasher.VerifyHashedPassword(user, user.Login.HashedPassword, password);
            if(result == PasswordVerificationResult.Failed)
            {
                return null;
            }
            user.Login.LastUpdated = DateTime.Now;
            await dbContext.SaveChangesAsync();
            return user;
        }

       
    }
}
