using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Application.Contracts.Identity
{
    public interface ILoggedInUserService
    {
        public string UserId { get; }
    }
}
