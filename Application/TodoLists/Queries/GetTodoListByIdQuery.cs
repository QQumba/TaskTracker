using System.Threading;
using System.Threading.Tasks;
using Contract.Dtos;
using Domain.Repositories;
using LanguageExt;
using Mapster;
using MediatR;

namespace Application.TodoLists.Queries
{
    public class GetTodoListByIdQuery : IRequest<Option<TodoListDto>>
    {
        public GetTodoListByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }

    internal class GetTodoListByIdHandler : IRequestHandler<GetTodoListByIdQuery, Option<TodoListDto>>
    {
        private readonly ITodoListRepository _repository;

        public GetTodoListByIdHandler(ITodoListRepository repository)
        {
            _repository = repository;
        }

        public async Task<Option<TodoListDto>> Handle(GetTodoListByIdQuery request, CancellationToken cancellationToken)
        {
            var todoList = await _repository.GetAsync(request.Id);
            for (int i = todoList.TodoItems.Count - 1; i >= 0; i--)
            {
                var todoItem = todoList.TodoItems[i];
                if (todoItem.NestingLevel != 0)
                {
                    todoList.TodoItems.Remove(todoItem);
                }
            }
            return todoList.Adapt<TodoListDto>();
        }
    }
}