using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entites;

namespace TaskManagementSystem.Application.Departments.Commands.Delete
{
    public class DeleteDepartmentMapper
    {
        public static Department MapToEntity(Department department)
        {
            return new Department
            {
                Id = department.Id
            };
        }

        public static DeleteDepartmentResponse MapToResponse(bool isDeleted, string message)
        {
            return new DeleteDepartmentResponse
            {
                IsDeleted = isDeleted,
                Message = message
            };
        }
    }
}
