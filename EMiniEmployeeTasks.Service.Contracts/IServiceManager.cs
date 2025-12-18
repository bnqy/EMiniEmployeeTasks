namespace EMiniEmployeeTasks.Service.Contracts;

public interface IServiceManager
{
    IEmployeeService EmployeeService { get; }
    ITaskService TaskService { get; }

    IAuthService AuthService { get; }
}
