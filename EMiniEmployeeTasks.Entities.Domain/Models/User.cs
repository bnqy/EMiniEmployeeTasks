using System.ComponentModel.DataAnnotations;

namespace EMiniEmployeeTasks.Entities.Domain.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Username { get; set; } = default!;

    [Required]
    public byte[] PasswordHash { get; set; } = default!;
}
