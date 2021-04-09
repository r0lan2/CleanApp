using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Responses;

namespace TodoApp.Application.Features.Todo.Commands.CreateTodo
{
    public class CreateTodoCommandResponse: BaseResponse
    {
        public CreateTodoCommandResponse() : base()
        {

        }

        public CreateTodoDto Category { get; set; }
    }
}
