using EMiniEmployeeTasks.Service.Contracts;
using EMiniEmployeeTasks.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EMiniEmployeeTasks.API.Presentation.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public AuthController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
    {
        var token = await _serviceManager.AuthService
            .LoginAsync(loginDto.Username, loginDto.Password);

        return Ok(new { token });
    }
}
