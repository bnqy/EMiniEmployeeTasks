using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    using EMiniEmployeeTasks.Entities.Domain.Models;

    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username, bool trackChanges);
        void CreateUser(User user);
    }
}
