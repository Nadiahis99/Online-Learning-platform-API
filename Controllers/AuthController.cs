using Microsoft.AspNetCore.Mvc;
using Online_L_Platform2.Models;
using Online_L_Platform2.Service.interfaces;
using Online_L_Platform2.DTOs;  
namespace Online_L_Platform2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService; 

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        // api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model) 
        {
            
            var result = await _authService.RegisterAsync(model);

            return Ok(result);
        }
        // api/auth/login

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto) 
        {
            var token = await _authService.LoginAsync(loginDto.Email, loginDto.Password);

            if (token == null)
                return Unauthorized("بيانات غلط");

            return Ok(new { token });
        }
    }
}
