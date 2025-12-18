using System.ComponentModel.DataAnnotations;

namespace EMiniEmployeeTasks.Entities.Domain.Models;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
