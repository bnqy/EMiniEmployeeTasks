using EMiniEmployeeTasks.Entities.Domain.Models;
using EMiniEmployeeTasks.Service.Security;

namespace EMiniEmployeeTasks.Repository.Seed;

public static class UserSeeder
{
    public static async Task SeedAsync(RepositoryContext context)
    {
        if (context.Users!.Any())
            return;

        var adminUser = new User
        {
            Username = "admin",
            PasswordHash = PasswordHasher.Hash("admin123")
        };

        context.Users.Add(adminUser);

        await context.SaveChangesAsync();
    }
}
