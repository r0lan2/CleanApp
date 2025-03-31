using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Api;
using TodoApp.Application.Features.Todo.Queries;
using TodoApp.IntegrationTests.Base;
using Xunit;

namespace TodoApp.IntegrationTests.Controllers
{
    public class TodoControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {

        private readonly CustomWebApplicationFactory<Startup> _factory;

        public TodoControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/todo/all=pageNum=1&pageSize=10");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<PagedListTodoVm>(responseString);

            Assert.IsType<PagedListTodoVm>(result);
            Assert.NotEmpty(result.TodoList);
        }
    }
}
