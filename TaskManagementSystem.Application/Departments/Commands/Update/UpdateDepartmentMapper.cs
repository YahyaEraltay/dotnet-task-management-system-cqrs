using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Application.Departments.Commands.Update
{
    public class UpdateDepartmentMapper
    {
        public static Department MapToEntity(UpdateDepartmentRequest request, Department department)
        {
            department.DepartmentName = request.DepartmentName;

            return department;
        }

        public static UpdateDepartmentResponse MapToResponse(Department department)
        {
            return new UpdateDepartmentResponse
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName
            };
        }
    }
}
