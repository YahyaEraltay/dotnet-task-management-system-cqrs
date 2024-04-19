using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.DTOs.DepartmentDTOs.DepartmentRequestModel;
using TaskManagementSystem.Infrastructure.Services;

namespace TaskManagementSystem.Application.Departments.Commands.Update
{
    public class UpdateDepartmentHandler : IRequestHandler<UpdateRequest, UpdateResponse>
    {
        private readonly IDepartmentService _departmentService;

        public async Task<UpdateResponse> Handle(UpdateRequest request, CancellationToken cancellationToken)
        {
            var department = await _departmentService.Detail(new GetDepartmentIdRequestDTO
            {
                Id = request.Id,
            });

            if (department != null)
            {
                var updatedDepartment = new UpdateDepartmentRequestDTO
                {
                    Id = department.Id,
                    DepartmentName = request.DepartmentName
                };

                await _departmentService.Update(updatedDepartment);
            }

            var response = new UpdateResponse
            {
                Id = department.Id,
                DepartmentName = request.DepartmentName
            };

            return response;
        }
    }
}
