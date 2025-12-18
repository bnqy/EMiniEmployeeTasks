using Contracts.Interfaces;

namespace EMiniEmployeeTasks.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext repositoryContext;

    private readonly Lazy<IEmployeeRepository> employeeRepository;

    private readonly Lazy<ITaskRepository> taskRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        this.repositoryContext = repositoryContext;
        this.employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));
        this.taskRepository = new Lazy<ITaskRepository>(() => new TaskRepository(repositoryContext));
    }

    public IEmployeeRepository Employee => this.employeeRepository.Value;

    public ITaskRepository TaskItem => this.taskRepository.Value;

    public async Task SaveAsync()
    {
        await this.repositoryContext.SaveChangesAsync();
    }
}
