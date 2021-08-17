using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Threading.Tasks;
using Contract.Dtos;
using Domain.Entities;
using Domain.Repositories;
using LanguageExt;
using Mapster;
using MediatR;

namespace Application.TodoLists.Command
{
    public class CreateTodoListCommand : IRequest<Option<long?>>
    {
        public CreateTodoListCommand(TodoListCreateDto todoList)
        {
            TodoList = todoList;
        }

        public TodoListCreateDto TodoList { get; }
    }

    internal class CreateTodoListHandler : IRequestHandler<CreateTodoListCommand, Option<long?>>
    {
        private readonly ITodoListRepository _repository;

        public CreateTodoListHandler(ITodoListRepository repository)
        {
            _repository = repository;
        }

        public async Task<Option<long?>> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            var todoList = request.TodoList.Adapt<TodoList>();
            return await _repository.CreateAsync(todoList);
        }
    }
}