namespace EMiniEmployeeTasks.Shared.DTOs;

public record TaskForCreationDTO(string Title, string Description, bool IsCompleted, int EmployeeId);
