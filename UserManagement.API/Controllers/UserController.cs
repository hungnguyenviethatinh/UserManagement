using Microsoft.AspNetCore.Mvc;
using UserManagement.Services.Interfaces.User;
using UserManagement.ViewModels.User;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(string userName)
        {
            var user = await _userService.GetUserByUserNameAsync(userName);

            return Ok(user);
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
    }
}
