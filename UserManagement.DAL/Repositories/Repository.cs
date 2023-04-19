using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UserManagement.DAL.Repositories.Interfaces;

namespace UserManagement.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public Repository(DbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }

        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.SingleOrDefaultAsync(predicate);
        }

        public virtual TEntity Find(params object[] keyValues)
        {
            return _entities.Find(keyValues);
        }

        public async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await _entities.FindAsync(keyValues);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }
    }
}
