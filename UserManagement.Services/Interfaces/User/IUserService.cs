using UserManagement.ViewModels.User;

namespace UserManagement.Services.Interfaces.User
{
    public interface IUserService
    {
        Task<UserViewModel> GetUserByUserNameAsync(string username);

        IEnumerable<UserViewModel> GetUsers();

        Task<int> AddUserAsync(UserAddModel model);

        Task<int> UpdateUserAsync(UserUpdateModel model);

        Task<int> DeleteUserByUserNameAsync(string username);
    }
}
