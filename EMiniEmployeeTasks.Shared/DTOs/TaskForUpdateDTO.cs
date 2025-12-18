namespace EMiniEmployeeTasks.Shared.DTOs;
public record TaskForUpdateDTO(string Title, string Description, bool IsCompleted, int EmployeeId);
