using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITodoItemRepository : IRepository<TodoItem>
    {
        public Task<TodoItem> GetByIdIncludeNestingAsync(long id);
        public Task<List<TodoItem>> GetAllIncludeNestingAsync(long userId);
        public Task<List<TodoItem>> GetAllIncludeNestingAsync();
    }
}