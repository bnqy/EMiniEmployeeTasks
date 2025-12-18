using AutoMapper;
using Contracts.Interfaces;
using EMiniEmployeeTasks.Entities.Domain.Exceptions;
using EMiniEmployeeTasks.Entities.Domain.Models;
using EMiniEmployeeTasks.Service.Contracts;
using EMiniEmployeeTasks.Shared.DTOs;

namespace EMiniEmployeeTasks.Service;

public class EmployeeService : IEmployeeService
{
    private readonly IRepositoryManager repositoryManager;
    private readonly ILoggerManager loggerManager;
    private readonly IMapper mapper;

    public EmployeeService(IRepositoryManager repositoryManager,
        ILoggerManager loggerManager,
        IMapper mapper)
    {
        this.repositoryManager = repositoryManager;
        this.loggerManager = loggerManager;
        this.mapper = mapper;
    }

    public async Task<EmployeeDTO> CreateEmployeeAsync(EmployeeForCreationDTO employeeForCreationDTO)
    {
        var employee = this.mapper.Map<Employee>(employeeForCreationDTO);
        this.repositoryManager.Employee.CreateEmployee(employee);

        await this.repositoryManager.SaveAsync();

        var employeeDTO = this.mapper.Map<EmployeeDTO>(employee);

        return employeeDTO;
    }

    public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync(bool trackChanges)
    {
        var employees = await repositoryManager.Employee.GetAllEmployeesAsync(trackChanges);

        var employeesDTO = mapper.Map<IEnumerable<EmployeeDTO>>(employees);

        return employeesDTO;
    }

    public async Task<EmployeeDTO> GetEmployeeAsync(int id, bool trackChanges)
    {
        var employee = await repositoryManager.Employee.GetEmployeeAsync(id, trackChanges);

        if (employee is null)
        {
            throw new EmployeeNotFoundException(id);
        }

        var employeeDTO = mapper.Map<EmployeeDTO>(employee);

        return employeeDTO;
    }
}
