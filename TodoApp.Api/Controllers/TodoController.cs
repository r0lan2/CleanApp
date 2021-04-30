using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using TodoApp.Application.Features.Todo.Queries;
using TodoApp.Application.Features.Todo.Commands.CreateTodo;
using TodoApp.Application.Paging;

namespace TodoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodoController : ControllerBase
    {

        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpGet("all", Name = "GetAllTodos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TodoListVm>>> GetAllTodos([FromBody] GetTodoListQuery options)
        {
            //TODO: Remove this line.
            var dtos = await _mediator.Send(new GetTodoListQuery(){ PageOptions =  new SortFilterPageOptions()
            {
                PageNum = 2,
                PageSize = 10
            }});
            return Ok(dtos);
        }


        [HttpPost(Name = "AddTodo")]
        public async Task<ActionResult<CreateTodoCommandResponse>> Create([FromBody] CreateTodoCommand createCategoryCommand)
        {
            var response = await _mediator.Send(createCategoryCommand);
            return Ok(response);
        }

    }
}
