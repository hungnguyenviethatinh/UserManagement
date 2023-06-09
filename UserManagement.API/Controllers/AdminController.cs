using Microsoft.AspNetCore.Mvc;
using UserManagement.API.Helpers;
using UserManagement.Services.Interfaces.User;
using UserManagement.Shared.Constants;
using UserManagement.ViewModels.User;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Role = RoleConstants.Admin)]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();

            return Ok(users);
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(UserAddModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.AddUserAsync(model);

                return Ok(result);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UpdateUserAsync(model);

                return Ok(result);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            var result = await _userService.DeleteUserByUserNameAsync(userName);

            return Ok(result);
        }
    }
}
