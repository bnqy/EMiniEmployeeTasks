using Contracts.Interfaces;
using EMiniEmployeeTasks.Entities.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EMiniEmployeeTasks.Repository;

public class TaskRepository : RepositoryBase<TaskItem>, ITaskRepository
{
    public TaskRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {

    }

    public void CreateTask(TaskItem task)
    {
        Create(task);
    }

    public void DeleteTask(TaskItem taskItem)
    {
        Delete(taskItem);
    }

    public async Task<IEnumerable<TaskItem>> GetAllTasksAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(x => x.Id)
            .ToListAsync();
    }

    public async Task<TaskItem> GetTaskAsync(int id, bool trackChanges)
    {
        return await FindByCondition(t => t.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }
}
