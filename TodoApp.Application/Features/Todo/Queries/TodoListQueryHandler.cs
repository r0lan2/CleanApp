using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TodoApp.Application.Contracts.Persistence;
using AutoMapper;
using System.Threading;
using TodoApp.Application.Paging;


namespace TodoApp.Application.Features.Todo.Queries
{
    public class TodoListQueryHandler : IRequestHandler<GetTodoListQuery, PagedListTodoVm>
    {

        private readonly IAsyncRepository<Domain.Entities.Todo> _todoRepository;
        private readonly IMapper _mapper;

        public TodoListQueryHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Todo> todoRepository) {
            _mapper = mapper;
            _todoRepository = todoRepository;

        }



        public async Task<PagedListTodoVm> Handle(GetTodoListQuery request, CancellationToken cancellationToken)
        {
            var allTodos = (await _todoRepository.ListAllAsync()).OrderBy(x => x.Description);

            request.PageOptions.SetupRestOfDto(allTodos);

            var todos = _mapper.Map<List<TodoListVm>>(allTodos.Page(request.PageOptions.PageNum -1, request.PageOptions.PageSize));

            var output = new PagedListTodoVm(todos, request.PageOptions);

            return output;

        }





    }
}
