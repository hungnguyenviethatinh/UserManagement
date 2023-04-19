using UserManagement.DAL.Repositories;
using UserManagement.DAL.Repositories.Interfaces;

namespace UserManagement.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        private IUserRepository _users;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUserRepository Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_dbContext);
                }

                return _users;
            }
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
