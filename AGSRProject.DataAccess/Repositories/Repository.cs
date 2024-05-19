using AGSRProject.Common.Interfaces.Repositories;
using AGSRProject.DataAccess.Contexts;
using AGSRProject.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AGSRProject.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private bool _disposed;

        protected readonly ApplicationDbContext _context;

        protected readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            this._context = context;
            this._dbSet = this._context.Set<T>();
        }

        public virtual async Task<T?> GetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id), $"Param 'id' is not valid.");
            }

            return await _dbSet.SingleOrDefaultAsync(entity => entity.Id == id).ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var result = await _dbSet.AddAsync(entity);
            var numberOfChanges = await _context.SaveChangesAsync().ConfigureAwait(false);

            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var result = _context.Entry(entity).State = EntityState.Modified;
            var numberOfChanges = await _context.SaveChangesAsync().ConfigureAwait(false);

            return entity;
        }

        public virtual async Task<T?> DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var result = _context.Entry(entity).State = EntityState.Deleted;
            var numberOfChanges = await _context.SaveChangesAsync().ConfigureAwait(false);

            if (numberOfChanges > 0)
            {
                return entity;
            }

            return null;
        }

        public virtual async Task<T?> DeleteAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id), $"Param 'id' is not valid.");
            }

            var entity = await _dbSet.SingleOrDefaultAsync(entity => entity.Id == id).ConfigureAwait(false);

            if (entity == null)
            {
                return null;
            }

            var result = _context.Entry(entity).State = EntityState.Deleted;
            var numberOfChanges = await _context.SaveChangesAsync().ConfigureAwait(false);

            if (numberOfChanges > 0)
            {
                return entity;
            }

            return null;
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            return await _dbSet.AsNoTracking().Where(filter).ToListAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }

        ~Repository()
        {
            Dispose(false);
        }
    }
}
