using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Departments.Commands.Create
{
    public class CreateDepartmentResponse
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
    }
}
