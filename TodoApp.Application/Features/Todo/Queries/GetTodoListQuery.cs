using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TodoApp.Application.Features.Todo.Queries
{
    public class GetTodoListQuery: IRequest< List<TodoListVm>>
    {

    }
}
