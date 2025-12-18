using EMiniEmployeeTasks.Entities.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMiniEmployeeTasks.Repository.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasData(
            new Employee
            {
                Id = 1,
                FirstName = "Sam",
                LastName = "Raiden",
                Email = "sam.raiden@company.com",
                Department = "Software Development",
                CreatedAt = new DateTime(2024, 1, 1)
            },
            new Employee
            {
                Id = 2,
                FirstName = "Jana",
                LastName = "McLeaf",
                Email = "jana.mcleaf@company.com",
                Department = "Software Development",
                CreatedAt = new DateTime(2024, 1, 2)
            },
            new Employee
            {
                Id = 3,
                FirstName = "Kane",
                LastName = "Miller",
                Email = "kane.miller@company.com",
                Department = "Administration",
                CreatedAt = new DateTime(2024, 1, 3)
            }
        );
    }
}
