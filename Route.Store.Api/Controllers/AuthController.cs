using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;

namespace Route.Store.Api.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class AuthController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpPost(template: "login")] // POST: /api/auth/login
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await serviceManager.AuthService.LoginAsync(loginDto);
            return Ok(result);
        }

        // register
        [HttpPost(template: "register")] // POST: /api/auth/register
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await serviceManager.AuthService.RegisterAsync(registerDto);
            return Ok(result);
        }
    }
}
