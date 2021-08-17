using System.Threading;
using System.Threading.Tasks;
using Contract.Dtos;
using Domain.Entities;
using Domain.Repositories;
using LanguageExt;
using Mapster;
using MediatR;

namespace Application.TodoItems.Commands
{
    public class CreateTodoItemCommand : IRequest<Option<long?>>
    {
        public CreateTodoItemCommand(TodoItemCreateDto todoItem)
        {
            TodoItem = todoItem;
        }

        public TodoItemCreateDto TodoItem { get; }
    }

    internal class CreateTodoItemHandler : IRequestHandler<CreateTodoItemCommand, Option<long?>>
    {
        private const int MaxNestingLevel = 5;

        private readonly ITodoItemRepository _repository;
        private readonly ITodoListRepository _todoListRepository;

        public CreateTodoItemHandler(ITodoItemRepository repository, ITodoListRepository todoListRepository)
        {
            _repository = repository;
            _todoListRepository = todoListRepository;
        }

        public async Task<Option<long?>> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = request.TodoItem.Adapt<TodoItem>();
            if (todoItem.ParentTodoItemId != null)
            {
                var parent = await _repository.GetAsync((long) todoItem.ParentTodoItemId,
                    x => new TodoItem {Id = x.Id, NestingLevel = x.NestingLevel});
                if (parent is null)
                {
                    return null;
                }

                var nestingLevel = parent.NestingLevel + 1;
                if (nestingLevel >= MaxNestingLevel)
                {
                    return null;
                }

                todoItem.NestingLevel = nestingLevel;
            }

            if (todoItem.TodoListId != null)
            {
                var list = await _todoListRepository.GetAsync((long) todoItem.TodoListId,
                    x => new TodoList {Id = x.Id});
                if (list is null)
                {
                    return null;
                }
            }

            return await _repository.CreateAsync(request.TodoItem.Adapt<TodoItem>());
        }
    }
}