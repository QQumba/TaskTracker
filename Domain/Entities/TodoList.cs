using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities
{
    public class TodoList : BaseEntity
    {
        public string Title { get; set; }

        public long UserId { get; set; }
        
        // N-1
        public User User { get; set; }
        
        // 1-N
        public List<TodoItem> TodoItems { get; set; }
    }
}