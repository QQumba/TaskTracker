using System;
using System.Linq;
using System.Linq.Expressions;
using Domain.Common;

namespace DataAccess.Repositories
{
    public static class DbSetFilter
    {
        public static IQueryable<TEntity> Filter<TEntity>(this IQueryable<TEntity> queryable,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> func) where TEntity : BaseEntity
        {
            return func.Invoke(queryable);
        }
    }
}