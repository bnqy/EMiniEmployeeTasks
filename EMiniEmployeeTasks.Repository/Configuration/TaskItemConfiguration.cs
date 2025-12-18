using EMiniEmployeeTasks.Entities.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMiniEmployeeTasks.Repository.Configuration;

public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.HasData(
            new TaskItem
            {
                Id = 1,
                Title = "Implement authentication",
                Description = "Add JWT authentication to the API",
                IsCompleted = false,
                EmployeeId = 1,
                CreatedAt = new DateTime(2024, 1, 5)
            },
            new TaskItem
            {
                Id = 2,
                Title = "Fix migration issues",
                Description = "Resolve SQL Server migration errors",
                IsCompleted = true,
                EmployeeId = 1,
                CreatedAt = new DateTime(2024, 1, 6)
            },
            new TaskItem
            {
                Id = 3,
                Title = "Prepare admin report",
                Description = "Generate monthly admin statistics",
                IsCompleted = false,
                EmployeeId = 3,
                CreatedAt = new DateTime(2024, 1, 7)
            }
        );
    }
}
