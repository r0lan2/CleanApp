﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Application.Features.Todo.Commands.CreateTodo
{
    public class CreateTodoDto
    {
        public int TodoId { get; set; }
        public string Description { get; set; }
    }
}
