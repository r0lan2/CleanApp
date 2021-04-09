using TodoApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TodoApp.Persistence
{
    public class TodoAppDbContext: DbContext
    {
        public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options)
          : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

    }
}
