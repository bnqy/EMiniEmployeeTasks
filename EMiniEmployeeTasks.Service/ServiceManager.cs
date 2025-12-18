using Contracts.Interfaces;
using EMiniEmployeeTasks.Service.Contracts;

namespace EMiniEmployeeTasks.Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IEmployeeService> _employeeService;
    private readonly Lazy<ITaskService> _taskService;

    public ServiceManager(IRepositoryManager repositoryManager, 
        ILoggerManager logger)
    {
        _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger));
        _taskService = new Lazy<ITaskService>(() => new TaskService(repositoryManager, logger));
    }

    public IEmployeeService EmployeeService => _employeeService.Value;
    public ITaskService TaskService => _taskService.Value;

}
