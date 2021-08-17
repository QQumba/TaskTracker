using System.Collections.Generic;
using System.Security.Principal;
using Domain.Common;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        
        // 1-N
        public List<TodoList> TodoLists { get; set; }
        public List<TodoItem> TodoItems { get; set; }
    }
}