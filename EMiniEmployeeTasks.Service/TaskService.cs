using AutoMapper;
using Contracts.Interfaces;
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

    public async Task<IEnumerable<TaskDTO>> GetAllTasksAsync(bool trackChanges)
    {
        var tasks = await repositoryManager.TaskItem.GetAllTasksAsync(trackChanges);

        var tasksDto = mapper.Map<IEnumerable<TaskDTO>>(tasks);

        return tasksDto;
    }

    public async Task<TaskDTO> GetTaskAsync(int id, bool trackChanges)
    {
        var task = await repositoryManager.TaskItem.GetTaskAsync(id, trackChanges);

        var taskDto = mapper.Map<TaskDTO>(task);

        return taskDto;
    }
}
