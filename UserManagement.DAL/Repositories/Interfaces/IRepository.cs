using System.Linq.Expressions;

namespace UserManagement.DAL.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity Find(params object[] keyValues);

        Task<TEntity> FindAsync(params object[] keyValues);

        IEnumerable<TEntity> GetAll();
    }
}
