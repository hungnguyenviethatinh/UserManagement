using Microsoft.AspNetCore.Mvc;
using UserManagement.Services.Interfaces.Authentication;
using UserManagement.ViewModels.Authentication;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticateController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthenticationRequest model)
        {
            var response = await _authenticationService.AuthenticateAsync(model);

            if (response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(response);
        }
    }
}
