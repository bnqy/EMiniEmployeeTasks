using System.ComponentModel.DataAnnotations;

namespace EMiniEmployeeTasks.Shared.DTOs;
public record TaskForUpdateDTO
{
    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; init; }

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; init; }

    [Required(ErrorMessage = "IsCompleted is required.")]
    public bool IsCompleted { get; init; }

    [Required(ErrorMessage = "EmployeeId is required.")]
    public int EmployeeId { get; init; }
}
