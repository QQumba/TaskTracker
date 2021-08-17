using System;
using System.Threading;
using System.Threading.Tasks;
using Application.TodoItems.Commands;
using Contract.Dtos;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TaskTracker.Web.Controllers;

namespace Web.UnitTests
{
    public class TodoItemControllerTests
    {
        [Test]
        public async Task CreateTodoItem_ReturnsBadRequest_WhenPassNonExistentParentTodoItemId()
        {
            var command = new CreateTodoItemCommand(null);
            // var mediator = Mock.Of<IMediator>();
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(command, CancellationToken.None))
                .Returns(Task.FromResult<Option<long?>>(null));

            var controller = new TodoItemController(mockMediator.Object);
            
            var response = await controller.CreateTodoItem(null);

            Console.WriteLine(response.GetType());
            Console.WriteLine(response.Result.GetType());
            
            Assert.IsTrue(response.Result.GetType() == typeof(BadRequestResult));
        }
    }
}