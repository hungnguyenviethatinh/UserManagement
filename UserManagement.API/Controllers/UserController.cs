﻿using Microsoft.AspNetCore.Mvc;
using UserManagement.API.Helpers;
using UserManagement.Services.Interfaces.User;
using UserManagement.Shared.Constants;
using UserManagement.ViewModels.User;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Role = RoleConstants.User)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(string userName)
        {
            var user = await _userService.GetUserByUserNameAsync(userName);

            return Ok(user);
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
    }
}
