using AutoMapper;
using Contracts.Interfaces;
using EMiniEmployeeTasks.Entities.Domain.Exceptions;
using EMiniEmployeeTasks.Entities.Domain.Models;
using EMiniEmployeeTasks.Service.Contracts;
using EMiniEmployeeTasks.Shared.DTOs;

namespace EMiniEmployeeTasks.Service;

public class TaskService : ITaskService
{
    private readonly IRepositoryManager repositoryManager;
    private readonly ILoggerManager loggerManager;
    private readonly IMapper mapper;

    public TaskService(IRepositoryManager repositoryManager,
        ILoggerManager loggerManager,
        IMapper mapper)
    {
        this.repositoryManager = repositoryManager;
        this.loggerManager = loggerManager;
        this.mapper = mapper;
    }

    public async Task<TaskDTO> CreateTaskAsync(TaskForCreationDTO taskForCreationDTO)
    {
        var task = this.mapper.Map<TaskItem>(taskForCreationDTO);
        this.repositoryManager.TaskItem.CreateTask(task);

        await this.repositoryManager.SaveAsync();

        var taskDTO = this.mapper.Map<TaskDTO>(task);

        return taskDTO;
    }

    public async Task DeleteTaskAsync(int id, bool trackChanges)
    {
        var task = await this.repositoryManager.TaskItem.GetTaskAsync(id, trackChanges);

        if (task is null)
        {
            throw new TaskNotFoundException(id);
        }

        this.repositoryManager.TaskItem.DeleteTask(task);

        await this.repositoryManager.SaveAsync();
    }

    public async Task<IEnumerable<TaskDTO>> GetAllTasksAsync(bool trackChanges)
    {
        var tasks = await repositoryManager.TaskItem.GetAllTasksAsync(trackChanges);

        var tasksDto = mapper.Map<IEnumerable<TaskDTO>>(tasks);

        return tasksDto;
    }

    public async Task<TaskDTO> GetTaskAsync(int id, bool trackChanges)
    {
        var task = await repositoryManager.TaskItem.GetTaskAsync(id, trackChanges);

        if (task is null)
        {
            throw new TaskNotFoundException(id);
        }

        var taskDto = mapper.Map<TaskDTO>(task);

        return taskDto;
    }
}
