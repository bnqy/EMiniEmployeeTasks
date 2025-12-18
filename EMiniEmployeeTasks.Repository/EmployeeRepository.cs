using Contracts.Interfaces;
using EMiniEmployeeTasks.Entities.Domain.Models;

namespace EMiniEmployeeTasks.Repository;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}
