
using System;
using TodoApp.Persistence;
using TodoApp.Domain.Entities;
namespace TodoApp.IntegrationTests.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(TodoAppDbContext context)
        {
            
           
            context.Todos.Add(new Todo()
            {
                Description = "task1",
                IsDone = true
            });
            context.Todos.Add(new Todo()
            {
                Description = "task2",
                IsDone = true
            });
        

            context.SaveChanges();
        }
    }
}
