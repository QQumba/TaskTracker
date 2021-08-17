using System.Threading.Tasks;
using Application.Users.Commands;
using Application.Users.Queries;
using Contract.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Web.JwtUtils;

namespace TaskTracker.Web.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult<Jwt>> SignUp([FromBody] LogInDto logInDto)
        {
            // TODO add token creation
            var command = new CreateUserCommand(logInDto);
            var id = await _mediator.Send(command);
            return id.Match<ActionResult>(x => Ok(new Jwt {Value = x.ToString()}), BadRequest);
        }

        public async Task<ActionResult<Jwt>> LogIn([FromBody] LogInDto logInDto)
        {
            // TODO add token creation
            var query = new GetUserByEmailQuery(logInDto.Email);
            await _mediator.Send(query);
            return NotFound();
        }

        public async Task<Jwt> Authenticate()
        {
            return new();
        }
    }
}