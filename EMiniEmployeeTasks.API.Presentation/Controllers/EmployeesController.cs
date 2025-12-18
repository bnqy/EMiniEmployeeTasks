using EMiniEmployeeTasks.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMiniEmployeeTasks.API.Presentation.Controllers;

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

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetEmployee(int id)
    {
        var employee = await _serviceManager.EmployeeService.GetEmployeeAsync(id, trackChanges: false);
        return Ok(employee);
    }
}
