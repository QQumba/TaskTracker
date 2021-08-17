using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contract.Dtos;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.TodoItems.Queries
{
    public class GetAllTodoItemsQuery: IRequest<List<TodoItemDto>>
    {
        
    }

    internal class GetAllTodoItemsHandler : IRequestHandler<GetAllTodoItemsQuery, List<TodoItemDto>>
    {
        private readonly ITodoItemRepository _repository;

        public GetAllTodoItemsHandler(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TodoItemDto>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
        {
            var todoItems = await _repository.GetAllIncludeNestingAsync(); 
            return todoItems.Adapt<List<TodoItemDto>>();
        }
    }
}