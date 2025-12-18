using EMiniEmployeeTasks.Entities.Domain.Models;

namespace Contracts.Interfaces;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync(bool trackChanges);

    Task<Employee> GetEmployeeAsync(int id, bool trackChanges);

    void CreateEmployee(Employee employee);

    void DeleteEmployee(Employee employee);
}
