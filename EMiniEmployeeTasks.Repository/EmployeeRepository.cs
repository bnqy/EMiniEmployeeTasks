using Contracts.Interfaces;
using EMiniEmployeeTasks.Entities.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace EMiniEmployeeTasks.Repository;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateEmployee(Employee employee)
    {
        Create(employee);
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(x => x.Id)
            .ToListAsync();
    }

    public async Task<Employee> GetEmployeeAsync(int id, bool trackChanges)
    {
        return await FindByCondition(e => e.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }
}
