using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Features.Todo.Queries;
using TodoApp.Domain.Entities;
using AutoMapper;
using TodoApp.Application.Features.Todo.Commands.CreateTodo;

namespace TodoApp.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {

            CreateMap<Todo, TodoListVm>().ReverseMap();
            CreateMap<Todo, CreateTodoCommand>().ReverseMap();
            CreateMap<Todo, CreateTodoDto>();
        }
    }
}
