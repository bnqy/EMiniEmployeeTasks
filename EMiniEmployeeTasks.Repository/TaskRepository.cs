using Contracts.Interfaces;
using EMiniEmployeeTasks.Entities.Domain.Models;

namespace EMiniEmployeeTasks.Repository;

public class TaskRepository : RepositoryBase<TaskItem>, ITaskRepository
{
    public TaskRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}
