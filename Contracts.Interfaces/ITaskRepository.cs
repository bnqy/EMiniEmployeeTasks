using EMiniEmployeeTasks.Entities.Domain.Models;

namespace Contracts.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<TaskItem>> GetAllTasksAsync(bool trackChanges);

    Task<TaskItem> GetTaskAsync(int id, bool trackChanges);
}
