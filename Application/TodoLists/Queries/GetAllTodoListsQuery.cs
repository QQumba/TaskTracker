using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contract.Dtos;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.TodoLists.Queries
{
    public class GetAllTodoListsQuery : IRequest<List<TodoListDto>>
    {
        
    }
    
    internal class GetAllTodoListsHandler : IRequestHandler< GetAllTodoListsQuery, List<TodoListDto>>
    {
        private readonly ITodoListRepository _repository;

        public GetAllTodoListsHandler(ITodoListRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TodoListDto>> Handle(GetAllTodoListsQuery request, CancellationToken cancellationToken)
        {
            var todoLists = await _repository.GetAsync();
            return todoLists.Adapt<List<TodoListDto>>();
        }
    }
}