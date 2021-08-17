using System.Threading;
using System.Threading.Tasks;
using Contract.Dtos;
using Domain.Entities;
using Domain.Repositories;
using LanguageExt;
using Mapster;
using MediatR;

namespace Application.Users.Commands
{
    public class CreateUserCommand : IRequest<Option<long?>>
    {
        public CreateUserCommand(LogInDto logInDto)
        {
            LogInDto = logInDto;
        }

        public LogInDto LogInDto { get; }
    }
    
    internal class CreateUserHandler : IRequestHandler<CreateUserCommand, Option<long?>>
    {
        private readonly IUserRepository _repository;

        public CreateUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Option<long?>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.LogInDto.Adapt<User>();
            return await _repository.CreateAsync(user);
        }
    }
}