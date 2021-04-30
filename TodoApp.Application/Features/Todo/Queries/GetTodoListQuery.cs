using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TodoApp.Application.Paging;

namespace TodoApp.Application.Features.Todo.Queries
{
    public class GetTodoListQuery: IRequest<PagedListTodoVm>
    {
        public SortFilterPageOptions PageOptions { get; set; }
    }
}
