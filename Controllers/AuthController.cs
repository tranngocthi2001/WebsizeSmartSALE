using DEMOwebAPI.Model;
using DEMOwebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DEMOwebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
       private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authService.LoginAsync(request);
            if (result == null)
            {
                return Unauthorized("Tài khoản hoặc mật khẩu không đúng.");
            }
            return Ok(result);
        }
        
    }
}
