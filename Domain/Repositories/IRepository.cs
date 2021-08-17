using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<long?> CreateAsync(TEntity entity);
        Task<TEntity> GetAsync(long id, Expression<Func<TEntity, TEntity>> selectExpression = default);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> condition = default);

        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, TEntity>> selectExpression,
            Expression<Func<TEntity, bool>> condition = default);

        Task<List<TRelatedEntity>> LoadRelatedData<TRelatedEntity>(TEntity entity, Expression<Func<TEntity, IEnumerable<TRelatedEntity>>> expression) where TRelatedEntity : BaseEntity;
        
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}