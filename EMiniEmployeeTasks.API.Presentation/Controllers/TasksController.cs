using EMiniEmployeeTasks.Service.Contracts;
using EMiniEmployeeTasks.Shared.DTOs;
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

    [HttpGet("{id}", Name = "TaskById")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        var task = await _serviceManager.TaskService.GetTaskAsync(id, trackChanges: false);

        return Ok(task);
    }

    [HttpPost(Name = "CreateTask")]
    public async Task<IActionResult> CreateTask([FromBody] TaskForCreationDTO taskForCreationDTO)
    {
        var addedTask = await this._serviceManager.TaskService.CreateTaskAsync(taskForCreationDTO);

        return this.CreatedAtRoute("TaskById", new { id = addedTask.Id }, addedTask);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        await this._serviceManager.TaskService.DeleteTaskAsync(id, false);

        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskForUpdateDTO taskForUpdateDTO)
    {
        await this._serviceManager.TaskService.UpdateTaskAsync(id, taskForUpdateDTO, true);

        return NoContent();
    }
}
