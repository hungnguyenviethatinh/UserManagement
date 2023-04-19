using UserManagement.DAL.Models;
using UserManagement.DAL.Repositories.Interfaces;

namespace UserManagement.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
