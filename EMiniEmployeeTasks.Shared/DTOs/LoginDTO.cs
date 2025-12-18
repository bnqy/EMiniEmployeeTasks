using System.ComponentModel.DataAnnotations;

namespace EMiniEmployeeTasks.Shared.DTOs;

public class LoginDTO
{
    [Required]
    public string Username { get; set; } = default!;

    [Required]
    public string Password { get; set; } = default!;
}
