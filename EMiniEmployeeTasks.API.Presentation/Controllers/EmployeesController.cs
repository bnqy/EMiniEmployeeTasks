using EMiniEmployeeTasks.Service.Contracts;
using EMiniEmployeeTasks.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMiniEmployeeTasks.API.Presentation.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public EmployeesController(IServiceManager serviceManager)
    {
        this._serviceManager = serviceManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = await _serviceManager.EmployeeService.GetAllEmployeesAsync(trackChanges: false);

        return Ok(employees);
    }

    [HttpGet("{id:int}", Name = "EmployeeById")]
    public async Task<IActionResult> GetEmployee(int id)
    {
        var employee = await _serviceManager.EmployeeService.GetEmployeeAsync(id, trackChanges: false);
        return Ok(employee);
    }

    [HttpPost(Name = "CreateEmployee")]
    public async Task<IActionResult> CreateEmployee([FromBody] EmployeeForCreationDTO employeeForCreationDTO)
    {
        var addedEmployee = await this._serviceManager.EmployeeService.CreateEmployeeAsync(employeeForCreationDTO);

        return this.CreatedAtRoute("EmployeeById", new { id = addedEmployee.Id }, addedEmployee);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        await this._serviceManager.EmployeeService.DeleteEmployeeAsync(id, false);

        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeForUpdateDTO employeeForUpdateDTO)
    {
        await this._serviceManager.EmployeeService.UpdateEmployeeAsync(id, employeeForUpdateDTO, true);

        return NoContent();
    }

    [HttpGet("{id:int}/tasks")]
    public async Task<IActionResult> GetEmployeeTasks(int id)
    {
        var tasks = await _serviceManager.EmployeeService
            .GetEmployeeTasksAsync(id, trackChanges: false);

        return Ok(tasks);
    }
}
