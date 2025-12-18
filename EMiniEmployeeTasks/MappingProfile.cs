using AutoMapper;
using EMiniEmployeeTasks.Entities.Domain.Models;
using EMiniEmployeeTasks.Shared.DTOs;

namespace EMiniEmployeeTasks
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>();

            CreateMap<TaskItem, TaskDTO>();

            CreateMap<EmployeeForCreationDTO, Employee>();

            CreateMap<TaskForCreationDTO, TaskItem>();

            CreateMap<EmployeeForUpdateDTO, Employee>()
                .ReverseMap();

            CreateMap<TaskForUpdateDTO, TaskItem>()
                .ReverseMap();
        }
    }
}
