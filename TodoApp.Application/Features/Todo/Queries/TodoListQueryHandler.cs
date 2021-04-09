using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TodoApp.Application.Contracts.Persistence;
using AutoMapper;
using System.Threading;


namespace TodoApp.Application.Features.Todo.Queries
{
    public class TodoListQueryHandler : IRequestHandler<GetTodoListQuery, List<TodoListVm>>
    {

        private readonly IAsyncRepository<Domain.Entities.Todo> _todoRepository;
        private readonly IMapper _mapper;

        public TodoListQueryHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Todo> todoRepository) {
            _mapper = mapper;
            _todoRepository = todoRepository;

        }



        public async Task<List<TodoListVm>> Handle(GetTodoListQuery request, CancellationToken cancellationToken)
        {
            var allTodos = (await _todoRepository.ListAllAsync()).OrderBy(x => x.Description);
            return _mapper.Map<List<TodoListVm>>(allTodos);
        }


    }
}
