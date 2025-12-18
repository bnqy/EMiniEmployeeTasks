namespace EMiniEmployeeTasks.Shared.DTOs;

public record TaskDTO(int Id, string Title, string Description, bool IsCompleted, int EmployeeId);
