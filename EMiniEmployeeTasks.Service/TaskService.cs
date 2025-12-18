using Contracts.Interfaces;
using EMiniEmployeeTasks.Service.Contracts;

namespace EMiniEmployeeTasks.Service;

public class TaskService : ITaskService
{
    private readonly IRepositoryManager repositoryManager;
    private readonly ILoggerManager loggerManager;

    public TaskService(IRepositoryManager repositoryManager,
        ILoggerManager loggerManager)
    {
        this.repositoryManager = repositoryManager;
        this.loggerManager = loggerManager;
    }
}
