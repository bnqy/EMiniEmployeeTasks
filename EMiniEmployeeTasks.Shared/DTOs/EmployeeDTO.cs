using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMiniEmployeeTasks.Shared.DTOs;

public record EmployeeDTO(int Id, string FirstName, string LastName, string Email, string Department);
