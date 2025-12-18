namespace Contracts.Interfaces;

public interface IRepositoryManager
{
    IEmployeeRepository Employee { get; }
    ITaskRepository TaskItem { get; }
    IUserRepository User { get; }

    Task SaveAsync();
}
