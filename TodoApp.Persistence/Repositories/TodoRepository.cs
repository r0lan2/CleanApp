using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Contracts.Persistence;
using TodoApp.Domain.Entities;

namespace TodoApp.Persistence.Repositories
{
    public class TodoRepository : BaseRepository<Todo>, ITodoRepository
    {
        public TodoRepository(TodoAppDbContext dbContext) : base(dbContext)
        {
        }

     

    }
}
