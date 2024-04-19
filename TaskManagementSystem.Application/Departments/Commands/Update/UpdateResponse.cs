using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Departments.Commands.Update
{
    public class UpdateResponse
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
    }
}
