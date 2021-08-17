using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class TodoItem : BaseEntity
    {
        public string Title { get; set; }
        public string Note { get; set; }
        public int NestingLevel { get; set; } = 0;
        public bool Done { get; set; } = false;
        public DateTime? Deadline { get; set; }
        public bool ExactTimeDeadline { get; set; } = false;
        public long? TodoListId { get; set; }
        public long? ParentTodoItemId { get; set; }
        public long UserId { get; set; }

        // N-1
        public TodoList TodoList { get; set; }
        public TodoItem ParentTodoItem { get; set; }
        public User User { get; set; }

        // 1-N
        public List<TodoItem> NestedTodoItems { get; set; }
    }
}