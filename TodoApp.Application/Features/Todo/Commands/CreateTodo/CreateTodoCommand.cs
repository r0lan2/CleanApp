using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TodoApp.Application.Features.Todo.Commands.CreateTodo
{
    public class CreateTodoCommand : IRequest<CreateTodoCommandResponse>
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
