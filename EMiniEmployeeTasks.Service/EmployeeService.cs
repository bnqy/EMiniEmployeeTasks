using Contracts.Interfaces;
using EMiniEmployeeTasks.Service.Contracts;

namespace EMiniEmployeeTasks.Service;

public class EmployeeService : IEmployeeService
{
    private readonly IRepositoryManager repositoryManager;
    private readonly ILoggerManager loggerManager;

    public EmployeeService(IRepositoryManager repositoryManager,
        ILoggerManager loggerManager)
    {
        this.repositoryManager = repositoryManager;
        this.loggerManager = loggerManager;
    }
}
