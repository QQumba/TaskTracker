using System.Collections.Generic;
using System.Threading.Tasks;
using Application.TodoItems.Commands;
using Application.TodoItems.Queries;
using Contract.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TaskTracker.Web.Controllers
{
    [ApiController]
    [Route("api/todo-item")]
    public class TodoItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<long>> CreateTodoItem([FromBody] TodoItemCreateDto todoItemDto)
        {
            var command = new CreateTodoItemCommand(todoItemDto);
            var id = await _mediator.Send(command);
            return id.Match<ActionResult<long>>(x => Ok(x), () => BadRequest());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDto>> GetTodoItem([FromRoute] long id)
        {
            var query = new GetTodoItemByIdQuery(id);
            var todoItem = await _mediator.Send(query);
            return todoItem.Match<ActionResult<TodoItemDto>>(x => Ok(x), () => NotFound());
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<TodoItemDto>>> GetAllTodoItems()
        {
            var query = new GetAllTodoItemsQuery();
            var todoItems = await _mediator.Send(query);
            return todoItems;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoItemDto>>> GetUserTodoItems()
        {
            var query = new GetAllTodoItemsQuery();
            var todoItems = await _mediator.Send(query);
            return todoItems;
        }
    }
}