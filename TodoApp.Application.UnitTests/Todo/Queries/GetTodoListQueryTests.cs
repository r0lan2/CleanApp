using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Shouldly;
using TodoApp.Application.Contracts.Persistence;
using TodoApp.Application.Features.Todo.Commands.CreateTodo;
using TodoApp.Application.Features.Todo.Queries;
using TodoApp.Application.Profiles;
using TodoApp.Application.UnitTests.Mocks;
using Xunit;
namespace TodoApp.Application.UnitTests.Todo.Queries
{
    public class GetTodoListQueryTests
    {

        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Domain.Entities.Todo>> _todoRepository;

        public GetTodoListQueryTests()
        {
            _todoRepository = RepositoryMocks.GetTodoRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();

        }

        [Fact]
        public async Task GetTodoListTest()
        {
            var handler = new TodoListQueryHandler(_mapper, _todoRepository.Object);

            var result = await handler.Handle(new GetTodoListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<TodoListVm>>();

            result.Count.ShouldBe(2);
        }


    }
}
