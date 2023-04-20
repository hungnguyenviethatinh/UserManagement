using UserManagement.ViewModels.User;

namespace UserManagement.ViewModels.Authentication
{
    public class AuthenticationResponse
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}
