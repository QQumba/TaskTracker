using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mime;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly TaskTrackerDbContext _context;
        private DbSet<TEntity> _set;

        public Repository(TaskTrackerDbContext context)
        {
            _context = context;
        }

        protected DbSet<TEntity> Set => _set ??= _context.Set<TEntity>();

        public virtual async Task<long?> CreateAsync(TEntity entity)
        {
            var entityEntry = await Set.AddAsync(entity);
            await SaveChangesAsync();
            return entityEntry.Entity.Id;
        }

        public Task<TEntity> GetAsync(long id, Expression<Func<TEntity, TEntity>> selectExpression = default)
        {
            return Set.Filter(Filter).Where(t => t.Id == id).Select(selectExpression ?? (x => x)).FirstOrDefaultAsync();
        }

        public Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> condition = default)
        {
            return Set.Where(condition ?? (x => true)).ToListAsync();
        }

        public Task<List<TEntity>> GetAsync(Expression<Func<TEntity, TEntity>> selectExpression,
            Expression<Func<TEntity, bool>> condition = default)
        {
            return Set.Where(condition ?? (x => true)).Select(selectExpression).ToListAsync();
        }

        public async Task<List<TRelatedEntity>> LoadRelatedData<TRelatedEntity>(TEntity entity,
            Expression<Func<TEntity, IEnumerable<TRelatedEntity>>> expression) where TRelatedEntity : BaseEntity
        {
            var collection = _context.Entry(entity).Collection(expression);
            return await collection.Query().ToListAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var e = await GetAsync(entity.Id);
            if (e != null)
            {
                await SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var e = await GetAsync(id);
            Set.Remove(e);
        }

        protected virtual IQueryable<TEntity> Filter(IQueryable<TEntity> entities)
        {
            return entities;
        }
        
        private async Task<int> SaveChangesAsync()
        {
            // TODD remove user id
            foreach (var entry in _context.ChangeTracker.Entries<TodoList>())
            {
                entry.Entity.UserId = 11;
            }

            foreach (var entry in _context.ChangeTracker.Entries<TodoItem>())
            {
                entry.Entity.UserId = 11;
            }

            return await _context.SaveChangesAsync();
        }
    }
}