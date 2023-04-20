using Microsoft.AspNetCore.Mvc;
using UserManagement.Services.Interfaces.User;
using UserManagement.ViewModels.User;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserAddModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.AddUserAsync(model);

                return Ok(result);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UpdateUserAsync(model);

                return Ok(result);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            var result = await _userService.DeleteUserByUserNameAsync(userName);

            return Ok(result);
        }
    }
}
