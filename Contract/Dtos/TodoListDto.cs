using System.Collections.Generic;

namespace Contract.Dtos
{
    public class TodoListDto
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public List<TodoItemDto> TodoItems { get; set; }
    }
}