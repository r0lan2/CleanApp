using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace TodoApp.Api.Services
{
    public class LoggedInUserService : Application.Contracts.Identity.ILoggedInUserService
    {
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }
    }
}
