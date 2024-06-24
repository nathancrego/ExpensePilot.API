using ExpensePilot.API.Models.Domain.Administration.RoleAccessManagement;
using ExpensePilot.API.Models.DTO.Administration.RoleAccessManagement;
using ExpensePilot.API.Repositories.Interface.Administration.RoleAccessManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpensePilot.API.Controllers.Administration.RoleAccessManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccessController : ControllerBase
    {
        private readonly IUserAccessRepository userAccessRepository;

        public UserAccessController(IUserAccessRepository userAccessRepository) {
            this.userAccessRepository = userAccessRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccess(AddUserAccessDto addUserAccess)
        {
            var addua = new UserAccess
            {
                UserID = addUserAccess.UserID,
                UserRoleID = addUserAccess.UserRoleID,
                LastUpdated = addUserAccess.LastUpdated
            };
            await userAccessRepository.CreateAsync(addua);

            var response = new UserAccessDto
            {
                UserAccessID = addua.UserAccessID,
                UserID = addua.UserID,
                UserRoleID = addua.UserRoleID,
                LastUpdated = addua.LastUpdated
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccess()
        {
            var access = await userAccessRepository.GetAllAsync();
            var response = new List<UserAccessDto>();
            foreach(var item in access)
            {
                response.Add(new UserAccessDto
                {
                    UserAccessID = item.UserAccessID,
                    UserID = item.UserID,
                    Logon = item.User.Logon,
                    UserRoleID = item.UserRoleID,
                    Role = item.UserRole.Role,
                    LastUpdated = item.LastUpdated,
                    
                });
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> EditAccess([FromRoute] int id ,EditUserAccessDto editUserAccess)
        {
            var editua = new UserAccess
            {
                UserAccessID = id,
                UserID = editUserAccess.UserID,
                UserRoleID = editUserAccess.UserRoleID,
                LastUpdated = editUserAccess.LastUpdated
            };
            editua = await userAccessRepository.UpdateAsync(editua);
            if(editua is null)
            {
                return NotFound();
            }

            var response = new UserAccessDto
            {
                UserAccessID = editua.UserAccessID,
                UserID = editua.UserID,
                UserRoleID = editua.UserRoleID,
                LastUpdated = editua.LastUpdated
            };
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAccess([FromRoute] int id)
        {
            var existingAccess = await userAccessRepository.DeleteAsync(id);
            if(existingAccess is null)
            {
                return NotFound();
            }
            var response = new UserAccessDto
            {
                UserAccessID = existingAccess.UserAccessID,
                UserID = existingAccess.UserID,
                UserRoleID = existingAccess.UserRoleID,
                LastUpdated = existingAccess.LastUpdated

            };
            return Ok(response);
        }
    }
}
