using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Application.Features.Todo.Queries
{
    public class TodoListVm
    {
        public int TodoId { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
