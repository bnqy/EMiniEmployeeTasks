using EMiniEmployeeTasks.Entities.Domain.Models;
using EMiniEmployeeTasks.Shared.DTOs;

namespace EMiniEmployeeTasks.Service.Contracts;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync(bool trackChanges);
    Task<EmployeeDTO> GetEmployeeAsync(int id, bool trackChanges);
    Task<EmployeeDTO> CreateEmployeeAsync(EmployeeForCreationDTO employeeForCreationDTO);
    Task DeleteEmployeeAsync(int id, bool trackChanges);
    Task UpdateEmployeeAsync(int id, EmployeeForUpdateDTO employeeForUpdateDTO, bool trackChanges);
    Task<IEnumerable<TaskDTO>> GetEmployeeTasksAsync(int id, bool trackChanges);
}
