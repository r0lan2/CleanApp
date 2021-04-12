using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using TodoApp.Application.Contracts.Identity;
using TodoApp.Domain.Entities;
using Xunit;
using Xunit.Sdk;

namespace TodoApp.Persistence.IntegrationTests
{
    public class TodoAppDbContextTests
    {

        private readonly TodoAppDbContext _todoAppDbContext;
       

        public TodoAppDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<TodoAppDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;


            _todoAppDbContext = new TodoAppDbContext(dbContextOptions);
        }

        [Fact]
        public void AddNewTodoIsOk()
        {
            var newTodo = new Todo() {Description = "task 1"};

            _todoAppDbContext.Todos.Add(newTodo);

            _todoAppDbContext.SaveChanges();

            Assert.NotEmpty(_todoAppDbContext.Todos.ToList());

        }
    }
}
