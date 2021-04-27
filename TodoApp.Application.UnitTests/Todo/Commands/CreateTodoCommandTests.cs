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
using TodoApp.Application.Profiles;
using TodoApp.Application.UnitTests.Mocks;
using Xunit;

namespace TodoApp.Application.UnitTests.Todo.Commands
{
    public class CreateTodoCommandTests
    {

        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Domain.Entities.Todo>> _todoRepository;
        public CreateTodoCommandTests()
        {
            _todoRepository = RepositoryMocks.GetTodoRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();

        }

        [Fact]
        public async Task Handle_ValidTodo_AddedToTodoRepo()
        {
            var handler = new CreateTodoCommandHandler(_mapper, _todoRepository.Object);

            await handler.Handle(new CreateTodoCommand() { Description = "Test",IsDone = true}, CancellationToken.None);

            var alltodos = await _todoRepository.Object.ListAllAsync();
            alltodos.Count.ShouldBe(3);
        }



    }
}
