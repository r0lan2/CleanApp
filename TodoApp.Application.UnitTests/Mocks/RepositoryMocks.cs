using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmptyFiles;
using Moq;
using TodoApp.Application.Contracts.Persistence;

namespace TodoApp.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IAsyncRepository<Domain.Entities.Todo>> GetTodoRepository()
        {
            var todos = new List<Domain.Entities.Todo>
            {
                new Domain.Entities.Todo()
                {
                    TodoId = 1,
                    Description = "task 1",
                    IsDone = true
                },
                new Domain.Entities.Todo()
                {
                    TodoId = 1,
                    Description = "task 2",
                    IsDone = true
                }
            };

            var mockTodoRepository = new Mock<IAsyncRepository<Domain.Entities.Todo>>();
            mockTodoRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(todos);

            mockTodoRepository.Setup(repo => repo.AddAsync(It.IsAny<Domain.Entities.Todo>())).ReturnsAsync(
                (Domain.Entities.Todo todo) =>
                {
                    todos.Add(todo);
                    return todo;
                });

            return mockTodoRepository;

        }
    }
}
