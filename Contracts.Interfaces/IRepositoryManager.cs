namespace Contracts.Interfaces;

public interface IRepositoryManager
{
    IEmployeeRepository Employee { get; }
    ITaskRepository TaskItem { get; }
    Task SaveAsync();
}
