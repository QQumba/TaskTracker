using System.Threading;
using System.Threading.Tasks;
using Contract.Dtos;
using Domain.Entities;
using Domain.Repositories;
using LanguageExt;
using Mapster;
using MediatR;

namespace Application.Users.Queries
{
    public class GetUserByEmailQuery : IRequest<Option<UserDto>>
    {
        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }

        public string Email { get; }
    }
    
    internal class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, Option<UserDto>>
    {
        private readonly IUserRepository _repository;

        public GetUserByEmailHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Option<UserDto>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetAsync(request.Email);
            return user.Adapt<UserDto>();
        }
    }
}