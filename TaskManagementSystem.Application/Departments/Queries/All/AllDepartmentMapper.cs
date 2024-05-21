using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Application.Departments.Queries.All
{
    public class AllDepartmentMapper
    {
        public static List<AllDepartmentResponse> MapToResponse(List<Department> departments)
        {
            return departments?.Select(department => new AllDepartmentResponse
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName
            }).ToList();
        }
    }
}
