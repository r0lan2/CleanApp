using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Paging;

namespace TodoApp.Application.Features.Todo.Queries
{
    public class TodoListVm
    {
        public int TodoId { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }

    public class PagedListTodoVm
    {
        public PagedListTodoVm(IEnumerable<TodoListVm> totList, SortFilterPageOptions sortFilterPageData)
        {
            TodoList = totList;
            SortFilterPageData = sortFilterPageData;
        }

        public IEnumerable<TodoListVm> TodoList { get; private set; }
        public SortFilterPageOptions SortFilterPageData { get; private set; }


    }

}
