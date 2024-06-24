using ExpensePilot.API.Models.Domain.Administration.UserManagement;
using ExpensePilot.API.Models.DTO.Administration.UserManagement;
using ExpensePilot.API.Repositories.Interface.Administration.UserManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpensePilot.API.Controllers.Administration.UserManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthLoginController : ControllerBase
    {
        private readonly IAuthLoginRepository authLoginRepository;

        public AuthLoginController(IAuthLoginRepository authLoginRepository)
        {
            this.authLoginRepository = authLoginRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterDto registerDto)
        {
            var user = new Users
            {
                Logon = registerDto.Logon,
                FName = registerDto.FName,
                LName = registerDto.LName,
                Email = registerDto.Email,
                LastUpdated = DateTime.Now,
            };
            await authLoginRepository.Register(user, registerDto.Password);
            return Ok(new { message = "You have been registered successfully!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginDto loginDto)
        {
            var user = await authLoginRepository.Login(loginDto.Logon, loginDto.Password);
            if(user == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }
            return Ok(new {message = "Login successful!"});
        }
    }
}
