using System.ComponentModel.DataAnnotations;

namespace EMiniEmployeeTasks.Entities.Domain.Models;

public class Employee : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string FirstName { get; set; } = default!;

    [Required]
    [StringLength(100)]
    public string LastName { get; set; } = default!;

    [Required]
    [EmailAddress]
    [StringLength(256)]
    public string Email { get; set; } = default!;

    [Required]
    [StringLength(100)]
    public string Department { get; set; } = default!;

    // Navigation: 1 Employee -> many TaskItems
    public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
}
