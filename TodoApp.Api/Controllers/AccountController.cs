using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TodoApp.Application.Contracts.Identity;
using TodoApp.Application.Models.Authentication;

namespace TodoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private ILogger<AccountController> _logger;
        public AccountController(IAuthenticationService authenticationService, ILogger<AccountController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            _logger.LogInformation("new login action call using this {data}",request);
            return Ok(await _authenticationService.AuthenticateAsync(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            return Ok(await _authenticationService.RegisterAsync(request));
        }
    }
}
