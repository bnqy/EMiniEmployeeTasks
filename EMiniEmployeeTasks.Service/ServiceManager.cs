using AutoMapper;
using Contracts.Interfaces;
using EMiniEmployeeTasks.Service.Contracts;
using Microsoft.Extensions.Configuration;

namespace EMiniEmployeeTasks.Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IEmployeeService> _employeeService;
    private readonly Lazy<ITaskService> _taskService;
    private readonly Lazy<IAuthService> _authService;

    public ServiceManager(IRepositoryManager repositoryManager, 
        ILoggerManager logger,
        IMapper mapper,
        IConfiguration configuration)
    {
        _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger, mapper));
        _taskService = new Lazy<ITaskService>(() => new TaskService(repositoryManager, logger, mapper));
        _authService = new Lazy<IAuthService>(() => new AuthService(repositoryManager, configuration));
    }

    public IEmployeeService EmployeeService => _employeeService.Value;
    public ITaskService TaskService => _taskService.Value;
    public IAuthService AuthService => _authService.Value;
}
