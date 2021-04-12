using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace TodoApp.Identity
{
    public class TodoAppIdentityDataContext : IdentityDbContext<ApplicationUser>
    {
        public TodoAppIdentityDataContext(DbContextOptions<TodoAppIdentityDataContext> options) : base(options)
        {
        }
    }
}
