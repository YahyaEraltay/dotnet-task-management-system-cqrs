using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Departments.Commands.Update
{
    public class UpdateDepartmentResponse
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
    }
}
