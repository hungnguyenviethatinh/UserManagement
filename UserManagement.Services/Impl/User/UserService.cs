using AutoMapper;
using UserManagement.DAL;
using UserManagement.Services.Interfaces.User;
using UserManagement.ViewModels.User;

namespace UserManagement.Services.Impl.User
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddUserAsync(UserAddModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var user = _mapper.Map<DAL.Models.User>(model);

            await _unitOfWork.Users.AddAsync(user);

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> DeleteUserByUserNameAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            var user = await _unitOfWork.Users.FindAsync(username);

            if (user == null)
            {
                throw new KeyNotFoundException(nameof(username));
            }

            _unitOfWork.Users.Remove(user);

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UserViewModel> GetUserByUserNameAsync(string username)
        {
            var user = await _unitOfWork.Users.FindAsync(username);

            return _mapper.Map<UserViewModel>(user);
        }

        public IEnumerable<UserViewModel> GetUsers()
        {
            var users = _unitOfWork.Users.GetAll();

            return _mapper.Map<IEnumerable<UserViewModel>>(users);
        }

        public async Task<int> UpdateUserAsync(UserUpdateModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var user = _mapper.Map<DAL.Models.User>(model);

            _unitOfWork.Users.Update(user);

            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
