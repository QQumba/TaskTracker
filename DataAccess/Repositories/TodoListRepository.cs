using System.Linq;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.Repositories
{
    public class TodoListRepository : Repository<TodoList>, ITodoListRepository
    {
        public TodoListRepository(TaskTrackerDbContext context) : base(context)
        {
        }

        protected override IQueryable<TodoList> Filter(IQueryable<TodoList> entities)
        {
            return entities.Include(x => x.TodoItems);
        }
    }
}