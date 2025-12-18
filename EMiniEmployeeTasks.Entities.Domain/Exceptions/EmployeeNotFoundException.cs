using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMiniEmployeeTasks.Entities.Domain.Exceptions
{
    public class EmployeeNotFoundException : NotFoundException
    {
        public EmployeeNotFoundException(int id)
            : base($"Employee with id: {id} does not exist in the DB.")
        {
        }
    }
}
