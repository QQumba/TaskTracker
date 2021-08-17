using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class TodoItemRepository : Repository<TodoItem>, ITodoItemRepository
    {
        private const string SqlDirectory = "bin/Debug/net5.0/RawQueries/";
        
        public TodoItemRepository(TaskTrackerDbContext context) : base(context)
        {
        }

        public async Task<TodoItem> GetByIdIncludeNestingAsync(long id)
        {
            var query = (await File.ReadAllTextAsync($"{SqlDirectory}nested-todo-items-by-id.sql")).Replace("(:id)", id.ToString());
            var todoItems = await Set.FromSqlRaw(query).ToListAsync();
            return todoItems.FirstOrDefault(t => t.Id == id);
        }

        public async Task<List<TodoItem>> GetAllIncludeNestingAsync(long userId)
        {
            var query = (await File.ReadAllTextAsync($"{SqlDirectory}nested-todo-items-by-user-id.sql")).Replace("(:user_id)", userId.ToString());
            var todoItems = await Set.FromSqlRaw(query).ToListAsync();
            return todoItems.Where(t => t.NestingLevel == 0).ToList();
        }

        public async Task<List<TodoItem>> GetAllIncludeNestingAsync()
        {
            var query = await File.ReadAllTextAsync($"{SqlDirectory}nested-todo-items.sql");
            var todoItems = await Set.FromSqlRaw(query).ToListAsync();
            return todoItems.Where(t => t.NestingLevel == 0).ToList();
        }
    }
}