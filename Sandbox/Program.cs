using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TaskTracker.Sandbox
{
    class Program
    {
        // private static readonly TaskTrackerDbContext Context = new TaskTrackerDbContext();
        // private static readonly Repository<TodoItem> Repository = new(Context);
        // private static readonly ITodoItemRepository TodoItemRepository = new TodoItemRepository(Context);

        static async Task Main(string[] args)
        {
            Expression<Func<TodoItem, bool>> whereClause = t => t.NestingLevel == 0 && t.Id == 11;
            Expression<Func<TodoItem, TodoItem>> select = t => new TodoItem
            {
                Id = t.Id,
                Title = t.Title,
                ParentTodoItemId = t.ParentTodoItemId,
                NestingLevel = t.NestingLevel,
                TodoListId = t.TodoListId
            };

            await GetAllIncludeNestingAsync(whereClause);
        }
        
        public static async Task<List<TodoItem>> GetAllIncludeNestingAsync(Expression<Func<TodoItem, bool>> exp)
        {
            return new List<TodoItem>();
        }

        static async Task Fill()
        {
            var todo1 = new TodoItem
            {
                Title = "todo 1",
                NestingLevel = 0,
            };

            var todo2 = new TodoItem
            {
                Title = "todo 2",
                NestingLevel = 1,
                ParentTodoItem = todo1,
            };

            // await Repository.CreateAsync(todo1);
            // await Repository.CreateAsync(todo2);
        }

        static async Task Fill2()
        {
            var todo1 = new TodoItem
            {
                Title = "todo 3",
                NestingLevel = 0,
            };

            var todo2 = new TodoItem
            {
                Title = "todo 4",
                NestingLevel = 2,
                ParentTodoItemId = 2,
            };

            // await Repository.CreateAsync(todo1);
            // await Repository.CreateAsync(todo2);
        }
    }
}