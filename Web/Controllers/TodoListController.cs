using System.Collections.Generic;
using System.Threading.Tasks;
using Application.TodoLists.Command;
using Application.TodoLists.Queries;
using Contract.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TaskTracker.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<long>> CreateTodoList([FromBody] TodoListCreateDto todoListDto)
        {
            var command = new CreateTodoListCommand(todoListDto);
            var id = await _mediator.Send(command);
            return id.Match<ActionResult<long>>(x => Ok(x), () => BadRequest());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoListDto>> GetTodoList(long id)
        {
            var query = new GetTodoListByIdQuery(id);
            var todoList = await _mediator.Send(query);
            return todoList.Match<ActionResult>(Ok, BadRequest);
        }
        
        [HttpGet("all")]
        public async Task<ActionResult<List<TodoListDto>>> GetAllTodoLists()
        {
            var query = new GetAllTodoListsQuery();
            var todoList = await _mediator.Send(query);
            return todoList;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<TodoListDto>>> GetUserTodoLists()
        {
            // TODO rewrite for return user related data
            var query = new GetAllTodoListsQuery();
            var todoList = await _mediator.Send(query);
            return todoList;
        }
    }
}