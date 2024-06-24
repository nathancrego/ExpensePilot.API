using ExpensePilot.API.Models.Domain;
using ExpensePilot.API.Models.Domain.Administration.RoleAccessManagement;
using ExpensePilot.API.Models.DTO.Administration.RoleAccessManagement;
using ExpensePilot.API.Repositories.Interface.Administration.RoleAccessManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpensePilot.API.Controllers.Administration.RoleAccessManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRolesRepository userRolesRepository;

        public UserRolesController(IUserRolesRepository userRolesRepository)
        {
            this.userRolesRepository = userRolesRepository;
        }

        //POST: api/userroles
        [HttpPost]
        public async Task<IActionResult> CreateUserRole(AddUserRoleDto addUserRole)
        {
            //Convert DTO to Domain Model
            var addur = new UserRoles
            {
                Role = addUserRole.Role,
                LastUpdated = addUserRole.LastUpdated
            };
            await userRolesRepository.CreateRoleAsync(addur);

            //Convert Domain Model to DTO
            var response = new UserRolesDto
            {
                ID = addur.ID,
                Role = addur.Role,
                LastUpdated = addur.LastUpdated
            };
            return Ok(response);
        }

        //GET: api/userroles
        [HttpGet]
        public async Task<IActionResult> GetAllUserRoles()
        {
            var roles = await userRolesRepository.GetAllRolesAsync();
            //Convert Domain Model to DTO
            var response = new List<UserRolesDto>();
            foreach (var role in roles)
            {
                response.Add(new UserRolesDto
                {
                    ID = role.ID,
                    Role = role.Role,
                    LastUpdated = role.LastUpdated
                });
            }
            return Ok(response);
        }

        //GET: api/userroles/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUserRoleId([FromRoute] int id)
        {
            var existingRole = await userRolesRepository.GetRolesByIdAsync(id);
            if (existingRole is null)
            {
                return NotFound();
            }
            //Map Domain Model to DTO
            var response = new UserRolesDto
            {
                ID = existingRole.ID,
                Role = existingRole.Role,
                LastUpdated = existingRole.LastUpdated
            };
            return Ok(response);
        }

        //PUT: api/userroles/{id}
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> EditUserRole([FromRoute] int id, EditUserRoleDto editUserRole)
        {
            //Convert DTO to Domain Model
            var editur = new UserRoles
            {
                ID = id,
                Role = editUserRole.Role,
                LastUpdated = editUserRole.LastUpdated
            };
            editur = await userRolesRepository.UpdateRoleAsync(editur);
            if (editur is null)
            {
                return NotFound();
            }
            //Convert Domain Model to DTO
            var response = new UserRolesDto
            {
                ID = editur.ID,
                Role = editur.Role,
                LastUpdated = editur.LastUpdated
            };
            return Ok(response);
        }

        //DELETE:api/userroles/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteUserRole([FromRoute] int id)
        {
            var existingRole = await userRolesRepository.DeleteRoleAsync(id);
            if (existingRole is null)
            {
                return NotFound();
            }
            //Convert Domain model to DTO
            var response = new UserRolesDto
            {
                ID = existingRole.ID,
                Role = existingRole.Role,
                LastUpdated = existingRole.LastUpdated
            };
            return Ok(response);
        }
    }
}
