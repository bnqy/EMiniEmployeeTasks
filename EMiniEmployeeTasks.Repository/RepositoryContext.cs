using EMiniEmployeeTasks.Entities.Domain.Models;
using EMiniEmployeeTasks.Repository.Configuration;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EMiniEmployeeTasks.Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new TaskItemConfiguration());

        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }

    public DbSet<Employee>? Employees { get; set; }

    public DbSet<TaskItem>? Tasks { get; set; }

    public DbSet<User>? Users { get; set; }
}
