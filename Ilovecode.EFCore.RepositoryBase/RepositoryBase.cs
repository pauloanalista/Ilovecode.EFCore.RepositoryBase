using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Ilovecode.EFCore.RepositoryBase
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
       where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        //protected RepositoryBase()
        //{
            
        //}

        public RepositoryBase(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }
        public IQueryable<TEntity> GetAllBy(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Where(where);
        }

        public IQueryable<TEntity> GetAllBy(Expression<Func<TEntity, bool>> where, int skip, int take)
        {
            return _dbSet.Where(where).Skip(skip).Take(take);
        }

        public virtual TEntity GetBy(Func<TEntity, bool> where)
        {
            return _dbSet.FirstOrDefault(where);
        }

        public virtual async Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FirstOrDefaultAsync(where, cancellationToken);
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.AsNoTracking().Any(where);
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().AnyAsync(where, cancellationToken);
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public virtual void AddCollection(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual async Task AddCollectionAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddRangeAsync(entities, cancellationToken);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }


        public virtual void DeleteCollection(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        
    }
}
