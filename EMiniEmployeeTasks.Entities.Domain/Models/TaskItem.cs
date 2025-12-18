using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMiniEmployeeTasks.Entities.Domain.Models;

public class TaskItem : BaseEntity
{
    [Required]
    [StringLength(200)]
    public string Title { get; set; } = default!;

    [StringLength(2000)]
    public string? Description { get; set; }

    [Required]
    public bool IsCompleted { get; set; }

    [Required]
    public int EmployeeId { get; set; }

    public Employee Employee { get; set; } = default!;
}
