namespace EMiniEmployeeTasks.Repository;

using Contracts.Interfaces;
using EMiniEmployeeTasks.Entities.Domain.Models;
using global::EMiniEmployeeTasks.Entities.Domain.Models;
using Microsoft.EntityFrameworkCore;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<User?> GetByUsernameAsync(string username, bool trackChanges)
    {
        return await FindByCondition(
                u => u.Username == username,
                trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreateUser(User user)
    {
        Create(user);
    }
}
