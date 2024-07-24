using ExpensePilot.API.Models.Domain;
using ExpensePilot.API.Models.Domain.Administration.UserManagement;
using ExpensePilot.API.Models.DTO.Administration.UserManagement;
using ExpensePilot.API.Repositories.Interface.Administration.UserManagement;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpensePilot.API.Controllers.Administration.UserManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        //POST:/api/users
        [HttpPost]
        public async Task<IActionResult> CreateUser(AddUserDto addUser)
        {
            //Convert DTO to Domain Model
            var addu = new Users
            {
                Logon = addUser.Logon,
                FName = addUser.FName,
                LName = addUser.LName,
                Email = addUser.Email,
                ManagerID = addUser.ManagerID,
                DepartmentID = addUser.DepartmentID,
                LastUpdated = addUser.LastUpdated
            };
            await usersRepository.CreateUserAsync(addu);

            //Convert Domain Model to DTO
            var response = new UsersDto
            {
                ID = addu.ID,
                Logon = addu.Logon,
                FName = addu.FName,
                LName = addu.LName,
                Email = addu.Email,
                ManagerID = addu.ManagerID,
                ManagerName = addu.Manager != null ? $"{addu.Manager.FName} {addu.Manager.LName}" : null,
                DepartmentID = addu.DepartmentID,
                DepartmentName = addu.Department != null ? addu.Department.DepartmentName : null,
                LastUpdated = addu.LastUpdated
            };
            return Ok(response);
        }

        //GET:api/users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await usersRepository.GetAllUsersAsync();
            //Convert Domain model to DTO
            var response = new List<UsersDto>();
            foreach (var user in users)
            {
                response.Add(new UsersDto
                {
                    ID = user.ID,
                    Logon = user.Logon,
                    FName = user.FName,
                    LName = user.LName,
                    Email = user.Email,
                    ManagerID = user.ManagerID,
                    ManagerName = user.Manager != null ? $"{user.Manager.FName} {user.Manager.LName}" : null,
                    DepartmentID = user.DepartmentID,
                    DepartmentName = user.Department != null ? $"{user.Department.DepartmentName}" : null,
                    LastUpdated = user.LastUpdated
                });
            }
            return Ok(response);
        }

        //GET:/ap/users/{id?}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUserID([FromRoute] int id)
        {
            var existingUser = await usersRepository.GetByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            //map domain model to dto
            var response = new UsersDto
            {
                ID = existingUser.ID,
                Logon = existingUser.Logon,
                FName = existingUser.FName,
                LName = existingUser.LName,
                Email = existingUser.Email,
                ManagerID = existingUser.ManagerID,
                ManagerName = existingUser.Manager != null ? $"{existingUser.Manager.FName} {existingUser.Manager.LName}" : null,
                DepartmentID = existingUser.DepartmentID,
                DepartmentName = existingUser.Department != null ? $"{existingUser.Department.DepartmentName}" : null,
                LastUpdated = existingUser.LastUpdated
            };
            return Ok(response);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> EditUser([FromRoute] int id, EditUserDto editUser)
        {
            //Convert DTO to Domain Model
            var editu = new Users
            {
                ID = id,
                Logon = editUser.Logon,
                FName = editUser.FName,
                LName = editUser.LName,
                Email = editUser.Email,
                ManagerID = editUser.ManagerID,
                DepartmentID = editUser.DepartmentID,
                LastUpdated = editUser.LastUpdated
            };
            editu = await usersRepository.UpdateUserAsync(editu);
            if (editu is null)
            {
                return NotFound();
            }
            //Convert Domain to DTO
            var response = new UsersDto
            {
                ID = editu.ID,
                Logon = editu.Logon,
                FName = editu.FName,
                LName = editu.LName,
                Email = editu.Email,
                ManagerID = editu.ManagerID,
                ManagerName = editu.Manager != null ? $"{editu.Manager.FName} {editu.Manager.LName}" : null,
                DepartmentID = editu.DepartmentID,
                DepartmentName = editu.Department != null ? editu.Department.DepartmentName : null,
                LastUpdated = editu.LastUpdated
            };
            return Ok(response);
        }

        //DELETE:/api/users/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var existingUser = await usersRepository.DeleteUserAsync(id);
            if (existingUser is null)
            {
                return NotFound();
            }
            //Convert Domain model to dTO
            var response = new UsersDto
            {
                ID = existingUser.ID,
                Logon = existingUser.Logon,
                FName = existingUser.FName,
                LName = existingUser.LName,
                Email = existingUser.Email,
                ManagerID = existingUser.ManagerID,
                ManagerName = existingUser.Manager != null ? $"{existingUser.Manager.FName} {existingUser.Manager.LName}" : null,
                DepartmentID = existingUser.DepartmentID,
                DepartmentName = existingUser.Department != null ? $"{existingUser.Department.DepartmentName}" : null,
                LastUpdated = existingUser.LastUpdated
            };
            return Ok(response);
        }
    }
}
