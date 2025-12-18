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
public class TasksController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public TasksController(IServiceManager serviceManager)
    {
        this._serviceManager = serviceManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await _serviceManager.TaskService.GetAllTasksAsync(trackChanges: false);

        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        var task = await _serviceManager.TaskService.GetTaskAsync(id, trackChanges: false);

        return Ok(task);
    }
}
