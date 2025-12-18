using Contracts.Interfaces;
using EMiniEmployeeTasks.Entities.Domain.Models;
using EMiniEmployeeTasks.Service.Contracts;
using EMiniEmployeeTasks.Service.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EMiniEmployeeTasks.Service;

public class AuthService : IAuthService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IConfiguration _configuration;

    public AuthService(
        IRepositoryManager repositoryManager,
        IConfiguration configuration)
    {
        _repositoryManager = repositoryManager;
        _configuration = configuration;
    }

    public async Task<string> LoginAsync(string username, string password)
    {
        var user = await _repositoryManager.User
            .GetByUsernameAsync(username, trackChanges: false);

        if (user == null ||
            !PasswordHasher.Verify(password, user.PasswordHash))
        {
            throw new UnauthorizedAccessException("Invalid username or password");
        }

        return GenerateJwtToken(user);
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

        var credentials = new SigningCredentials(
            key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
