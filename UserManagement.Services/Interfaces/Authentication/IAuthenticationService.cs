using UserManagement.ViewModels.Authentication;

namespace UserManagement.Services.Interfaces.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest model);
    }
}
