using System.Threading;
using System.Threading.Tasks;
using Contract.Dtos;
using Domain.Repositories;
using LanguageExt;
using Mapster;
using MediatR;

namespace Application.TodoItems.Queries
{
    public class GetTodoItemByIdQuery : IRequest<Option<TodoItemDto>>
    {
        public GetTodoItemByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
    
    internal class GetTodoItemByIdHandler : IRequestHandler<GetTodoItemByIdQuery, Option<TodoItemDto>>
    {
        private readonly ITodoItemRepository _repository;

        public GetTodoItemByIdHandler(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Option<TodoItemDto>> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
        {
            var todoItem = await _repository.GetByIdIncludeNestingAsync(request.Id);
            return todoItem.Adapt<TodoItemDto>();
        }
    }
}