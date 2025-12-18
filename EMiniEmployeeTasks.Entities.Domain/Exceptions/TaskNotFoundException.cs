using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMiniEmployeeTasks.Entities.Domain.Exceptions
{
    public class TaskNotFoundException : NotFoundException
    {
        public TaskNotFoundException(int id)
            : base($"The task with id: {id} doesn't exist in the DB.")
        {
        }
    }
}
