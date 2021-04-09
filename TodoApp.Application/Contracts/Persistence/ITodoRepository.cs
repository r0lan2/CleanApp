using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Contracts.Persistence
{
    public interface ITodoRepository: IAsyncRepository<Todo>
    {
    }
}
