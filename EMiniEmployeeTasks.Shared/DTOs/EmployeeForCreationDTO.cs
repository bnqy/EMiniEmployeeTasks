using System.ComponentModel.DataAnnotations;

namespace EMiniEmployeeTasks.Shared.DTOs;

public record EmployeeForCreationDTO
{
    [Required(ErrorMessage = "Name is required.")]
    public string FirstName { get; init; }

    [Required(ErrorMessage = "Last name is required.")]
    public string LastName { get; init; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; init; }


    public string Department { get; init; }
}
