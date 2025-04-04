﻿using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TodoApp.Application.Contracts.Persistence;
using AutoMapper;
using System.Threading;
using System.Collections.Generic;
using FluentValidation.Results;
using TodoApp.Application.Extensions;
using TodoApp.Application.Responses;

namespace TodoApp.Application.Features.Todo.Commands.CreateTodo
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, CreateTodoCommandResponse>
    {

        private readonly IAsyncRepository<Domain.Entities.Todo> _todoRepository;
        private readonly IMapper _mapper;

        public CreateTodoCommandHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Todo> todoRepository)
        {
            _mapper = mapper;
            _todoRepository = todoRepository;

        }


        public async Task<CreateTodoCommandResponse> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var createCategoryCommandResponse = new CreateTodoCommandResponse();

            var validator = new CreateTodoCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                createCategoryCommandResponse.SetValidationsWhenValidationsAreNotOk(validationResult);
            }

            if (createCategoryCommandResponse.Success)
            {
                var newTodo = new Domain.Entities.Todo() { Description = request.Description, IsDone=request.IsDone };

                newTodo = await _todoRepository.AddAsync(newTodo);

                createCategoryCommandResponse.Todo = _mapper.Map<CreateTodoDto>(newTodo);
            }

            return createCategoryCommandResponse;
        }

       

    }
}
