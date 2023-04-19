using UserManagement.DAL.Repositories.Interfaces;

namespace UserManagement.DAL
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
