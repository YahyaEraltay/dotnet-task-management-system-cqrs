using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Application.Departments.Commands.Create
{
    public class CreateDepartmentMapper
    {
        public static Department MapToEntity(CreateDepartmentRequest request)
        {
            return new Department
            {
                DepartmentName = request.DepartmentName
            };
        }

        public static CreateDepartmentResponse MapToResponse(Department department)
        {
            return new CreateDepartmentResponse
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName
            };
        }
    }
}
