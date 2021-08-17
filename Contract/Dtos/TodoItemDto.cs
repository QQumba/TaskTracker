using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contract.Dtos
{
    public class TodoItemDto
    {
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Note { get; set; }
        public int NestingLevel { get; set; }
           
        public long? TodoListId { get; set; }
        public long? ParentTodoItemId { get; set; }

        public List<TodoItemDto> NestedTodoItems { get; set; } = new List<TodoItemDto>();
    }
}