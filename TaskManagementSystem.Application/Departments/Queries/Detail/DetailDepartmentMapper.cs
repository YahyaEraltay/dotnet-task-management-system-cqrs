using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Application.Departments.Queries.Detail
{
    public class DetailDepartmentMapper
    {
        public static DetailDepartmentResponse MapToResponse(Department department)
        {
            return new DetailDepartmentResponse
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName
            };
        }
    }
}
