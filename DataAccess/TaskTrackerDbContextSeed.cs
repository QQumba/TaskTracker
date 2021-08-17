using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public static class TaskTrackerDbContextSeed
    {
        public static void Seed(this TaskTrackerDbContext context)
        {
            var set = context.Set<TodoItem>();
            if (!set.Any())
            {
                set.AddRange(GetTodoItemsSeed());
                context.SaveChanges();
            }
        }

        private static IEnumerable<TodoItem> GetTodoItemsSeed()
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
            var todo3 = new TodoItem
            {
                Title = "todo 3",
                NestingLevel = 0,
            };

            return new[] {todo1, todo2, todo3};
        }
    }
}
