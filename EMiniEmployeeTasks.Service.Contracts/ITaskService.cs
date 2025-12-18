using EMiniEmployeeTasks.Shared.DTOs;

namespace EMiniEmployeeTasks.Service.Contracts;

public interface ITaskService
{
    Task<IEnumerable<TaskDTO>> GetAllTasksAsync(bool trackChanges);
    Task<TaskDTO> GetTaskAsync(int id, bool trackChanges);
    Task<TaskDTO> CreateTaskAsync(TaskForCreationDTO taskForCreationDTO);
    Task DeleteTaskAsync(int id, bool trackChanges);
    Task UpdateTaskAsync(int id, TaskForUpdateDTO taskForUpdateDTO, bool trackChanges);
}
