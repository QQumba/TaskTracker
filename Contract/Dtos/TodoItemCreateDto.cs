using System.ComponentModel.DataAnnotations;

namespace Contract.Dtos
{
    public class TodoItemCreateDto
    {
        [Required]
        public string Title { get; set; }
        public string Note { get; set; }
           
        public long? TodoListId { get; set; }
        public long? ParentTodoItemId { get; set; }
    }
}